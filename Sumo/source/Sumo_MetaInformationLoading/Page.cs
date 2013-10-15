namespace Sumo_MetaInformationLoading
{
    /// <summary>
    /// Класс html страници.
    /// </summary>
    internal class Page
    {
        /// <summary>
        /// Инициализарует класс html страници.
        /// </summary>
        public Page()
        {
            this.AbsoluteUrl = null;
            this.TextOfPage = null;
        }

        /// <summary>
        /// Инициализарует класс html страници.
        /// </summary>
        /// <param name="absoluteUrl">
        /// Полный url страници.
        /// </param>
        /// <param name="textOfPageLoader">
        /// Текст страници.
        /// </param>
        internal Page(string absoluteUrl, string textOfPageLoader)
        {
            this.AbsoluteUrl = absoluteUrl;
            this.TextOfPage = textOfPageLoader;
        }

        /// <summary>
        /// Получает полный Url страници.
        /// </summary>
        public string AbsoluteUrl { get; private set; }

        /// <summary>
        /// Получает текст страници.
        /// </summary>
        public string TextOfPage { get; private set; }
    }
}
