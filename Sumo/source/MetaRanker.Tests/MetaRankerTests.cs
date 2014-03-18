using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;

namespace MetaRanker.Tests
{
    [TestFixture]
    public class MetaRankerTests
    {
        [Test]
        public void GetTotalXmlForFirstBookTest()
        {
            var primaryMeta = XDocument.Load(@"xmlfiles\Игра престолов. Битва королей\primary.xml");

            var pathToFiles = Directory.GetFiles(@"xmlfiles\Игра престолов. Битва королей").ToList();
            pathToFiles = pathToFiles.Select(pathToFile => pathToFile.Substring(pathToFile.LastIndexOf(@"\") + 1)).ToList();

            var altMetas = (from pathToFile in pathToFiles where pathToFile != "primary.xml" select XDocument.Load(@"xmlfiles\Игра престолов. Битва королей\" + pathToFile)).ToList();

            var totalXml = new MetaRanker().GetTotalXml(primaryMeta, altMetas);

            Assert.AreEqual(@"<Book>
  <Md5Hash>437899147903618</Md5Hash>
  <Name>Игра престолов. Битва королей</Name>
  <Path>D:\Library\1</Path>
  <Authors>Джордж Рэймонд Ричард Мартин</Authors>
  <ISBN>978-5-17-060391-6</ISBN>
  <PublicHouse>Астрель</PublicHouse>
  <PublicYear>2013</PublicYear>
  <Anotation>Перед вами - знаменитая эпопея ""Песнь льда и огня"". 
		   Эпическая, чеканная сага о мире Семи Королевств. 
		   О мире суровых земель вечного холода и радостных земель вечного лета. 
		   О мире опасных приключений, тончайших политических интриг и великих деяний. 
		   О мире лордов и героев, драконов, воинов и магов, чернокнижников и убийц - всех, 
		   кого свела Судьба во исполнение пророчества...</Anotation>
  <PicturePath>http://static2.ozone.ru/multimedia/books_covers/c300/1005198128.jpg</PicturePath>
  <Language>Русский</Language>
  <PageCount>1150</PageCount>
  <Categories>Художественная литература, Фантастика. Фэнтези. Мистика, Зарубежное фэнтези </Categories>
</Book>", totalXml.ToString());
        }

        [Test]
        public void GetTotalXmlForSecondBookTest()
        {
            var primaryMeta = XDocument.Load(@"xmlfiles\Океан в конце дороги\primary.xml");

            var pathToFiles = Directory.GetFiles(@"xmlfiles\Океан в конце дороги").ToList();
            pathToFiles = pathToFiles.Select(pathToFile => pathToFile.Substring(pathToFile.LastIndexOf(@"\") + 1)).ToList();

            var altMetas = (from pathToFile in pathToFiles where pathToFile != "primary.xml" select XDocument.Load(@"xmlfiles\Океан в конце дороги\" + pathToFile)).ToList();

            var totalXml = new MetaRanker().GetTotalXml(primaryMeta, altMetas);

            Assert.AreEqual(@"<Book>
  <Md5Hash>432343284790781</Md5Hash>
  <Name>Океан в конце дороги</Name>
  <Path>D:\Library\2</Path>
  <Authors>Нил Гейман</Authors>
  <ISBN>978-5-17-079158-3</ISBN>
  <PublicHouse>АСТ</PublicHouse>
  <PublicYear>2013</PublicYear>
  <PageCount>320</PageCount>
  <PicturePath>http://static1.ozone.ru/multimedia/books_covers/c300/1008289593.jpg</PicturePath>
  <Language>Русский</Language>
  <Anotation>От знаменитого автора ""Американских богов"" и ""Сыновей Ананси"". Захватывающая сказка-миф, 
		   блестяще рассказанная история одинокого ""книжного"" мальчика, имени которого читатель так и не узнает, но в котором 
		   безошибочно угадываются черты самого Нила Геймана.</Anotation>
  <Categories>Художественная литература, Фэнтези, Зарубежное фэнтези, Современная зарубежная фантастика, 
		    Мистическая зарубежная фантастика </Categories>
</Book>", totalXml.ToString());
        }

        [Test]
        public void GetTotalXmlForThirdBookTest()
        {
            var primaryMeta = XDocument.Load(@"xmlfiles\Рыцарь Семи Королевств\primary.xml");

            var pathToFiles = Directory.GetFiles(@"xmlfiles\Рыцарь Семи Королевств").ToList();
            pathToFiles = pathToFiles.Select(pathToFile => pathToFile.Substring(pathToFile.LastIndexOf(@"\") + 1)).ToList();

            var altMetas = (from pathToFile in pathToFiles where pathToFile != "primary.xml" select XDocument.Load(@"xmlfiles\Рыцарь Семи Королевств\" + pathToFile)).ToList();

            var totalXml = new MetaRanker().GetTotalXml(primaryMeta, altMetas);

            Assert.AreEqual(@"<Book>
  <Md5Hash>79513385</Md5Hash>
  <Name>Рыцарь Семи Королевств</Name>
  <Path>D:\Library\3</Path>
  <Authors>Мартин Дж.</Authors>
  <ISBN>978-5-17-079458-4</ISBN>
  <PublicHouse>АСТ</PublicHouse>
  <PublicYear>2014</PublicYear>
  <PageCount>381</PageCount>
  <PicturePath>http://www.chitai-gorod.ru/upload/iblock/6f1/6f1cd28a4209d6f36078354f411c3a99.jpg</PicturePath>
  <Categories>Зарубежная фантастика</Categories>
  <Anotation>Миллионы фанатов – без тени преувеличения – ждут, затаив дыхание, 
		   каждой новой книги Джорджа Мартина из цикла «Песнь Льда и Огня». Но еще нам хочется знать 
		   ответы на вопросы – что было раньше? Что привело Семь Королевств к кровавой распре, к гражданской войне, 
		   которая вот-вот ввергнет их в гибель? И на многие из этих вопросов отвечает цикл Джорджа Мартина «Рыцарь Семи Королевств» – 
		   ПРЕДЫСТОРИЯ нашей любимой саги! Еще сто лет – до смертоносного противостояния Старков, Баратеонов и Ланнистеров. 
		   Еще правит Вестеросом династия Таргариенов от крови драконов. Еще свежа память о битве за Железный трон Дейемона и 
		   Дейерона Таргариенов, еще стоят у городских стен эшафоты, на которых окончили жизнь проигравшие. А по вестеросским 
		   землям странствует молодой рыцарь Дункан со своим оруженосцем – десятилетним Эгом, – он жаждет славы, чести и приключений, 
		   и он получит их. И не только на ристалищах чести, но и в череде жестоких заговоров и опасных политических интриг, по-прежнему 
		   зреющих за замковыми стенами Семи Королевств…</Anotation>
  <Language>русский</Language>
</Book>", totalXml.ToString());
        }
    }
}
