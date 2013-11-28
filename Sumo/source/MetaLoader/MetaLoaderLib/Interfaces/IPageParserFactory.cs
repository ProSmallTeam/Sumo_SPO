namespace MetaLoaderLib.Interfaces
{
    /// <summary>
    /// Интерфейс фабрики парсеров.
    /// </summary>
    public interface IPageParserFactory
    {
        /// <summary>
        /// Метод для получения парсера страницы.
        /// </summary>
        /// <returns>
        /// Парсер страницы.
        /// </returns>
        IPageParser GetPageParserObject();
    }
}
