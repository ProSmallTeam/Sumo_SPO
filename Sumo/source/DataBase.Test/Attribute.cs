using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Test
{
    class Attribute : IAttribute
    {
        public string Annotation;

        public List<string> Categories;

        public string ReferenceToTheBook;

        public string fileExtension;
    }
}
