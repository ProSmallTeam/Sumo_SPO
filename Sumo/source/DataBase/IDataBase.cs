﻿using System.Collections.Generic;
using Sumo.API;

namespace DataBase
{
    public interface IDataBase
    {
        //просто добавить информацию о книге в глобальное хранилище
        int SaveBookMeta(Book book, List<Book> alternativeBook);

        int DeleteBookMeta(string md5Hash);

        bool IsHaveBookMeta(string md5Hash);

        int GetStatistic(string query); // формат строки запроса {name1, name2, ..., nameN}

        int GetStatistic(List<int> attrId);

        List<Book> GetBooksByAttrId(List<int> attrId, int limit, int offset);

        int SaveAttribute(string name, int parrentId, int rootId);

        int InsertTask(Task task, bool flagOfHighPriority);

        int RemoveTask(Task task);

        List<Task> GetTask(int quantity);

        CategoriesMultiList GetStatisticTree();

    }
}