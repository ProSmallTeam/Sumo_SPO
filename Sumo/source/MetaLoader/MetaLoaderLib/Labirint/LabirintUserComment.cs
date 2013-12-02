namespace MetaLoaderLib.Labirint
{
    using System;

    using HtmlAgilityPack;

    using MetaLoaderLib.Interfaces;

    /// <summary>
    /// Комментарий пользователя с сайта Labirint.ru.
    /// </summary>
    internal class LabirintUserComment : IUserComment
    {
        /// <summary>
        /// Получает заголовок комментария.
        /// </summary>
        public string CommentTitle { get; set; }

        /// <summary>
        /// Получает текст комментария пользователя.
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// Получает дату и время, в которую был оставлен комментарий.
        /// </summary>
        public DateTime CommentDate { get; set; }

        /// <summary>
        /// Получает имя пользователя, оставившего комментарий.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Получает оценку, которую поставил пользователь.
        /// </summary>
        public byte UserMark { get; set; }

        /// <summary>
        /// Метод для парсинга комментария из html текста, содержащего блок с комментарием.
        /// </summary>
        /// <param name="commentHtmlText">
        /// Html текст, содержащий блок с комментарием.
        /// </param>
        public void Parse(string commentHtmlText)
        {
            var document = new HtmlDocument();
            document.LoadHtml(commentHtmlText);
            
            // Изменил парсинг комментов
            this.UserName = document.DocumentNode.SelectNodes("//div[@class=\"uzer-name\"]/a")[0].InnerText;
            
            string date = document.DocumentNode.SelectNodes("//div[@class=\"date\"]")[0].InnerText;
            string[] Date = date.Split(new char[] { ' ' });
            
            this.CommentDate = DateTime.Parse(Date[0]);

            this.CommentText = document.DocumentNode.SelectNodes("//div[@class=\"comment-text\"]/div/p")[0].InnerText;
            this.UserMark = Convert.ToByte(document.DocumentNode.SelectNodes("//div[@class=\"form-inp\"]")[1].InnerText);

        }
    }
}

