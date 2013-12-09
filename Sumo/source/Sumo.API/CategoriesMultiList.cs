using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Sumo.API
{
    [DataContract]
    public class CategoriesMultiList
    {
        [DataMember]
        public CategoryNode Node;

        [DataMember]
        public List<CategoriesMultiList> Childs { get; set; }

        public CategoriesMultiList(CategoryNode node, List<CategoriesMultiList> childs)
        {
            Node = node;
            Childs = childs;
        }

        public CategoriesMultiList(CategoryNode node) : this(node, new List<CategoriesMultiList>())
        { }


        public void AddChild(CategoriesMultiList child)
        {
            Childs.Add(child);
        }
    }
}