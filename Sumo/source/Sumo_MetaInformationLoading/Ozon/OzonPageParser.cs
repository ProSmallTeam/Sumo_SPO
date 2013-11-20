using System.Linq;

namespace MetaInformationLoader.Ozon
{
    using System;

    using HtmlAgilityPack;

    /// <summary>
    /// Класс для парсинга страници с книгой, загруженной с сайта Ozon.ru
    /// </summary>
    public class OzonPageParser
    {
        private readonly string _url;

        private readonly HtmlDocument _document;

        private OzonPageParser(HtmlDocument document, string url)
        {
            _document = document;
            _url = url;
        }

        private MetaInformationContainer Parse()
        {
            // Заводим контейнер для сохранения информации
            var container = new MetaInformationContainer();

            // Вытаскиваем метаинформацию
            container.Link = _url;
            container.EnTitle = Get("//div[@class='product-detail']/p[2]");
            container.RuTitle = Get("//h1[@itemprop='name']");
            container.InternalId = Get("//div[@class='product-detail']/p[1]").Remove(0, "ID ".Length);
            container.Author = Get("//p[@itemprop='author']/a");
            container.Annotation = Get("//div[@id='detail_description']/table/tr/td");
            container.PublishHouse = Get("//p[@itemprop='publisher']/a");
            container.Languages = Get("//p[@itemprop='inLanguage']").Remove(0, "Языки: ".Length);

            // Вытаскиваем ISBN и год издания
            var publishYearAndIsbn = Get("//p[@itemprop='isbn']").Substring("ISBN ".Length);
            container.ISBN = publishYearAndIsbn.Substring(0, publishYearAndIsbn.Length - "; 2013 г.".Length).Split(new char[] { ',', ' ' }).ToList();
            container.ISBN.RemoveAll(_isbn => _isbn == "");
            container.PublishYear = publishYearAndIsbn.Substring(publishYearAndIsbn.Length - "0000 г.".Length, 4);

            // Вытаскиваем количество страниц в книге
            var pageCountInText = Get("//span[@itemprop='numberOfPages']");
            container.PageCount = Convert.ToInt32(pageCountInText.Substring(0, pageCountInText.Length - 5));

            // Вытаскиваем цепочку категорий
            container.Сategories = OzonChainCategories.Parse(_document.DocumentNode.SelectNodes("//ul[@class=\"navLine\"]")[0].InnerHtml);

            // Вытаскиваем коментарии пользователей
            Page comentsBlock = PageLoader.LoadFromUrl("http://www.ozon.ru/DetailLoader.aspx?module=comments&id=4473201&sort=&perPage=100&page=1&modelId=4473201");
            container.UsersComents = new OzonComentsList();
            container.UsersComents.Parse(comentsBlock.PageText);

            // container.PictureLink = _document.DocumentNode.SelectNodes("//div[@class=\"eMicroGallery_full\"]")[0].InnerText;
            // container.FileFormat = 

            // Возвращаем контейнер
            return container;            
        }

        private string Get(string query)
        {
            var nodes = _document.DocumentNode.SelectNodes(query);
            return nodes.Count == 0 ? string.Empty : nodes[0].InnerText;
        }

        /// <summary>
        /// Метод для парсинга страници.
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
    }
}