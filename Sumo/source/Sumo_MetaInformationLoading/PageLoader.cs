namespace MetaInformationLoader
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
        /// <param name="url">
        /// Url страници.
        /// </param>
        /// <returns>
        /// Текст загруженной страници.
        /// </returns>
        public static Page LoadFromUrl(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var encoding = response.CharacterSet != null ? Encoding.GetEncoding(response.CharacterSet) : Encoding.UTF8;

                using (var stream = response.GetResponseStream())
                    return new Page(response.ResponseUri.AbsoluteUri, ReadTextFromStream(stream, encoding));
            }
        }

        /// <summary>
        /// Метод считывания текста страници из потока.
        /// </summary>
        /// <param name="stream">
        ///     Поток для считывания.
        /// </param>
        /// <param name="encoding"></param>
        /// <returns>
        /// Текст загруженной страници.
        /// </returns>
        private static string ReadTextFromStream(Stream stream, Encoding encoding)
        {
            var reader = new StreamReader(stream, encoding);
            return reader.ReadToEnd();
        }
    }
}
