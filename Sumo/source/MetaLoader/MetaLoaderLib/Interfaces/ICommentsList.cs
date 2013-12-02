namespace MetaLoaderLib.Interfaces
{
    /// <summary>
    /// The commentsList interface.
    /// </summary>
    public interface ICommentsList
    {
        /// <summary>
        ///  Метод для парсинга комментариев из html текста, содержащего блок со всеми комментариями.
        ///  </summary>
        /// <param name="commentListHtmlText">
        ///  Html текст, содержащий блок со всеми комментариями.
        /// </param>
        void Parse(string commentListHtmlText);
    }
}
