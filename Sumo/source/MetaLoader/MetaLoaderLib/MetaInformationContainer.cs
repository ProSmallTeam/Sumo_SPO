namespace MetaLoaderLib
{
    using System.Collections.Generic;

    using MetaLoaderLib.Interfaces;

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
        /// Получает название книги на английском.
        /// </summary>
        public string EnTitle { get; set; }

        /// <summary>
        /// Получает название книги на русском.
        /// </summary>
        public string RuTitle { get; set; }

        /// <summary>
        /// Получает формат файла книги.
        /// </summary>
        public string FileFormat { get; set; }

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
        public List<string> ISBN { get; set; }

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
        public string PublishYear { get; set; }

        /// <summary>
        /// Получает количество страниц в книге.
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Получает категорию.
        /// </summary>
        public IChainCategories Сategories { get; set; }

        /// <summary>
        /// Получает аннотацию к книге.
        /// </summary>
        public string Annotation { get; set; }

        /// <summary>
        /// Получает комментарии пользователей на книгу.
        /// </summary>
        public ICommentsList UsersComments { get; set; }
    }
}
