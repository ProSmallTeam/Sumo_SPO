using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualSumoWPF
{

    //class SumoStattistic
    //{
    //    private List<Book> books;

    //    MyClass GetStatistic(List<Book> _books)
    //    {

    //    }

    //}

    public class TreeStatistic
    {
        public TreeStatistic(List<TreeStatistic> list, string name, int quantity)
        {
            this.list = list;
            this.Name = name + "(" + quantity.ToString() + ")";
            this.quantity = quantity;
        }
        public TreeStatistic(string name, int quantity)
        {
            this.list = null;
            this.Name = name + "(" + quantity.ToString() + ")";
            this.quantity = quantity;
        }
        public TreeStatistic(string name)
        {
            this.list = null;
            this.Name = name + "(" + quantity.ToString() + ")";
        }

        public void SetNumber(int quantity)
        {
            this.quantity = quantity;
        }
        public void AddList(List<TreeStatistic> tree)
        {
            this.list = tree;
        }

        public List<TreeStatistic> list { get; set; }

        public string Name { get; set; }

        public int quantity { get; set; }
    }

}
