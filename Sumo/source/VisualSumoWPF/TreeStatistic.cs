using System.Collections.Generic;

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
        public TreeStatistic(List<TreeStatistic> childs, string name, int count)
        {
            Childs = childs;
            Name = name;
            Count = count;
        }

        public TreeStatistic(string name, int count)
        {
            Childs = null;
            Name = name + "(" + count + ")";
            Count = count;
        }

        public TreeStatistic(string name)
        {
            Childs = null;
            Name = name + "(" + Count + ")";
        }

        public List<TreeStatistic> Childs { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}