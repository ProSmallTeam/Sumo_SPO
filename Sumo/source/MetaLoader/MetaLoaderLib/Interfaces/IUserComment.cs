namespace MetaLoaderLib.Interfaces
{
    using System;

    /// <summary>
    /// Комментарий пользователя.
    /// </summary>
    public interface IUserComment
    {
        /// <summary>
        /// Получает заголовок комментария.
        /// </summary>
        string CommentTitle { get; set; }

        /// <summary>
        /// Получает текст комментария пользователя.
        /// </summary>
        string CommentText { get; set; }

        /// <summary>
        /// Получает дату и время, в которую был оставлен комментарий.
        /// </summary>
        DateTime CommentDate { get; set; }

        /// <summary>
        /// Получает имя пользователя, оставившего комментарий.
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// Получает оценку, которую поставил пользователь.
        /// </summary>
        byte UserMark { get; set; }

        /// <summary>
        /// Метод для парсинга комментария из html текста, содержащего блок с комментарием.
        /// </summary>
        /// <param name="commentHtmlText">
        /// Html текст, содержащий блок с комментарием.
        /// </param>
        void Parse(string commentHtmlText);
    }
}
