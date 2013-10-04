namespace Sumo_MetaInformationLoading
{
    /// <summary>
    /// Контейнер хранения метаинформации.
    /// </summary>
    public class MetaInformationContainer
    {
        /// <summary>
        /// Название книги на русском.
        /// </summary>
        public string RuTitle { get; private set; }

        /// <summary>
        /// Название книги на английском языке.
        /// </summary>
        public string EnTitle { get; private set; }

        /// <summary>
        /// Получает автора книги.
        /// </summary>
        public string Author { get; private set; }

        /// <summary>
        /// Получает информацию о переводчике.
        /// </summary>
        public string Translator { get; private set; }

        /// <summary>
        /// Получает внутренний ID книги.
        /// </summary>
        public string InternalId { get; private set; }

        /// <summary>
        /// Получает ISBN книги.
        /// </summary>
        public string Isbn { get; private set; }

        /// <summary>
        /// Получает язык, на котором написана книга.
        /// </summary>
        public string Language { get; private set; }

        /// <summary>
        /// Gets the publish house.
        /// </summary>
        public string PublishHouse { get; private set; }

        /// <summary>
        /// Получает год издания книги.
        /// </summary>
        public string PublishYear { get; private set; }

        /// <summary>
        /// Получает количество страниц в книге.
        /// </summary>
        public string PageCount { get; private set; }

        /// <summary>
        /// Получает Формат книги.
        /// </summary>
        public string Format { get; private set; }

        /// <summary>
        /// Получает тираж книги.
        /// </summary>
        public string Edition { get; private set; }

        /// <summary>
        /// Получает категорию.
        /// </summary>
        public string Сategory { get; private set; }

        /// <summary>
        /// Получает серию книги.
        /// </summary>
        public string Series { get; private set; }

        /// <summary>
        /// Получает информацию о переплете книги.
        /// Надо ли нам его хранить?
        /// </summary>
        public string Binding { get; private set; }

        /// <summary>
        /// Получает аннотацию к книге.
        /// </summary>
        public string Annotation { get; private set; }

        /// <summary>
        /// Получает коментарии пользователей на книгу.
        /// </summary>
        public string[] UsersComents { get; private set; }
    }
}
