using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Sumo.API;

namespace VisualSumoWPF
{
    
        internal class 	VoodooConverts
        {
            internal class VoodoContent
            {
                public string Name { get; set; }
            }

            public static VoodoContent ToContent(CategoryNode node) 
            {
               return new VoodoContent{Name = node.Name};
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

    internal class MakeMeHappy
    {
        public MakeMeHappy(IDbMetaManager metaManager)
        {
        }

        public MakeMeHappy() : this(null)
        {
        }


        public CategoriesMultiList GetTreeStatistic()
        {
            var a = new CategoryNode { Id = 12, Name = "Name", Count = 1};

            var list1 = new CategoriesMultiList(a);
            var list2 = new CategoriesMultiList(a, new List<CategoriesMultiList> { list1, list1, list1 });

            return list2;

        }

        public List<Sumo.API.Book> GetBooks()
        {
            const int booksCount = 5;
 
            var list = new List<Sumo.API.Book>();

            for (int i = 0; i < booksCount; i++)
            {

                var book = new Sumo.API.Book();

                book.Name = "Book Name" + i.ToString(CultureInfo.InvariantCulture);
                book.Md5Hash = i.ToString(CultureInfo.InvariantCulture);
                book.Path = "path";

                list.Add(book);
            }

            return list;
        }
    }
}