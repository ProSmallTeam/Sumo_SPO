﻿using Sumo.API;

namespace VisualSumoWPF
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

        public static DynamicDictionary ToDynamicDictionary(Sumo.API.Book book)
        {
            var dictionary = new DynamicDictionary();

            dictionary.SetValue("Name", book.Name);
            dictionary.SetValue("Year", book.SecondaryFields["Year"]);
            dictionary.SetValue("Author", book.SecondaryFields["Authors"][0]);

            return dictionary;
        }
    }
}