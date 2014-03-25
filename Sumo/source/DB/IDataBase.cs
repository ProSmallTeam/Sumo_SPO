using System.Collections.Generic;
using Sumo.Api;

namespace DB
{
    public interface IDataBase
    {
        //просто добавить информацию о книге в глобальное хранилище
        int SaveBookMeta(Book book, List<Book> alternativeBook);

        int DeleteBookMeta(string md5Hash);

        bool IsHaveBookMeta(string md5Hash);

        int GetStatistic(string query); // формат строки запроса {name1, name2, ..., nameN}

        List<Book> GetBooks(string query, int limit, int offset);

        int SaveAttribute(string name, int parrentId, int rootId);

        int InsertTask(Task task, bool flagOfHighPriority);

        int RemoveTask(Task task);

        List<Task> GetTask(int quantity);

        CategoriesMultiList GetStatisticTree(string query);

    }
}