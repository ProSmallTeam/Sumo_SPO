namespace OzonShop
{
    using System;
    using System.Collections.Generic;

    using HtmlAgilityPack;

    using Network;
    using Network.Interfaces;

    using Sumo.API;

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
            var page = Network.LoadDocument("http://www.ozon.ru/?context=search&text=" + pattern.SecondaryFields["Title"] + "&group=div_book");

            var metaContainer = this.Parse(page);
            //this.UploadComments(metaContainer);

            return metaContainer;
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

        /// <summary>
        /// The parse.
        /// </summary>
        /// <param name="document">
        /// The document.
        /// </param>
        /// <returns>
        /// The <see cref="BookInfo[]"/>.
        /// </returns>
        private IList<Book> Parse(Page document)
        {
            // Заводим контейнер для сохранения информации
            var book = new Book();

            // Вытаскиваем метаинформацию
            book.SecondaryFields["UrlLink"].Add(document.Url);
            book.SecondaryFields["EnTitle"].Add(this.Get("//div[@class='product-detail']/p[2]", document.Document));
            book.SecondaryFields["RuTitle"].Add(this.Get("//h1[@itemprop='name']", document.Document));
            book.SecondaryFields["InternalId"].Add(this.Get("//div[@class='product-detail']/p[1]", document.Document).Remove(0, "ID ".Length));
            book.SecondaryFields["Author"].Add(this.Get("//p[@itemprop='author']/a", document.Document));
            book.SecondaryFields["PublishHouse"].Add(Get("//p[@itemprop='publisher']/a", document.Document));
            book.SecondaryFields["Language"].Add(Get("//p[@itemprop='inLanguage']", document.Document).Remove(0, "Языки: ".Length));

            // Вытаскиваем ISBN и год издания
            var publishYearAndIsbn = this.Get("//p[@itemprop='isbn']",document.Document).Substring("ISBN ".Length);
            book.SecondaryFields["ISBN"].AddRange(publishYearAndIsbn.Substring(0, publishYearAndIsbn.Length - "; 2013 г.".Length).Split(new[] { ',', ' ' }));
            book.SecondaryFields["ISBN"].RemoveAll(isbn => isbn == string.Empty);
            book.SecondaryFields["PublishYear"].Add(publishYearAndIsbn.Substring(publishYearAndIsbn.Length - "2013 г.".Length, 4));

            // Вытаскиваем количество страниц в книге
            var pageCountInText = Get("//span[@itemprop='numberOfPages']", document.Document);
            book.SecondaryFields["PageCount"].Add(Convert.ToInt32(pageCountInText.Substring(0, pageCountInText.Length - 5)).ToString());

            // Вытаскиваем цепочку категорий
            // var ozonChainCategories = new OzonChainCategories();
            // ozonChainCategories.Parse(this.Document.DocumentNode.SelectNodes("//ul[@class=\"navLine\"]")[0].InnerHtml);
            // book.Сategories = ozonChainCategories;

            // вытаскиваем ссылку на картинку с книгой
            book.SecondaryFields["PictureLink"].Add(document.Document.DocumentNode.SelectNodes("//img[@class=\"eMicroGallery_fullImage\"]")[0].Attributes["src"].Value);

            // втаскиваем аннотацию на книгу
            // container.Annotation = this.Get("//div[@id='detail_description']/table/tr/td");
            
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
        /// 
        /// </param>
        /// <returns>
        /// Содержимое тега.
        /// </returns>
        private string Get(string query, HtmlDocument document)
        {
            var nodes = document.DocumentNode.SelectNodes(query);
            return nodes.Count == 0 ? string.Empty : nodes[0].InnerText;
        }
    }
}
