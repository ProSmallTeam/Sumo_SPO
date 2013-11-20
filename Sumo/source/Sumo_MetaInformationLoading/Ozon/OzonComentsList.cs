namespace MetaLoader.Ozon
{
    using System.Collections.Generic;

    using HtmlAgilityPack;

    /// <summary>
    /// Класс, осуществляющий хранение коментариев пользователей с сайта Ozon.ru.
    /// </summary>
    public class OzonComentsList
    {
        /// <summary>
        /// Список коментариев, оставленых пользователями.
        /// </summary>
        private readonly List<OzonUserComent> coments = new List<OzonUserComent>();

        /// <summary>
        /// Метод для парсинга коментариев из html текста, содержащего блок со всеми коментариями.
        /// </summary>
        /// <param name="comentListHtmlText">
        /// Html текст, содержащий блок со всеми коментариями.
        /// </param>
        public void Parse(string comentListHtmlText)
        {
            var document = new HtmlDocument();
            document.LoadHtml(comentListHtmlText);

            var blockOfComents = document.DocumentNode.SelectNodes("//div[@class=\"item\"]");

            foreach (var comentBlock in blockOfComents)
            {
                var userComent = new OzonUserComent();
                userComent.Parse(comentBlock.InnerHtml);

                this.Add(userComent);
            }
        }

        /// <summary>
        /// Метод добавления коментария в список коментариев.
        /// </summary>
        /// <param name="coment">
        /// коментарий пользователя с Ozon.ru.
        /// </param>
        internal void Add(OzonUserComent coment)
        {
            this.coments.Add(coment);
        }
    }
}
