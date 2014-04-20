using System;
using System.Collections.Generic;
using System.Linq;
using DB;
using MongoDB.Bson;
using MongoDB.Driver;
using Sumo.Api;

internal class Statistic
{
    private readonly MongoCollection<BsonDocument> Books;
    private readonly MongoCollection<BsonDocument> Attributes;

    public Statistic(MongoCollection<BsonDocument> books, MongoCollection<BsonDocument> attributes)
    {
        Books = books;
        Attributes = attributes;
    }

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

    private int GetStatistic(List<int> attrId)
    {
        var queries = CreateStatisticQuery(attrId);

        return (int)Books.FindAs<BsonDocument>(queries).Count();
    }

    private static QueryDocument CreateStatisticQuery(List<int> attrId)
    {
        var queries = new QueryDocument(true);

        foreach (var id in attrId)
        {
            queries.Add("Attributes", id);
        }
        return queries;
    }

    private void AddChilds(CategoriesMultiList tree, List<int> listId)
    { 
        var childs = FindChilds(tree.Node.Id);

        if (!childs.Any())
            return;

        foreach (var child in childs)
        {
            var subTree = GetTree(child, listId);

            AddChilds(subTree, listId);

            tree.AddChild(subTree);
        }
    }

    private CategoriesMultiList GetTree(BsonDocument root, List<int> attributesId)
    {
        var rootId = Int32.Parse(root["_id"].ToString());

        var attrId = AddAttribute(rootId, attributesId);

        var subTree = CreateTree(root, attrId);
        return subTree;
    }

    private static List<int> AddAttribute(int attributeId, List<int> attributesId)
    {
        var attrId = new List<int>(attributesId);
        var rootId = attributeId;
        if (!attrId.Contains(rootId))
            attrId.Add(rootId);
        return attrId;
    }

    private CategoriesMultiList CreateTree(BsonDocument root, List<int> attrId)
    {
        var node = new CategoryNode
            {
                Count = GetStatistic(attrId),
                Id = Int32.Parse(root["_id"].ToString()),
                Name = root["Name"].ToString()
            };

        var subTree = new CategoriesMultiList(node);

        return subTree;
    }

    private List<BsonDocument> FindChilds(int id)
    {
        var queryDocument = new QueryDocument(new BsonDocument {{"FatherRef", id}});

        var childs = Attributes.FindAs<BsonDocument>(queryDocument).ToList();
        return childs;
    }
}