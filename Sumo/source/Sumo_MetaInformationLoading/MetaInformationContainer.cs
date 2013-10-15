using System.Collections.Generic;

namespace Sumo_MetaInformationLoading
{
    using Sumo_MetaInformationLoading.Ozon;

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
        public List<string> ISBN { get; set; }

        /// <summary>
        /// Получает язык, на котором написана книга.
        /// </summary>
        public string Languages { get; set; }

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
        public OzonChainCategories Сategories { get; set; }

        /// <summary>
        /// Получает аннотацию к книге.
        /// </summary>
        public string Annotation { get; set; }

        /// <summary>
        /// Получает коментарии пользователей на книгу.
        /// </summary>
        public OzonComentsList UsersComents { get; set; }
    }
}
