namespace InitializeDataBase
{
    using System.Collections.Generic;

    public class Attribute : IAttribute
    {
        public string Annotation;

        public List<IComment> Comments;

        public List<string> Categories;

        public string ReferenceToTheBook;

        public string fileExtension;
    }
}