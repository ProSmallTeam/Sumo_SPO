namespace Sumo_MetaInformationLoading
{
    /// <summary>
    /// Контейнер хранения метаинформации.
    /// </summary>
    public class MetaInformationContainer
    {
        /// <summary>
        /// Получает ссылку на книгу.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Получает ссылку на обложку книги.
        /// </summary>
        public string PictureLink { get; set; }

        /// <summary>
        /// Получает название книги.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Получает формат файла книги.
        /// </summary>
        public string FileFormat { get; private set; }

        /// <summary>
        /// Получает автора книги.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Получает внутренний ID книги на сайте.
        /// </summary>
        public string InternalId { get; set; }

        /// <summary>
        /// Получает ISBN книги.
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Получает язык, на котором написана книга.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Получает издателя.
        /// </summary>
        public string PublishHouse { get; set; }

        /// <summary>
        /// Получает год издания книги.
        /// </summary>
        public string PublishYear { get; private set; }

        /// <summary>
        /// Получает количество страниц в книге.
        /// </summary>
        public string PageCount { get; set; }

        /// <summary>
        /// Получает категорию.
        /// </summary>
        public string Сategory { get; set; }

        /// <summary>
        /// Получает аннотацию к книге.
        /// </summary>
        public string Annotation { get; set; }

        /// <summary>
        /// Получает коментарии пользователей на книгу.
        /// </summary>
        public string[] UsersComents { get; private set; }
    }
}
