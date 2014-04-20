namespace OzonShop
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using HtmlAgilityPack;

    using Network;
    using Network.Interfaces;

    using Sumo.Api;

    /// <summary>
    /// The ozon book shop.
    /// </summary>
    public class OzonBookShop : IBookShop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OzonBookShop"/> class.
        /// </summary>
        /// <param name="network">
        /// The network.
        /// </param>
        public OzonBookShop(INetwork network)
        {
            Network = (HttpNetwork)network;
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
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        private List<Book> SearchByField(string field)
        {
            var metaContainers = new List<Book>();

            var page =
                this.Network.LoadDocument(
                    "http://www.ozon.ru/?context=search&text=" + field + "&group=div_book");

            if (page.Url.Contains("context=search"))
                metaContainers.AddRange(ParseMultiPage(page.Document));
            else if (page.Url.Contains("context/detail/id"))
                metaContainers.AddRange(this.Parse(page));

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
        private List<Book> ParseMultiPage(HtmlDocument document)
        {
            var bookHrefBlocks = document.DocumentNode.SelectNodes("//div[@class='bOneTile inline']");
            
            var metaContainers = new List<Book>();
            
            foreach (var bookHrefBlock in bookHrefBlocks)
            {
                var bookHref = bookHrefBlock.SelectNodes("//a[class='jsUpdateLink jsPic']@href");
                var page =
                    this.Network.LoadDocument(
                        "http://www.ozon.ru" + bookHref);

                metaContainers.AddRange(this.Parse(page));
            }
            
            return metaContainers;
        }

        /// <summary>
        /// The parse.
        /// </summary>
        /// <param name="document">
        /// The document.
        /// </param>
        /// <returns>
        /// The <see cref="BookInfo[]"/>.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1116:SplitParametersMustStartOnLineAfterDeclaration", Justification = "Reviewed. Suppression is OK here.")]
        public List<Book> Parse(Page document)
        {
            // Заводим контейнер для сохранения информации
            var book = new Book();
            book.SecondaryFields = new Dictionary<string, List<string>>();

            // Вытаскиваем метаинформацию
            book.Name = this.Get("//h1[@itemprop='name']", document.Document);
            book.SecondaryFields.Add("UrlLink", new List<string> { document.Url });
            book.SecondaryFields.Add(
                "InternalId",
                new List<string>
                    {
                        this.Get("//div[@class='product-detail']/p[1]", document.Document)
                            .Remove(0, "ID ".Length)
                    });
            book.SecondaryFields.Add(
                "Author", new List<string> { this.Get("//p[@itemprop='author']/a", document.Document) });
            book.SecondaryFields.Add(
                "PublishHouse", new List<string> { this.Get("//p[@itemprop='publisher']/a", document.Document) });
            book.SecondaryFields.Add(
                "Language",
                new List<string>
                    {
                        this.Get("//p[@itemprop='inLanguage']", document.Document)
                            .Remove(0, "Языки: ".Length)
                    });

            // Вытаскиваем ISBN и год издания
            var publishYearAndIsbn = this.Get("//p[@itemprop='isbn']", document.Document).Substring("ISBN ".Length);
            book.SecondaryFields.Add("ISBN", new List<string> { null });
            book.SecondaryFields["ISBN"].AddRange(
                publishYearAndIsbn.Substring(0, publishYearAndIsbn.Length - "; 2013 г.".Length)
                                  .Split(new[] { ',', ' ' }));
            book.SecondaryFields["ISBN"].RemoveAll(isbn => isbn == string.Empty);
            book.SecondaryFields["ISBN"].RemoveAll(isbn => isbn == null);
            book.SecondaryFields.Add(
                "PublishYear",
                new List<string> { publishYearAndIsbn.Substring(publishYearAndIsbn.Length - "2013 г.".Length, 4) });

            // Вытаскиваем количество страниц в книге
            var pageCountInText = this.Get("//span[@itemprop='numberOfPages']", document.Document);
            book.SecondaryFields.Add(
                "PageCount",
                new List<string>
                    {
                        Convert.ToInt32(pageCountInText.Substring(0, pageCountInText.Length - 5)).ToString()
                    });

            // Вытаскиваем цепочку категорий
            // var ozonChainCategories = new OzonChainCategories();
            // ozonChainCategories.Parse(this.Document.DocumentNode.SelectNodes("//ul[@class=\"navLine\"]")[0].InnerHtml);
            // book.Сategories = ozonChainCategories;

            // вытаскиваем ссылку на картинку с книгой
            book.SecondaryFields.Add(
                "PictureLink",
                new List<string>
                    {
                        document.Document.DocumentNode.SelectNodes(
                            "//img[@class=\"eMicroGallery_fullImage\"]")[0].Attributes["src"].Value
                    });

            // втаскиваем аннотацию на книгу
            // container.Annotation = this.Get("//div[@id='detail_description']/table/tr/td");

            // втаскиваем комментарии на книгу

            // Возвращаем контейнер
            return new List<Book> { book };
        }

        /// <summary>
        /// Метод для получения тега по XPath выражению.
        /// </summary>
        /// <param name="query">
        /// XPath выражение тега.
        /// </param>
        /// <param name="document">
        /// документ для поиска изла с xPath выражением
        /// </param>
        /// <returns>
        /// Содержимое тега.
        /// </returns>
        private string Get(string query, HtmlDocument document)
        {
            var nodes = document.DocumentNode.SelectNodes(query);
            return nodes.Count == 0 ? string.Empty : nodes[0].InnerText;
        }

        /// <summary>
        /// Подгружаем комментарии пользователей.
        /// </summary>
        /// <param name="metaContainer">
        /// Контейнер для сохранения комментариев пользователей.
        /// </param>
        private void UploadComments(Book metaContainer)
        {
            var commentsBlock = Network.LoadDocument("http://www.ozon.ru/DetailLoader.aspx?module=comments&id="
                    + metaContainer.SecondaryFields["InternalId"]
                    + "&perPage=1&page=1000");
            // metaContainer.UsersComments = new OzonCommentsList();
            // metaContainer.UsersComments.Parse(commentsBlock.PageText);
        }
    }
}
