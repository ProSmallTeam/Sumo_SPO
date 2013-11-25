namespace MetaLoaderLib
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
        /// Метод загрузки текста страницы по конкретному url.
        /// </summary>
        /// <param name="url">
        /// Url страницы.
        /// </param>
        /// <returns>
        /// Текст загруженной страницы.
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
        /// Метод считывания текста страницы из потока.
        /// </summary>
        /// <param name="stream">
        /// Поток для считывания.
        /// </param>
        /// <param name="encoding">
        /// Кодировка страницы.
        /// </param>
        /// <returns>
        /// Текст загруженной страницы.
        /// </returns>
        private static string ReadTextFromStream(Stream stream, Encoding encoding)
        {
            var reader = new StreamReader(stream, encoding);
            return reader.ReadToEnd();
        }
    }
}
