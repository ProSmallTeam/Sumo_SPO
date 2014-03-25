using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Sumo.Api;

namespace XmlBookConverter
{
    public static class BookConverter
    {
        public static Book ToBook(XDocument xDocument)
        {
            var root = xDocument.Element("Book");
         //   var root = root.Element("SecondaryFields");

            var secondaryFields = new Dictionary<string, List<string>>();

            if (root == null)
            {
                return new Book();
            }

            var md5Hash = string.Empty;
            var name = string.Empty;
            var path = string.Empty;

            foreach (var element in root.Elements())
            {
                var nameOfElement = element.Name.ToString();

                if (nameOfElement == "Md5Hash")
                {
                    md5Hash = element.Value;
                    continue;
                }

                if (nameOfElement == "Name")
                {
                    name = element.Value;
                    continue;
                }

                if (nameOfElement == "Path")
                {
                    path = element.Value;
                    continue;
                }

                var value = element.Elements().Any()
                    ? element.Elements().Select(xElement => xElement.Value).ToList()
                    : new List<string> { element.Value };

                secondaryFields.Add(nameOfElement, value);
            }


            var book = new Book
            {
                Md5Hash = md5Hash,
                Name = name,
                Path = path,
                SecondaryFields = secondaryFields
            };

            return book;
        }

        public static XDocument ToXml(Book book)
        {
            var md5HashElement = book.Md5Hash != null ? new XElement("Md5Hash", book.Md5Hash) : null;

            var nameElement = book.Name != null ? new XElement("Name", book.Name) : null;

            var pathElement = book.Path != null ? new XElement("Path", book.Path) : null;

            var bookElement = new XElement("Book", md5HashElement, nameElement, pathElement);

            if (book.SecondaryFields == null || book.SecondaryFields.Count == 0) return new XDocument(bookElement);

            foreach (var field in book.SecondaryFields)
            {
                if (field.Value.Count == 1)
                {
                    bookElement.Add(new XElement(field.Key, field.Value[0].Trim()));
                }
                else
                {
                    var fieldElement = new XElement(field.Key);

                    for (var i = 0; i < field.Value.Count; i++)
                    {
                        fieldElement.Add(new XElement("Item" + (i + 1), field.Value[i].Trim()));
                    }

                    bookElement.Add(fieldElement);
                }
            }


            return new XDocument(bookElement);
        }
    }
}
