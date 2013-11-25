using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Sumo.API;

namespace XmlBookConvert
{
    public static class XmlBookConverter
    {
        public static Book XmlToBook(XDocument xDocument)
        {
            var root = xDocument.Element("Book");
            var secondaryFieldsElements = root.Element("SecondaryFields");

            var secondaryFields = new Dictionary<string, List<string>>();

            if (secondaryFieldsElements != null)
                foreach (var element in secondaryFieldsElements.Elements())
                {
                    secondaryFields.Add(element.Name.ToString(),
                        element.Elements().Any()
                            ? element.Elements().Select(xElement => xElement.Value).ToList()
                            : new List<string> { element.Value });
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

        public static XDocument BookToXml(Book book)
        {
            var md5HashElement = book.Md5Hash != null ? new XElement("Md5Hash", book.Md5Hash) : null;

            var nameElement = book.Name != null ? new XElement("Name", book.Name) : null;

            var pathElement = book.Path != null ? new XElement("Path", book.Path) : null;

            var secondaryFieldsElement = book.SecondaryFields != null ? new XElement("SecondaryFields") : null;

            if (book.SecondaryFields != null)
            {
                foreach (var field in book.SecondaryFields)
                {
                    if (field.Value.Count != 1)
                    {
                        var fieldElement = new XElement(field.Key);

                        for (var i = 0; i < field.Value.Count; i++)
                        {
                            fieldElement.Add(new XElement("Item" + i, field.Value[i]));
                        }

                        secondaryFieldsElement.Add(fieldElement);
                    }
                    else
                    {
                        secondaryFieldsElement.Add(new XElement(field.Key, field.Value[0]));
                    }
                }
            }

            var bookElement = new XElement("Book", md5HashElement, nameElement, pathElement, secondaryFieldsElement);

            return new XDocument(bookElement);
        }
    }
}
