namespace MetaLoader
{
    /// <summary>
    /// Класс html страницы.
    /// </summary>
    internal class Page
    {
        /// <summary>
        /// Инициализарует класс html страницы.
        /// </summary>
        public Page()
        {
            Url = null;
            PageText = null;
        }

        /// <summary>
        /// Инициализарует класс html страницы.
        /// </summary>
        /// <param name="url">
        /// Полный url страницы.
        /// </param>
        /// <param name="pageText">
        /// Текст страницы.
        /// </param>
        internal Page(string url, string pageText)
        {
            Url = url;
            PageText = pageText;
        }

        /// <summary>
        /// Получает полный Url страницы.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Получает текст страницы.
        /// </summary>
        public string PageText { get; private set; }
    }
}
