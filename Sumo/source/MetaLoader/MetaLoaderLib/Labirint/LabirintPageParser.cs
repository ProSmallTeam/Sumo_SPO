namespace MetaLoaderLib.Labirint
{
    using System;

    using HtmlAgilityPack;

    using MetaLoaderLib;
    using MetaLoaderLib.Interfaces;

    /// <summary>
    /// Класс для парсинга страници с книгой, загруженной с сайта Ozon.ru
    /// </summary>
    public class LabirintPageParser : IPageParser
    {

        public LabirintPageParser(HtmlDocument document, string url)
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
        /// <summary>
        /// Метод для парсинга страници.
        /// </summary>
        /// <param name="isbn">
        /// ISBN книги.
        /// </param>
        /// <returns>
        /// Контейнер с информацией о книге.
        /// </returns>
        public MetaInformationContainer Parse(string isbn)
        {
            // Загрузка страници
            var page = PageLoader.LoadFromUrl("http://www.labirint.ru/search/" + isbn + "/");

            var document = new HtmlDocument();
            document.LoadHtml(page.PageText);
            this.Document = document;

            var metaContainer = this.Parse();
            //this.UploadComents(metaContainer);

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
            container.PublishHouse = this.Get("//div[@class=\"publisher\"]/a");
            container.Annotation = this.Get("//div[@id=\"product-about\"]/div/div/p");
            container.InternalId = this.Get("//div[@class=\"articul\"]").Substring("ID товара: ".Length);

            string title = this.Get("//div[@id=\"product-title\"]/h1");
            string[] Title = title.Split(new char[] { ':' });
            container.Author = Title[0];
            container.RuTitle = Title[1].Remove(0, 1);

            // Вытаскиваем ISBN и год издания

            //????????????????????????

            string year = this.Get("//div[@class=\"publisher\"]");
            string[] Year = year.Split(new char[] { ' ' });
            container.PublishYear = Year[2];

            // Вытаскиваем количество страниц в книге
            string page = this.Get("//div[@class=\"pages2\"]");
            string[] Page = page.Split(new char[] { ' ' });
            container.PageCount = Convert.ToInt32(Page[1]);

            // Вытаскиваем цепочку категорий
            //????????????????????????????????


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
/*
        /// <summary>
        /// Подгружаем коментарии пользователей.
        /// </summary>
        /// <param name="metaContainer">
        /// Контейнер для сохранения коментариев пользователей.
        /// </param>
        private void UploadComents(MetaInformationContainer metaContainer)
        {
            var comentsBlock =
                PageLoader.LoadFromUrl(
                    "http://www.ozon.ru/DetailLoader.aspx?module=comments&id=" + metaContainer.InternalId // нужна ссылка для коментов
                    + "&perPage=1&page=1000");
            metaContainer.UsersComentsForLabirint = new LabirintComentsList();
            metaContainer.UsersComentsForLabirint.Parse(comentsBlock.PageText);
        }*/
    }
}