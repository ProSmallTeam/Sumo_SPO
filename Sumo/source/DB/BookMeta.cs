using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using Sumo.Api;

namespace DB
{
    class BookMeta
    {
        private MongoCollection<BsonDocument> Books;

        private MongoCollection<BsonDocument> AlternativeMeta;


        public BookMeta(MongoCollection<BsonDocument> bookCollection, MongoCollection<BsonDocument> altMetaCollection)
        {
            Books = bookCollection;
            AlternativeMeta = altMetaCollection;
        }

        public int SaveBookMeta(Book book, List<Book> alternativeBook = null)
        {
            try
            {
                var idOfAltMeta = new List<int>();

                if (alternativeBook != null)
                    foreach (var altBookMeta in alternativeBook.Select(altBook => BookTools.CreateBook(altBook, AlternativeMeta)))
                    {
                        AlternativeMeta.Insert(altBookMeta);

                        idOfAltMeta.Add(int.Parse(altBookMeta["_id"].ToString()));
                    }

                var document = BookTools.CreateBook(book, Books, idOfAltMeta);

                Books.Insert(document);

                return 0;
            }
            catch (Exception)
            {

                return -1;
            }

        }

        public int DeleteBookMeta(string md5Hash)
        {
            try
            {
                var query = new QueryDocument(new BsonDocument { { "Md5Hash", md5Hash } });

                var book = Books.FindOneAs<BsonDocument>(query);

                Books.Remove(query);

                var stringOfid = book["AlternativeMeta"].ToString();
                var idOfAltMeta = stringOfid
                                           .Substring(1, stringOfid.Length - 2)
                                           .Split(new[] { ',' }).ToList();

                foreach (var id in idOfAltMeta)
                {
                    query = new QueryDocument(new BsonDocument { { "_id", int.Parse(id) } });

                    AlternativeMeta.Remove(query);

                }

                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public bool IsHaveBookMeta(string md5Hash)
        {
            return Books.Find(new QueryDocument(new BsonDocument { { "Md5Hash", md5Hash } })).Any();
        }

        public List<Book> GetBooks(string query, int limit = 0, int offset = 0)
        {
            if (query == null) return BookTools.BsdToBook(Books.FindAllAs<BsonDocument>().ToList());

            var attrId = new QueryCreator().Convert(query);

            return GetBooksByAttrId(attrId, limit, offset);
        }

        private List<Book> GetBooksByAttrId(IEnumerable<int> attrId, int limit = 0, int offset = 0)
        {
            var query = new QueryDocument(true);

            foreach (var id in attrId)
            {
                query.Add("Attributes", id);
            }

            return BookTools.BsdToBook(Books.FindAs<BsonDocument>(query).SetLimit(limit).SetSkip(offset).ToList());
        }
    }
}
