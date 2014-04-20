using System;
using System.Collections.Generic;
using System.Linq;
using DB;
using MongoDB.Bson;
using MongoDB.Driver;
using Sumo.Api;

internal class StatisticTools
{
    public CategoriesMultiList GetStatisticTree(string query)
    {
        var statisticTree = new CategoriesMultiList(new CategoryNode { Count = GetStatistic(query), Id = 0, Name = "/" });

        var listId = new List<int>();
        var attrId = new QueryCreator().Convert(query);
        listId.AddRange(attrId);

        AddChilds(statisticTree, listId);

        return statisticTree;
    }

    public int GetStatistic(string query)
    {
        var attrId = new QueryCreator().Convert(query);

        return GetStatistic(attrId);
    }

    private static int GetStatistic(List<int> attrId)
    {
        var queries = new QueryDocument(true);

        foreach (var id in attrId)
        {
            queries.Add("Attributes", id);
        }

        return (int)DataBase.Books.FindAs<BsonDocument>(queries).Count();
    }

    private static void AddChilds(CategoriesMultiList tree, List<int> listId)
    { 
        var queryDocument = new QueryDocument(new BsonDocument { { "FatherRef", tree.Node.Id } });

        var childs = DataBase.Attributes.FindAs<BsonDocument>(queryDocument).ToList();

        if (!childs.Any())
            return;

        foreach (var child in childs)
        {
            var list = new List<int>(listId);
            var childId = Int32.Parse(child["_id"].ToString());
            if(!list.Contains(childId))
                list.Add(childId);
                 
                
            var node = new CategoryNode
                {
                    Count = GetStatistic(list),
                    Id = Int32.Parse(child["_id"].ToString()),
                    Name = child["Name"].ToString()
                };

            var subTree = new CategoriesMultiList(node);

            AddChilds(subTree, listId);

            tree.AddChild(subTree);
        }
    }
}