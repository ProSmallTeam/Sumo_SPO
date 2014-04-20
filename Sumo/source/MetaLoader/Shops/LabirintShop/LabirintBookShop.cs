namespace LabirintShop
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Network;
    using Network.Interfaces;
    using HtmlAgilityPack;

    using Sumo.Api;

    /// <summary>
    /// The labirint book shop.
    /// </summary>
    public class LabirintBookShop : IBookShop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabirintBookShop"/> class.
        /// </summary>
        /// <param name="network">
        /// The network.
        /// </param>
        public LabirintBookShop(INetwork network)
        {
            this.Network = (HttpNetwork)network;
        }

        /// <summary>
        /// Gets or sets the network.
        /// </summary>
        private HttpNetwork Network { get; set; }

        /// <summary>
        /// The search.
        /// </summary>
        /// <param name="pattern">
        /// The pattern.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public IList<Book> Search(Book pattern)
        {
            var metaContainer = new List<Book>();

            metaContainer.AddRange(SearchByField(pattern.Name));
            metaContainer.AddRange(SearchByField(pattern.SecondaryFields["ISBN"][0]));

            return metaContainer;
        }

        /// <summary>
        /// The search by field.
        /// </summary>
        /// <param name="field">
        /// The field.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        private List<Book> SearchByField(string field)
        {
            var metaContainers = new List<Book>();

            var page =
                this.Network.LoadDocument(
                    "http://www.labirint.ru/search/" + field + "/");

            if (page.Url.Contains("/search/"))
                metaContainers.AddRange(ParseMultiPage(page.Document));
            else if (page.Url.Contains("/books/"))
                metaContainers.AddRange(Parse(page));

            return metaContainers;
        }

        /// <summary>
        /// The parse multi page.
        /// </summary>
        /// <param name="document">
        /// The document.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        private List<Book> ParseMultiPage(HtmlDocument document)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The parse.
        /// </summary>
        /// <param name="document">
        /// The document.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Book> Parse(Page document)
        {
            // Заводим контейнер для сохранения информации
            var book = new Book();
            book.SecondaryFields = new Dictionary<string, List<string>>();

            // Вытаскиваем метаинформацию
            book.Name = this.Get(".//*[@id='product-title']/h1", document.Document).Split(new[] { ':' })[1].Remove(0, 1);
            book.SecondaryFields.Add("UrlLink", new List<string> { document.Url });
            book.SecondaryFields.Add(
                "InternalId",
                new List<string>
                    {
                        this.Get(".//*[@id='product-specs']/div[1]/div[4]", document.Document)
                            .Remove(0, "ID товара: ".Length)
                    });
            book.SecondaryFields.Add(
                "Author",
                new List<string> { this.Get(".//*[@id='product-title']/h1", document.Document).Split(new[] { ':' })[0] });
            book.SecondaryFields.Add(
                "PublishHouse", new List<string> { this.Get(".//*[@id='product-specs']/div[1]/div[2]/a", document.Document) });
            /*book.SecondaryFields.Add(
                "Language",
                new List<string>
                    {
                        this.Get("//p[@itemprop='inLanguage']", document.Document)
                            .Remove(0, "Языки: ".Length)
                    });*/

            // Вытаскиваем ISBN и год издания
            var publishYearAndHouse = this.Get(".//*[@id='product-specs']/div[1]/div[2]", document.Document);
            book.SecondaryFields.Add(
                "PublishYear",
                new List<string> { publishYearAndHouse.Substring(publishYearAndHouse.Length - 7, 4) });

            var isbn = this.Get(".//*[@id='product-specs']/div[1]/div[5]", document.Document);

            book.SecondaryFields.Add("ISBN", new List<string> { null });
            book.SecondaryFields["ISBN"].AddRange(
                isbn.Substring("ISBN: ".Length, isbn.Length - "ISBN: ".Length)
                                  .Split(new[] { ',', ' ' }));
            book.SecondaryFields["ISBN"].RemoveAll(elem => elem == string.Empty);
            book.SecondaryFields["ISBN"].RemoveAll(elem => elem == null);
            

            // Вытаскиваем количество страниц в книге
            var pagesInfo = this.Get(".//*[@id='product-specs']/div[1]/div[6]", document.Document);
            var pagesCount = pagesInfo.Substring("Страниц: ".Length, pagesInfo.Length - "Страниц: ".Length).Split(new[] { ' ' })[0];
            book.SecondaryFields.Add(
                "PageCount",
                new List<string>
                    {
                        pagesCount
                    });

            // вытаскиваем ссылку на картинку с книгой
            /*book.SecondaryFields.Add(
                "PictureLink",
                new List<string>
                    {
                        document.Document.DocumentNode.SelectNodes(
                            "//img[@class=\"eMicroGallery_fullImage\"]")[0].Attributes["src"].Value
                    });*/

            // Возвращаем контейнер
            return new List<Book> { book };
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="document">
        /// The document.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string Get(string query, HtmlDocument document)
        {
            var nodes = document.DocumentNode.SelectNodes(query);
            return nodes.Count == 0 ? string.Empty : nodes[0].InnerText;
        }
    }
}
