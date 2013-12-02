namespace MetaLoaderLib.Labirint
{
    using System.Collections.Generic;

    using HtmlAgilityPack;

    using MetaLoaderLib.Interfaces;

    /// <summary>
    /// Класс, осуществляющий хранение комментариев пользователей с сайта Labirint.ru.
    /// </summary>
    public class LabirintCommentsList : ICommentsList
    {
        /// <summary>
        /// Список комментариев, оставленых пользователями.
        /// </summary>
        private readonly List<IUserComment> comments = new List<IUserComment>();

        /// <summary>
        /// Метод для парсинга комментариев из html текста, содержащего блок со всеми комментариями.
        /// </summary>
        /// <param name="commentListHtmlText">
        /// Html текст, содержащий блок со всеми комментариями.
        /// </param>
        public void Parse(string commentListHtmlText)
        {
            var document = new HtmlDocument();
            document.LoadHtml(commentListHtmlText);

            var blockOfcomments = document.DocumentNode.SelectNodes("//div[@class=\"item\"]");

            foreach (var commentBlock in blockOfcomments)
            {
                var userComment = new LabirintUserComment();
                userComment.Parse(commentBlock.InnerHtml);

                this.comments.Add(userComment);
            }
        }
    }
}
