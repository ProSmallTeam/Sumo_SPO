using System;
using System.Collections.Generic;
using DB;
using MongoDB.Bson;
using MongoDB.Driver;
using Sumo.Api;

static internal class AttributesTools
{
    /*/// <summary>
    /// TODO: Отложен до лучших времен
    /// </summary>
    /// <param name="name"></param>
    /// <param name="parrentId"></param>
    /// <param name="rootId"></param>
    /// <returns></returns>
    public int SaveAttribute(string name, int parrentId, int rootId)
    {
        var IsRoot = false;

        try
        {
            Attributes.Insert(new BsonDocument
                    {
                        {"_id", Attributes.Count()},
                        {"Name", name},
                        {"IsRoot", IsRoot},
                        {"RootRef", rootId},
                        {"FatherRef", parrentId}
                    }
                );

            return 0;
        }
        catch (Exception)
        {
            return -1;
        }
    }*/

    public static List<int> GetListOfAttributes(Book book)
    {
        var attributes = new List<int>();
        foreach (var field in book.SecondaryFields)
            foreach (var nameOfAttribute in field.Value)
            {
                var document = new QueryDocument(new BsonDocument {{"Name", nameOfAttribute}});
                var attribute = DataBase.Attributes.FindOneAs<BsonDocument>(document);
                if (attribute == null)
                    throw new NoAttrException();

                var idAttr = Int32.Parse(attribute["_id"].ToString());

                AddFatherAttr(attribute, attributes);

                attributes.Add(idAttr);
            }

        return attributes;
    }

    private static void AddFatherAttr(BsonDocument attribute, List<int> attributes)
    {
        var document = new QueryDocument(new BsonDocument { { "_id", Int32.Parse(attribute["FatherRef"].ToString()) } });
        var fatherAttr = DataBase.Attributes.FindOneAs<BsonDocument>(document);

        if (fatherAttr == null) return;

        AddFatherAttr(fatherAttr, attributes);

        var idAttr = Int32.Parse(fatherAttr["_id"].ToString());
        attributes.Add(idAttr);
    }
}