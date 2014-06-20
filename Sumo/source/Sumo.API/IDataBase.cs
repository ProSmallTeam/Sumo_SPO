using System.Collections.Generic;

namespace Sumo.Api
{
    public interface IDataBase
    {
        //просто добавить информацию о книге в глобальное хранилище
        int SaveBookMeta(Book book, List<Book> alternativeBook);

        int DeleteBookMeta(string md5Hash);

        bool IsHaveBookMeta(string md5Hash);

        int GetStatistic(string query); // формат строки запроса {name1, name2, ..., nameN}

        List<Book> GetBooks(string query, int limit, int offset);

        CategoriesMultiList GetStatisticTree(string query);

    }
}