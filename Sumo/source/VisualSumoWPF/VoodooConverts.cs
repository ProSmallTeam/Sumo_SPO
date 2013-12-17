using Sumo.API;

namespace VisualSumoWPF
{
    internal class 	VoodooConverts
    {
        internal class VoodoContent
        {
            public string Name { get; set; }

            public CategoryNode Node { get; set; }
        }

        public static VoodoContent ToContent(CategoryNode node) 
        {
            return new VoodoContent{Name = node.Name};
        }

        public static CategoryNode ToNode(VoodoContent content)
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