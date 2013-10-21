using System.Collections.Generic;
using System.Linq;

namespace Sumo_MetaInformationLoading.Ozon
{
    using System;

    using HtmlAgilityPack;

    /// <summary>
    /// Класс для парсинга страници с книгой, загруженной с сайта Ozon.ru
    /// </summary>
    public static class LabirintPageParser
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
            Page parsedPage = PageLoader.LoadFromUrl("http://www.labirint.ru/search/" + isbn + "/");
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(parsedPage.TextOfPage);

            // Заводим контейнер для сохранения информации
            var container = new MetaInformationContainer();

            // Вытаскиваем метаинформацию
            container.Link = parsedPage.AbsoluteUrl;
            container.PublishHouse = document.DocumentNode.SelectNodes("//div[@class=\"publisher\"]/a")[0].InnerText;
            container.Annotation = document.DocumentNode.SelectNodes("//div[@id=\"product-about\"]/p/noindex")[0].InnerText;
            container.InternalId = document.DocumentNode.SelectNodes("//div[@class=\"articul\"]/p[1]")[0].InnerText.Substring("ID товар: ".Length);

            string title = document.DocumentNode.SelectNodes("//div[@id=\"product-title\"]/h1")[0].InnerText;
            string[] Title = title.Split(new char[] {':'});
            container.Author = Title[0];
            container.RuTitle = Title[1];

            // Вытаскиваем ISBN и год издания
            
            //container.ISBN = document.DocumentNode.SelectNodes("//div[@class=\"isbn\"]"); ????????????????????????

            string year = document.DocumentNode.SelectNodes("//div[@class=\"publisher\"]")[2].InnerText;
            string[] Year = year.Split(new char[] {' '});
            container.PublishYear = Year[1];

            // Вытаскиваем количество страниц в книге
            string page = document.DocumentNode.SelectNodes("//div[@class=\"pages2\"]")[0].InnerText;
            string[] Page = page.Split(new char[] {' '});
            container.PageCount = Convert.ToInt32(Page[1].Substring(0, Page[1].Length - 5)); 

            // Возвращаем контейнер
            return container;
        }
    }
}