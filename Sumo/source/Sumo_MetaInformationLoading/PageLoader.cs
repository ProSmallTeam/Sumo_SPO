namespace Sumo_MetaInformationLoading
{
    using System.IO;
    using System.Net;
    using System.Text;

    /// <summary>
    /// Класс, отвечающий за загрузку метаинформации о книге.
    /// </summary>
    internal static class PageLoader
    {
        /// <summary>
        /// Метод загрузки текста страници по конкретному url.
        /// </summary>
        /// <param name="absoluteUrl">
        /// Url страници.
        /// </param>
        /// <returns>
        /// Текст загруженной страници.
        /// </returns>
        public static Page LoadFromUrl(string absoluteUrl)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(absoluteUrl);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
             
            Stream stream = resp.GetResponseStream();

            return new Page(resp.ResponseUri.AbsoluteUri, TextOfPageReader(stream));
        }

        /// <summary>
        /// Метод считывания текста страници из потока.
        /// </summary>
        /// <param name="stream">
        /// Поток для считывания.
        /// </param>
        /// <returns>
        /// Текст загруженной страници.
        /// </returns>
        private static string TextOfPageReader(Stream stream)
        {
            StreamReader reader = new StreamReader(stream, Encoding.Default);
            return reader.ReadToEnd();
        }
    }
}
