namespace MetaLoaderLib
{
    using System.Collections.Generic;

    using MetaLoaderLib.Interfaces;

    /// <summary>
    /// Фабрика для генерации парсеров.
    /// </summary>
    public class PageParserFactory : IPageParserFactory
    {
        /// <summary>
        /// Сгенерированные парсеры для сайтов.
        /// </summary>
        private static readonly Dictionary<string, IPageParser> PageParsersObjects = new Dictionary<string, IPageParser>();

        /// <summary>
        /// Инициализирует новую фабрику для генерации парсеров.
        /// </summary>
        /// <param name="sourceSiteInfo">
        /// Информация о сайте, с которого берутся страницы для парсинга.
        /// </param>
        public PageParserFactory(SiteInfo sourceSiteInfo)
        {
            this.SourceSiteInfo = sourceSiteInfo;
        }

        /// <summary>
        /// Получает или задает информацию о сайте.
        /// </summary>
        private SiteInfo SourceSiteInfo { get; set; }

        /// <summary>
        /// Метод для получения парсера.
        /// </summary>
        /// <returns>
        /// Парсер страницы.
        /// </returns>
        public IPageParser GetPageParserObject()
        {
            return PageParsersObjects[this.SourceSiteInfo.Title];
        }
    }
}
