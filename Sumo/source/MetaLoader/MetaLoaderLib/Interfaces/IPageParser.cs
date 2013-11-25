namespace MetaLoaderLib.Interfaces
{
    using MetaLoaderLib;

    /// <summary>
    /// Интерфейс парсера страницы.
    /// </summary>
    public interface IPageParser
    {
        /// <summary>
        /// Метод для паринга страницы.
        /// </summary>
        /// <param name="isbn">
        /// ISBN книги для парсинга.
        /// </param>
        /// <returns>
        /// Найденная информация по книге.
        /// </returns>
        MetaInformationContainer Parse(string isbn);
    }
}
