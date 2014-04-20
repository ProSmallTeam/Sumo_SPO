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


        public BookMeta(MongoCollection<BsonDocument> books, MongoCollection<BsonDocument> alternativeMeta)
        {
            Books = books;
            AlternativeMeta = alternativeMeta;
        }

        public int SaveBookMeta(Book book, List<Book> alternativeBook = null)
        {
            try
            {
                var idOfAltMeta = InsertAltBookMeta(alternativeBook);

                var document = BookTools.CreateBook(Books, book, idOfAltMeta);

                Books.Insert(document);

                return 0;
            }
            catch (Exception)
            {

                return -1;
            }

        }

        private List<int> InsertAltBookMeta(List<Book> alternativeBook)
        {
            var idOfAltMeta = new List<int>();

            if (alternativeBook != null)
                foreach (var altBookMeta in alternativeBook.Select(altBook => BookTools.CreateBook(AlternativeMeta, altBook)))
                {
                    AlternativeMeta.Insert(altBookMeta);

                    idOfAltMeta.Add(int.Parse(altBookMeta["_id"].ToString()));
                }
            return idOfAltMeta;
        }

        public int DeleteBookMeta(string md5Hash)
        {
            try
            {
                var query = new QueryDocument(new BsonDocument { { "Md5Hash", md5Hash } });
                var book = Books.FindOneAs<BsonDocument>(query);

                DeleteAltBookMeta(book);

                Books.Remove(query);

                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private void DeleteAltBookMeta(BsonDocument book)
        {
            var idOfAltMeta = GetAltMetaId(book);

            foreach (var id in idOfAltMeta)
            {
                RemoveAltBookMeta(id);
            }
        }

        private void RemoveAltBookMeta(string id)
        {
            var query = new QueryDocument(new BsonDocument {{"_id", int.Parse(id)}});

            AlternativeMeta.Remove(query);
        }

        private static IEnumerable<string> GetAltMetaId(BsonDocument book)
        {
            var stringOfId = book["AlternativeMeta"].ToString();
            var idOfAltMeta = stringOfId
                .Substring(1, stringOfId.Length - 2)
                .Split(new[] {','}).ToList();
            return idOfAltMeta;
        }

        public bool IsHaveBookMeta(string md5Hash)
        {
            return Books.Find(new QueryDocument(new BsonDocument { { "Md5Hash", md5Hash } })).Any();
        }

        public List<Book> GetBooks(string query, int limit = 0, int offset = 0)
        {
            if (query == null) return GetAllBooks();

            var attrId = new QueryCreator().Convert(query);

            return GetBooksByAttrId(attrId, limit, offset);
        }

        private List<Book> GetAllBooks()
        {
            return BookTools.BsdToBook(Books.FindAllAs<BsonDocument>().ToList());
        }

        private List<Book> GetBooksByAttrId(IEnumerable<int> attrId, int limit = 0, int offset = 0)
        {
            var query = CreateMultipleQuery(attrId);

            return BookTools.BsdToBook(Books.FindAs<BsonDocument>(query).SetLimit(limit).SetSkip(offset).ToList());
        }

        private static QueryDocument CreateMultipleQuery(IEnumerable<int> attrId)
        {
            var query = new QueryDocument(true);

            foreach (var id in attrId)
            {
                query.Add("Attributes", id);
            }
            return query;
        }
    }
}
