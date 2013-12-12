namespace Network
{
    using System.IO;
    using System.Net;
    using System.Text;

    using HtmlAgilityPack;

    using Network.Interfaces;

    /// <summary>
    /// The http network.
    /// </summary>
    public class HttpNetwork : INetwork
    {
        /// <summary>
        /// The load document.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <returns>
        /// The <see cref="HtmlDocument"/>.
        /// </returns>
        public Page LoadDocument(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var encoding = response.CharacterSet != null ? Encoding.GetEncoding(response.CharacterSet) : Encoding.UTF8;

                var document = new HtmlDocument();

                using (var stream = response.GetResponseStream())
                    document.LoadHtml(ReadTextFromStream(stream, encoding));

                return new Page(response.ResponseUri.AbsoluteUri, document);
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
