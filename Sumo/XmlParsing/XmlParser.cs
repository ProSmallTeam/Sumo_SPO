using System.Collections.Generic;
using System.Xml.Linq;
using DataBase;

namespace XmlParsing
{
    public static class XmlParser
    {
        public static Book Parse(string xml)
        {
            var document = XDocument.Parse(xml);
            var root = document.Element("Book");
            var secondaryFieldsElements = root.Element("SecondaryFields");

            var secondaryFields = new Dictionary<string, string>();

            if (secondaryFieldsElements != null)
                foreach (var element in secondaryFieldsElements.Elements())
                {
                    secondaryFields.Add(element.Name.ToString(), element.Value);
                }


            var book = new Book
            {
                Md5Hash = root.Element("Md5Hash") != null ? root.Element("Md5Hash").Value : null,
                Name = root.Element("Name") != null ? root.Element("Name").Value : null,
                Path = root.Element("Path") != null ? root.Element("Path").Value : null,
                SecondaryFields = secondaryFields
            };

            return book;
        }
    }
}
