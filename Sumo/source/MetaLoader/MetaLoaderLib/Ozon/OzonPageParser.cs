namespace MetaLoaderLib.Ozon
{
    using System;
    using System.Linq;

    using HtmlAgilityPack;

    using MetaLoaderLib;
    using MetaLoaderLib.Interfaces;

    /// <summary>
    /// Класс для парсинга страницы с книгой, загруженной с сайта Ozon.ru
    /// </summary>
    public class OzonPageParser : IPageParser
    {
        /// <summary>
        /// Инициализирует класс для парсинга страницы с сайта Ozon.ru
        /// </summary>
        /// <param name="document">
        /// Страница в HTML документе для парсинга.
        /// </param>
        /// <param name="url">
        /// Url страницы для парсинга.
        /// </param>
        public OzonPageParser(HtmlDocument document, string url)
        {
            this.Document = document;
            this.Url = url;
        }

        /// <summary>
        /// Url страницы для парсинга.
        /// </summary>
        private string Url { get; set; }

        /// <summary>
        /// Страница в HTML документе для парсинга.
        /// </summary>
        private HtmlDocument Document { get; set; }

        /// <summary>
        /// Метод для парсинга страницы.
        /// </summary>
        /// <param name="isbn">
        /// ISBN книги.
        /// </param>
        /// <returns>
        /// Контейнер с информацией о книге.
        /// </returns>
        public MetaInformationContainer Parse(string isbn)
        {
            var page = PageLoader.LoadFromUrl("http://www.ozon.ru/?context=search&text=" + isbn + "&group=div_book");

            var document = new HtmlDocument();
            document.LoadHtml(page.PageText);
            this.Document = document;

            var metaContainer = this.Parse();
            this.UploadComments(metaContainer);

            return metaContainer;
        }

        /// <summary>
        /// Парсинг страницы.
        /// </summary>
        /// <returns>
        /// Коллекция с распарсенными страницами.
        /// </returns>
        public MetaInformationContainer Parse()
        {
            // Заводим контейнер для сохранения информации
            var container = new MetaInformationContainer();

            // Вытаскиваем метаинформацию
            container.Link = this.Url;
            container.EnTitle = this.Get("//div[@class='product-detail']/p[2]");
            container.RuTitle = this.Get("//h1[@itemprop='name']");
            container.InternalId = this.Get("//div[@class='product-detail']/p[1]").Remove(0, "ID ".Length);
            container.Author = this.Get("//p[@itemprop='author']/a");
            container.Annotation = this.Get("//div[@id='detail_description']/table/tr/td");
            container.PublishHouse = this.Get("//p[@itemprop='publisher']/a");
            container.Language = this.Get("//p[@itemprop='inLanguage']").Remove(0, "Языки: ".Length);

            // Вытаскиваем ISBN и год издания
            var publishYearAndIsbn = this.Get("//p[@itemprop='isbn']").Substring("ISBN ".Length);
            container.ISBN = publishYearAndIsbn.Substring(0, publishYearAndIsbn.Length - "; 2013 г.".Length).Split(new[] { ',', ' ' }).ToList();
            container.ISBN.RemoveAll(isbn => isbn == string.Empty);
            container.PublishYear = publishYearAndIsbn.Substring(publishYearAndIsbn.Length - "2013 г.".Length, 4);

            // Вытаскиваем количество страниц в книге
            var pageCountInText = this.Get("//span[@itemprop='numberOfPages']");
            container.PageCount = Convert.ToInt32(pageCountInText.Substring(0, pageCountInText.Length - 5));

            // Вытаскиваем цепочку категорий
            var ozonChainCategories = new OzonChainCategories();
            ozonChainCategories.Parse(this.Document.DocumentNode.SelectNodes("//ul[@class=\"navLine\"]")[0].InnerHtml);
            container.Сategories = ozonChainCategories;

            // container.PictureLink = _document.DocumentNode.SelectNodes("//div[@class=\"eMicroGallery_full\"]")[0].InnerText;

            // Возвращаем контейнер
            return container;
        }

        /// <summary>
        /// Метод для получения тега по XPath выражению.
        /// </summary>
        /// <param name="query">
        /// XPath выражение тега.
        /// </param>
        /// <returns>
        /// Содержимое тега.
        /// </returns>
        private string Get(string query)
        {
            var nodes = this.Document.DocumentNode.SelectNodes(query);
            return nodes.Count == 0 ? string.Empty : nodes[0].InnerText;
        }

        /// <summary>
        /// Подгружаем комментарии пользователей.
        /// </summary>
        /// <param name="metaContainer">
        /// Контейнер для сохранения комментариев пользователей.
        /// </param>
        private void UploadComments(MetaInformationContainer metaContainer)
        {
            var commentsBlock =
                PageLoader.LoadFromUrl(
                    "http://www.ozon.ru/DetailLoader.aspx?module=comments&id=" + metaContainer.InternalId
                    + "&perPage=1&page=1000");
            metaContainer.UsersComments = new OzonCommentsList();
            metaContainer.UsersComments.Parse(commentsBlock.PageText);
        }
    }
}