using System.Linq;
using Sumo.Api;

namespace SumoViewer
{
// ReSharper disable InconsistentNaming
    internal class 	_3dfxConverts
    {
        public class _3dfxContent
        {
            public string Name { get; set; }

            public CategoryNode Node { get; set; }
        }

        public static _3dfxContent ToContent(CategoryNode node) 
        {
            return new _3dfxContent{Name = node.Name + "(" + node.Count + ")", Node = node};
        }

        public static CategoryNode ToNode(_3dfxContent content)
        {
            return content.Node;
        }

        public static DynamicDictionary ToDynamicDictionary(Sumo.Api.Book book)
        {
            var dictionary = new DynamicDictionary();

            dictionary.SetValue("Name", book.Name);
            dictionary.SetValue("Year", book.SecondaryFields["Year"]);

            //да да, адовое LINQ
            var str = book.SecondaryFields["Authors"].Aggregate("", (current, author) => current + (author + " "));

            dictionary.SetValue("Author", str);
            


            return dictionary;
        }
    }
}