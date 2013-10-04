namespace Sumo_MetaInformationLoading
{
    using System.IO;
    using System.Net;

    /// <summary>
    /// Метод загрузки метаинформации.
    /// </summary>
    public enum LoadingMod
    {
        /// <summary>
        /// Загрузка метаинформации производится из html страници книги.
        /// </summary>
        FormFile,

        /// <summary>
        /// Загрузка метаинформации производится по конкретному url книги.
        /// </summary>
        FormUrl
    }

    /// <summary>
    /// Класс, отвечающий за загрузку метаинформации о книге по ссылке на страницу с книгой.
    /// </summary>
    public class MetaInformationLoading
    {
        /// <summary>
        /// Конструктор класса загрузки мета информации.
        /// </summary>
        /// <param name="path">
        /// Путь к источнику метаинформации.
        /// </param>
        /// <param name="loadingMod">
        /// Метод загрузки метаинформации.
        /// </param>
        public MetaInformationLoading(string path, LoadingMod loadingMod)
        {
            Stream stream;

            if (loadingMod == LoadingMod.FormFile)
            {
                stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            }
            else
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(path);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                stream = resp.GetResponseStream();
            }

            this.TextOfPage = this.LoadPageText(stream);
        }

        /// <summary>
        /// Получает текст загруженной страници.
        /// </summary>
        public string TextOfPage { get; private set; }

        /// <summary>
        /// Метод считывания страници из потока.
        /// </summary>
        /// <param name="stream">
        /// Поток для считывания.
        /// </param>
        /// <returns>
        /// текстовое представление считаной информации из потока.
        /// </returns>
        public string LoadPageText(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
