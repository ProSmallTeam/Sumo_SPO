namespace Sumo_MetaInformationLoading.Labirint
{
    using System.Collections.Generic;

    using HtmlAgilityPack;

    /// <summary>
    /// Класс, осуществляющий хранение коментариев пользователей с сайта Labirint.ru.
    /// </summary>
    public class LabirintComentsList
    {
        /// <summary>
        /// Список коментариев, оставленых пользователями.
        /// </summary>
        private readonly List<LabirintUserComent> _coments = new List<LabirintUserComent>();

        /// <summary>
        /// Метод для парсинга коментариев из html текста, содержащего блок со всеми коментариями.
        /// </summary>
        /// <param name="comentListHtmlText">
        /// Html текст, содержащий блок со всеми коментариями.
        /// </param>
        public void Parse(string comentListHtmlText)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(comentListHtmlText);

            var blockOfComents = document.DocumentNode.SelectNodes("//div[@class=\"item\"]");

            foreach (var comentBlock in blockOfComents)
            {
                LabirintUserComent userComent = new LabirintUserComent();
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
        internal void Add(LabirintUserComent coment)
        {
            this._coments.Add(coment);
        }
    }
}
