namespace Sumo_MetaInformationLoading.Tests
{
    using System.Diagnostics;

    using NUnit.Framework;

    using Sumo_MetaInformationLoading.Ozon;

    //    using HtmlAgilityPack;

    /// <summary>
    /// Тестирование класса загрузки мета информации.
    /// </summary>
    [TestFixture]
    public class MetaInformationLoadingTests
    {
        [Test]
        public void LoadPageTextTest()
        {
            var a = OzonPageParser.Parse("978-5-91671-156-1");
            Trace.WriteLine(a.ToString());
            //            var htmlPage =
            //                new MetaInformationLoading("C:\\Users\\Vaigard\\Учеба\\sumo\\ozon.ru\\пример страници с книгой - Книга HTML5 для веб-дизайнеров - купить книжку html5 для веб-дизайнеров от Кит Джереми в книжном интернет магазине OZON.ru с доставкой по выгодной цене.htm", LoadingMod.FormFile);
            //            var doc = new HtmlDocument();
            //            doc.LoadHtml(htmlPage.TextOfPage);
            //
            //            var title = doc.DocumentNode.SelectNodes("//h1[@itemprop=\"name\"]");
            //            var author = doc.DocumentNode.SelectNodes("//p[@itemprop=\"author\"]/a");
            //            var language = doc.DocumentNode.SelectNodes("//p[@itemprop=\"inLanguage\"]");
            //            var publisher = doc.DocumentNode.SelectNodes("//p[@itemprop=\"publisher\"]/a");
            //            var isbn = doc.DocumentNode.SelectNodes("//p[@itemprop=\"isbn\"]");
            //            var pages = doc.DocumentNode.SelectNodes("//span[@itemprop=\"numberOfPages\"]");
            //            var category = doc.DocumentNode.SelectNodes("//li[@class=\"prevLast\"]/a");
            //            var annotation = doc.DocumentNode.SelectNodes("//div[@class=\"mDetail_SidePadding\"]/table/tbody/tr/td");
            //            var comments = doc.DocumentNode.SelectNodes("");
            //            var link = doc.DocumentNode.SelectNodes("");
            //            var linkImage = doc.DocumentNode.SelectNodes("");
            //
            //            Assert.AreEqual("Кит Джереми", author[0].InnerText);
        }
    }
}


/*
private void start()
        {
            my_delegate = new add_text(add_text_method);
            // В цикле обрабатываем странички с first_page по last_page (те, что указали в полях ввода)
            for (int i = this.first_page - 1; i &lt; this.last_page; i++)
            {
                string content = getRequest(tb_url.Text + this.param_separator + "p=" + i);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(content);
                // Получаем список ссылок на страницы с резюме
                HtmlNodeCollection c = doc.DocumentNode.SelectNodes("//a[@class='newtitle']");
                if (c != null)
                {
                    // Обрабатываем каждую страницу (парсим из нее выбранные данные)
                    foreach (HtmlNode n in c)
                    {
                        if (n.Attributes["href"] != null)
                        {
                            // Загружаем страничку с резюме
                            string u = main_url + n.Attributes["href"].Value;
                            string res_cn = getRequest(u);
                            // Парсим страничку с резюме
                            HtmlAgilityPack.HtmlDocument d = new HtmlAgilityPack.HtmlDocument();
                            d.LoadHtml(res_cn);
                            // Выбираем ячейки с нужными данными
                            HtmlNodeCollection pads = d.DocumentNode.SelectNodes("//td[@class='pad_resume']");
                            if (pads != null)
                            {
                                // Нам нужны только четные ячейки
                                int j = 1;
                                while (j &lt; pads.Count) {
                                    // Записываем текст из ячейки в RTB (убираем все лишнее через trim)
                                    rtb_output.Invoke(my_delegate, new object[] { pads[j].InnerText.Trim() + ";" });
                                    j = j + 2;
                                }
                                rtb_output.Invoke(my_delegate, new object[] { "\n" });
                            }
                        }
                    }
                }
            }
            a_delegate = new set_text(set_text_method);
            // Убираем дубли
            rtb_output.Invoke(a_delegate, new object[] { array_unique(rtb_output.Lines) });\
            // Делаем элементы формы активными
            tlp_main.Enabled = true;
            // Завершаем поток
            tr.Abort();
        }
*/