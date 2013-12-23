using Sumo.API;

namespace VisualSumoWPF
{
// ReSharper disable InconsistentNaming
    internal class 	_3dfxConverts
    {
        internal class _3dfxContent
        {
            public string Name { get; set; }

            public CategoryNode Node { get; set; }
        }

        public static _3dfxContent ToContent(CategoryNode node) 
        {
            return new _3dfxContent{Name = node.Name + "(" + node.Count + ")"};
        }

        public static CategoryNode ToNode(_3dfxContent content)
        {
            return content.Node;
        }

        public static DynamicDictionary ToDynamicDictionary(Sumo.API.Book book)
        {
            var dictionary = new DynamicDictionary();

            dictionary.SetValue("Name", book.Name);
            dictionary.SetValue("Year", book.Md5Hash);
            dictionary.SetValue("Author", book.Path);

            return dictionary;
        }
    }
}