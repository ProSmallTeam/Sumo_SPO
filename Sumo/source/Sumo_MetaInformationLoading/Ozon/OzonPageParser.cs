using System.Collections.Generic;
using System.Linq;

namespace Sumo_MetaInformationLoading.Ozon
{
    using System;

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
        /// Контейнер с информацией о книге.
        /// </returns>
        public static MetaInformationContainer Parse(string isbn)
        {
            // Загрузка страници
            Page parsedPage = PageLoader.LoadFromUrl("http://www.ozon.ru/?context=search&text=" + isbn + "&group=div_book");
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(parsedPage.TextOfPage);

            // Заводим контейнер для сохранения информации
            MetaInformationContainer container = new MetaInformationContainer();

            // Вытаскиваем метаинформацию
            container.Link = parsedPage.AbsoluteUrl;
            container.EnTitle = document.DocumentNode.SelectNodes("//div[@class=\"product-detail\"]/p[2]")[0].InnerText;
            container.RuTitle = document.DocumentNode.SelectNodes("//h1[@itemprop=\"name\"]")[0].InnerText;
            container.InternalId = document.DocumentNode.SelectNodes("//div[@class=\"product-detail\"]/p[1]")[0].InnerText.Remove(0, "ID ".Length);
            container.Author = document.DocumentNode.SelectNodes("//p[@itemprop=\"author\"]/a")[0].InnerText;
            container.Annotation = document.DocumentNode.SelectNodes("//div[@id=\"detail_description\"]/table/tr/td")[0].InnerText;
            container.PublishHouse = document.DocumentNode.SelectNodes("//p[@itemprop=\"publisher\"]/a")[0].InnerText;
            container.Languages = document.DocumentNode.SelectNodes("//p[@itemprop=\"inLanguage\"]")[0].InnerText.Remove(0, "Языки: ".Length);

            // Вытаскиваем ISBN и год издания
            var publishYearAndIsbn = document.DocumentNode.SelectNodes("//p[@itemprop=\"isbn\"]")[0].InnerText.Substring("ISBN ".Length);
            container.ISBN = publishYearAndIsbn.Substring(0, publishYearAndIsbn.Length - "; 2013 г.".Length).Split(new char[] {',', ' '}).ToList();
            container.ISBN.RemoveAll(_isbn => _isbn == "");
            container.PublishYear = publishYearAndIsbn.Substring(publishYearAndIsbn.Length - "0000 г.".Length, 4);
            
            // Вытаскиваем количество страниц в книге
            var pageCountInText = document.DocumentNode.SelectNodes("//span[@itemprop=\"numberOfPages\"]")[0].InnerText;
            container.PageCount = Convert.ToInt32(pageCountInText.Substring(0, pageCountInText.Length - 5));

            // Вытаскиваем цепочку категорий
            container.Сategories = OzonChainCategories.Parse(document.DocumentNode.SelectNodes("//ul[@class=\"navLine\"]")[0].InnerHtml);

            // Вытаскиваем коментарии пользователей
            Page comentsBlock = PageLoader.LoadFromUrl("http://www.ozon.ru/DetailLoader.aspx?module=comments&id=4473201&sort=&perPage=100&page=1&modelId=4473201");
            container.UsersComents = new OzonComentsList();
            container.UsersComents.Parse(comentsBlock.TextOfPage);

            // container.PictureLink = document.DocumentNode.SelectNodes("//div[@class=\"eMicroGallery_full\"]")[0].InnerText;
            // container.FileFormat = 

            // Возвращаем контейнер
            return container;
        }
    }
}