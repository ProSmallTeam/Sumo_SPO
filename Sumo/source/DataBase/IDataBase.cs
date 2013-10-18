using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataBase
{
    public interface IDataBase
    {
        void InsertBook(BookInformation book);

        int GetStatistic(string typeOfStatistic, string inputValue);
    }
}