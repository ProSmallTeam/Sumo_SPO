namespace MetaLoader.Ozon
{
    using System;
    using System.Linq;

    using HtmlAgilityPack;

    using MetaLoader;

    /// <summary>
    /// Класс для парсинга страницы с книгой, загруженной с сайта Ozon.ru
    /// </summary>
    public class OzonPageParser
    {
        /// <summary>
        /// Url страницы для парсинга.
        /// </summary>
        private readonly string url;

        /// <summary>
        /// Страница в HTML документе для парсинга.
        /// </summary>
        private readonly HtmlDocument document;

        /// <summary>
        /// Инициализирует класс для парсинга страницы с сайта Ozon.ru
        /// </summary>
        /// <param name="document">
        /// Страница в HTML документе для парсинга.
        /// </param>
        /// <param name="url">
        /// Url страницы для парсинга.
        /// </param>
        private OzonPageParser(HtmlDocument document, string url)
        {
            this.document = document;
            this.url = url;
        }

        /// <summary>
        /// Метод для парсинга страницы.
        /// </summary>
        /// <param name="isbn">
        /// ISBN книги.
        /// </param>
        /// <returns>
        /// Контейнер с информацией о книге.
        /// </returns>
        public static MetaInformationContainer Parse(string isbn)
        {
            var page = PageLoader.LoadFromUrl("http://www.ozon.ru/?context=search&text=" + isbn + "&group=div_book");

            var document = new HtmlDocument();
            document.LoadHtml(page.PageText);

            var parser = new OzonPageParser(document, page.Url);
            return parser.Parse();
        }

        /// <summary>
        /// Парсинг страницы.
        /// </summary>
        /// <returns>
        /// Коллекция с распарсенными страницами.
        /// </returns>
        private MetaInformationContainer Parse()
        {
            // Заводим контейнер для сохранения информации
            var container = new MetaInformationContainer();

            // Вытаскиваем метаинформацию
            container.Link = this.url;
            container.EnTitle = this.Get("//div[@class='product-detail']/p[2]");
            container.RuTitle = this.Get("//h1[@itemprop='name']");
            container.InternalId = this.Get("//div[@class='product-detail']/p[1]").Remove(0, "ID ".Length);
            container.Author = this.Get("//p[@itemprop='author']/a");
            container.Annotation = this.Get("//div[@id='detail_description']/table/tr/td");
            container.PublishHouse = this.Get("//p[@itemprop='publisher']/a");
            container.Languages = this.Get("//p[@itemprop='inLanguage']").Remove(0, "Языки: ".Length);

            // Вытаскиваем ISBN и год издания
            var publishYearAndIsbn = this.Get("//p[@itemprop='isbn']").Substring("ISBN ".Length);
            container.ISBN = publishYearAndIsbn.Substring(0, publishYearAndIsbn.Length - "; 2013 г.".Length).Split(new[] { ',', ' ' }).ToList();
            container.ISBN.RemoveAll(isbn => isbn == string.Empty);
            container.PublishYear = publishYearAndIsbn.Substring(publishYearAndIsbn.Length - "2013 г.".Length, 4);

            // Вытаскиваем количество страниц в книге
            var pageCountInText = this.Get("//span[@itemprop='numberOfPages']");
            container.PageCount = Convert.ToInt32(pageCountInText.Substring(0, pageCountInText.Length - 5));

            // Вытаскиваем цепочку категорий
            container.Сategories = OzonChainCategories.Parse(this.document.DocumentNode.SelectNodes("//ul[@class=\"navLine\"]")[0].InnerHtml);

            // Вытаскиваем коментарии пользователей
            Page comentsBlock = PageLoader.LoadFromUrl("http://www.ozon.ru/DetailLoader.aspx?module=comments&id=" + container.InternalId + "&perPage=100&page=1");
            container.UsersComents = new OzonComentsList();
            container.UsersComents.Parse(comentsBlock.PageText);

            // container.PictureLink = _document.DocumentNode.SelectNodes("//div[@class=\"eMicroGallery_full\"]")[0].InnerText;
            // container.FileFormat = 

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
            var nodes = this.document.DocumentNode.SelectNodes(query);
            return nodes.Count == 0 ? string.Empty : nodes[0].InnerText;
        }
    }
}