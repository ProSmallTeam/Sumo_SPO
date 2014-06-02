using HtmlAgilityPack;

namespace Sumo.Api.Network
{
    /// <summary>
    /// Класс html страницы.
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Инициализарует класс html страницы.
        /// </summary>
        public Page()
        {
            this.Url = null;
            this.Document = null;
        }

        /// <summary>
        /// Инициализарует класс html страницы.
        /// </summary>
        /// <param name="documentUrl">
        /// Полный documentUrl страницы.
        /// </param>
        /// <param name="htmlDocument">
        /// The html Document.
        /// </param>
        public Page(string documentUrl, HtmlDocument htmlDocument)
        {
            Url = documentUrl;
            Document = htmlDocument;
        }

        /// <summary>
        /// Получает полный Url страницы.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Получает текст страницы.
        /// </summary>
        public HtmlDocument Document { get; set; }
    }
}
