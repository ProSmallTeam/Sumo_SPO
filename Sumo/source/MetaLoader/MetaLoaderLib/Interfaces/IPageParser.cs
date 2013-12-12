namespace MetaLoaderLib.Interfaces
{
    using MetaLoaderLib;

    /// <summary>
    /// Интерфейс для работыс парсером.
    /// </summary>
    public interface IPageParser
    {
        /// <summary>
        /// Метод для парсинга страницы.
        /// </summary>
        /// <param name="isbn">
        /// ISBN книги.
        /// </param>
        /// <returns>
        /// Контейнер с информацией о книге.
        /// </returns>
        Book Parse(string isbn);
    }
}
