﻿using System.Collections.Generic;
using System.Linq;
using Sumo.API;
using DataBase;

namespace DBMetaManager
{
    public class Manager : IDbMetaManager
    {
        private readonly IDataBase _dataBase;
        private Dictionary<SumoSession, string> SessionDictionary;
        
        public Manager(IDataBase dataBase)
        {
            SessionDictionary = new Dictionary<SumoSession, string>();
            _dataBase = dataBase;
        }

        public SumoSession CreateQuery(string query)
        {
        var session = new SumoSession
            {
                SessionId = SessionDictionary.Count(),
                Count = _dataBase.GetStatistic(query)
            };

            SessionDictionary.Add(session, query);

            return session;
        }

        public List<Book> GetDocuments(int sessionId, int count, int offset = 0)
        {
            var query = SessionDictionary.Single(t => t.Key.SessionId == sessionId).Value;

            var bookList = _dataBase.GetBooks(query, count, offset);

            return bookList;
        }

        public CategoriesMultiList GetStatistic(int sessionId)
        {
            return _dataBase.GetStatisticTree();
        }

        public void CloseSession(SumoSession session)
        {
            SessionDictionary.Remove(session);
        }
    }
}