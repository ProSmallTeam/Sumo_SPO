using System;
using DB;
using DBMetaManager;
using Sumo.Api;

namespace BookService
{
    public class ReleasingBooksServiceContainer : IBooksServiceContainer
    {
        public object ResolveService()
        {
            var dataBase = new DataBase(Sumo.Api.Resources.MongoConnectionString, Resources.MongoDataBaseName);
            var manager = new DbMetaManager(dataBase);
            return manager;
        }

        public void ReleaseService()
        {
            
        }
    }
}