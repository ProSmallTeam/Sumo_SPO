using System.Collections.Generic;

namespace Sumo.API
{
    public class CategoryTree
    {
        public CategoryTree(List<CategoryTree> childs, string name, int count, int id)
        {
            Childs = childs;
            Name = name;
            Count = count;
            Id = id;
        }

        public List<CategoryTree> Childs { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
        public int Id { get; set; }

        public void AddChild(CategoryTree child)
        {
            Childs.Add(child);
        }
    }
}