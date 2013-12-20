namespace Network
{
    using HtmlAgilityPack;

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
        internal Page(string documentUrl, HtmlDocument htmlDocument)
        {
            this.Url = documentUrl;
            this.Document = htmlDocument;
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
