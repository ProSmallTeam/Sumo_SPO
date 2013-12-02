namespace MetaLoaderLib.Ozon
{
    using System;

    using HtmlAgilityPack;

    using MetaLoaderLib.Interfaces;

    /// <summary>
    /// Комментарий пользователя с сайта Ozon.ru.
    /// </summary>
    internal class OzonUserComment : IUserComment
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

            this.CommentTitle = document.DocumentNode.SelectNodes("//strong[@itemprop=\"name\"]")[0].InnerText;
            this.CommentDate = DateTime.Parse(document.DocumentNode.SelectNodes("//span[@itemprop=\"datePublished\"]")[0].InnerText);
            this.UserName = document.DocumentNode.SelectNodes("//div[@class=\"content\"]/p[@class=\"misc\"]")[0].NextSibling.InnerText;
            this.CommentText = document.DocumentNode.SelectNodes("//p[@itemprop=\"description\"]")[0].InnerText;
            this.UserMark = Convert.ToByte(document.DocumentNode.SelectNodes("//meta[@itemprop=\"ratingValue\"]")[0].Attributes["content"].Value);
        }
    }
}
