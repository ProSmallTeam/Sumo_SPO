namespace Sumo_MetaInformationLoading.Labirint
{
    using System;

    using HtmlAgilityPack;

    /// <summary>
    /// Коментарий пользователя с сайта Ozon.ru.
    /// </summary>
    public class LabirintUserComent
    {
        
        /// <summary>
        /// Получает текст коментария пользователя.
        /// </summary>
        public string ComentText { get; internal set; }

        /// <summary>
        /// Получает дату и время, в которую был оставлен коментарий.
        /// </summary>
        public DateTime ComentDate { get; internal set; }

        /// <summary>
        /// Получает имя пользователя, оставившего коментарий.
        /// </summary>
        public string UserName { get; internal set; }

        /// <summary>
        /// Получает оценку, которую поставил пользователь.
        /// </summary>
        public byte UserMark { get; internal set; }

        /// <summary>
        /// Метод для парсинга коментария из html текста, содержащего блок с коментарием.
        /// </summary>
        /// <param name="comentHtmlText">
        /// Html текст, содержащий блок с коментарием.
        /// </param>
        internal void Parse(string comentHtmlText)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(comentHtmlText);

            this.UserName = document.DocumentNode.SelectNodes("//div[@class=\"uzer-name\"]")[0].InnerText;
            this.ComentDate = DateTime.Parse(document.DocumentNode.SelectNodes("//div[@class=\"comment-footer\"]/div[@class=\"date\"]")[0].InnerText);
            this.ComentText = document.DocumentNode.SelectNodes("//div[@class=\"comment-text\"]/div/p")[0].InnerText;
            this.UserMark = Convert.ToByte(document.DocumentNode.SelectNodes("//div[@class=\"form-inp\"]")[1].InnerText);

        }
    }
}

