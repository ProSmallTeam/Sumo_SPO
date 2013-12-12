using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}