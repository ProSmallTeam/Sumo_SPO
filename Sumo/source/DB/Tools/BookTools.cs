using System.Collections.Generic;
using DB;
using MongoDB.Bson;
using MongoDB.Driver;
using Sumo.Api;

static internal class BookTools
{
    public static BsonDocument CreateBook(Book book, MongoCollection<BsonDocument> collections, IEnumerable<int> idOfAltMeta = null)
    {
        var attributes = new List<int>();

        if (book.SecondaryFields != null)
            attributes = AttributesTools.GetListOfAttributes(book);

        var document = new BsonDocument
            {
                {"_id", collections.Count()},
                {"Md5Hash", book.Md5Hash},
                {"Name", book.Name},
                {"Path", book.Path}, //место подключения поддержки различных пользователей
                {"Attributes", new BsonArray(attributes)},
                {"AlternativeMeta", idOfAltMeta != null ? new BsonArray(idOfAltMeta) : null }
            };

        return document;
    }

    public static List<Book> BsdToBook(IEnumerable<BsonDocument> list)
    {
        var listBook = new List<Book>();

        foreach (var bsonBook in list)
        {
            var secondaryFields = GetSecondaryFields(bsonBook);

            listBook.Add(new Book
                {
                    Name = bsonBook["Name"].ToString(),
                    Md5Hash = bsonBook["_id"].ToString(),
                    Path = bsonBook.Contains("Path") ? bsonBook["Path"].ToString() : null,
                    SecondaryFields = secondaryFields
                }
                );
        }

        return listBook;
    }

    private static Dictionary<string, List<string>> GetSecondaryFields(BsonDocument bsonBook)
    {
        var listOfAttributes = bsonBook.GetValue("Attributes");
        var listOfSecondaryFields = new Dictionary<string, List<string>>();


        foreach (var attributeId in listOfAttributes.AsBsonArray)
        {
            AddToSecondaryFields(listOfSecondaryFields, attributeId);
        }

        return listOfSecondaryFields;
    }

    private static void AddToSecondaryFields(Dictionary<string, List<string>> listOfSecondaryFields, BsonValue attributeId)
    {
        var document = FindAttribute(attributeId.ToInt32());

        var rootId = document["RootRef"].ToInt32();
        var secondaryField = FindAttribute(rootId);

        if (secondaryField == null) return;

        var name = secondaryField["Name"].ToString();
        var value = document["Name"].ToString();

        InsertValueToDictionary(listOfSecondaryFields, name, value);
    }

    private static BsonDocument FindAttribute(int id)
    {
        var query = new QueryDocument("_id", id);
        var document = DataBase.Attributes.FindOneAs<BsonDocument>(query);
        return document;
    }

    private static void InsertValueToDictionary(Dictionary<string, List<string>> listOfSecondaryFields, string name, string value)
    {
        if (listOfSecondaryFields.ContainsKey(name))
        {
            listOfSecondaryFields[name].Add(value);
        }
        else
        {
            listOfSecondaryFields.Add(name, new List<string> { value });
        }
    }
}