namespace MetaLoaderLib
{
    /// <summary>
    /// Класс информации о сайте.
    /// </summary>
    public class SiteInfo
    {
        /// <summary>
        /// Инициализирует класс информации о сайте
        /// </summary>
        /// <param name="title">
        /// Заголовок сайта.
        /// </param>
        private SiteInfo(string title)
        {
            this.Title = title;
        }

        /// <summary>
        /// Получает или задает заголовок сайта.
        /// </summary>
        public string Title { get; set; }   
    }
}
