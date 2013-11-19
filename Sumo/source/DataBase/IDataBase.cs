using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataBase
{
    public interface IDataBase
    {
        //просто добавить информацию о книге в глобальное хранилище
        int SaveBookMeta(Book book, List<Book> alternativeBook );

        int DeleteBookMeta(string md5Hash);

        bool IsHaveBookMeta(string md5Hash);

        int GetStatistic(string query); // формат строки запроса {name1, name2, ..., nameN}

        IList<Book> GetBooksByAttrId(List<int> attrId, int limit, int offset);

        int SaveAttribute(string name, int parrentId, int rootId);
    }
}