using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataBase
{
    class QueryCreator
    {
        public List<int> Convert(string query)
        {
            var stringQuery = query.Split(new[] { ", ", "{", "}" }, StringSplitOptions.RemoveEmptyEntries);

            return (from nameAttr in stringQuery 
                    select new QueryDocument(new BsonDocument { { "Name", nameAttr } }) 
                    into queryDocument select Collections.Attributes.FindOneAs<BsonDocument>(queryDocument) 
                    into attr select int.Parse(attr["_id"].ToString())).ToList();

        }

        public static List<string> GetTypes(string stringParse)
        {
            var type = Regex.Match(stringParse, @"([a-zA-Z]{0,}):", RegexOptions.IgnoreCase);
            var types = new List<string>();

            while (type.Success)
            {
                types.Add(type.Groups[1].ToString());
                type = type.NextMatch();
            }

            return types;
        }

        public static List<string> GetNames(string type, string stringParse)
        {
            var splitedString = Regex.Split(stringParse, type);
            var uglyNames = Regex.Split(splitedString[1], ";");
            var clearNames = Regex.Replace(uglyNames[0], "(:| |;|\")", String.Empty);
            var names = Regex.Split(clearNames, ",", RegexOptions.IgnoreCase);

            return names.ToList();

        }

        public static List<int> GetId(string stringParse)
        {
            var list = new List<int>();

            var types = GetTypes(stringParse);

            foreach (var type in types)
            {
                var names = GetNames(type, stringParse);

                foreach (var name in names)
                {
                    var query = new QueryDocument(new BsonDocument { { name, type } });
                    var Root = Collections.Attributes.FindAs<BsonDocument>(query).ToList();

                    list.AddRange(Root.Select(attr => int.Parse(attr["_id"].ToString())));
                }
            }

            return list;
        }
    }
}