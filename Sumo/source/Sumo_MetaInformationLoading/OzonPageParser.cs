namespace Sumo_MetaInformationLoading
{
    using HtmlAgilityPack;

    /// <summary>
    /// Класс для парсинга страници с книгой, загруженной с сайта Ozon.ru
    /// </summary>
    public static class OzonPageParser
    {
        /// <summary>
        /// Метод для парсинга страници.
        /// </summary>
        /// <param name="isbn">
        /// ISBN книги.
        /// </param>
        /// <returns>
        /// Контейнер с информацией.
        /// </returns>
        public static MetaInformationContainer Parse(string isbn)
        {
            Page parsedPage = PageLoader.LoadPageFromUrl("http://www.ozon.ru/?context=search&text=" + isbn + "&group=div_book");

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(parsedPage.TextOfPage);

            MetaInformationContainer container = new MetaInformationContainer();

            // Проблемы в закоменченном тексте
            container.Title = document.DocumentNode.SelectNodes("//h1[@itemprop=\"name\"]")[0].InnerText;
            container.Link = parsedPage.Url;

            // container.PictureLink = document.DocumentNode.SelectNodes("//div[@class=\"eMicroGallery_full\"]")[0].InnerText;
            container.ISBN = document.DocumentNode.SelectNodes("//p[@itemprop=\"isbn\"]")[0].InnerText;
            container.InternalId = document.DocumentNode.SelectNodes("//p[@class=\"idItems\"]")[0].InnerText;
            container.Author = document.DocumentNode.SelectNodes("//p[@itemprop=\"author\"]/a")[0].InnerText;

            // container.PublishYear = В ISBN
            // container.UsersComents = 
            container.PageCount = document.DocumentNode.SelectNodes("//span[@itemprop=\"numberOfPages\"]")[0].InnerText;
            container.Сategory = document.DocumentNode.SelectNodes("//li[@class=\" prevLast\"]/a")[0].InnerText;
            container.Annotation = document.DocumentNode.SelectNodes("//div[@class=\"detail_description js_scrolload js-tab-descr \"]")[0].InnerText;
            container.PublishHouse = document.DocumentNode.SelectNodes("//p[@itemprop=\"publisher\"]/a")[0].InnerText;
            container.Language = document.DocumentNode.SelectNodes("//p[@itemprop=\"inLanguage\"]")[0].InnerText;

            // container.FileFormat = 
            return container;
        }
    }
}