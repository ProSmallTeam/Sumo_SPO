namespace Sumo_MetaInformationLoading
{
    /// <summary>
    /// Класс html страници.
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Инициализарует класс html страници
        /// </summary>
        /// <param name="url">
        /// Url страници.
        /// </param>
        /// <param name="textOfPageLoader">
        /// Текст страници.
        /// </param>
        public Page(string url, string textOfPageLoader)
        {
            this.Url = url;
            this.TextOfPage = textOfPageLoader;
        }

        /// <summary>
        /// Получает Url страници.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Получает текст страници.
        /// </summary>
        public string TextOfPage { get; private set; }
    }
}
