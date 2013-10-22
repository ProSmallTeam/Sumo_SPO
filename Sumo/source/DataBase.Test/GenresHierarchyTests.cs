using NUnit.Framework;

namespace DataBase.Test
{
    [TestFixture]
    class GenresHierarchyTests
    {
        [SetUp]
        public void SetUp()
        {
            GenresHierarchy.AddCategory("category1", "root");
            GenresHierarchy.AddCategory("category2", "root");
            GenresHierarchy.AddCategory("category3", "root");
            GenresHierarchy.AddCategory("subcategory11", "category1");
            GenresHierarchy.AddCategory("subcategory12", "category1");
            GenresHierarchy.AddCategory("subcategory13", "category1");
            GenresHierarchy.AddCategory("subcategory21", "category2");
            GenresHierarchy.AddCategory("subcategory22", "category2");
            GenresHierarchy.AddCategory("subcategory31", "category3");
            GenresHierarchy.AddCategory("genre1", "subcategory11");
            GenresHierarchy.AddCategory("genre2", "subcategory12");
            GenresHierarchy.AddCategory("genre3", "subcategory12");
            GenresHierarchy.AddCategory("genre4", "subcategory13");
            GenresHierarchy.AddCategory("genre5", "subcategory21");
            GenresHierarchy.AddCategory("genre6", "subcategory22");
            GenresHierarchy.AddCategory("genre7", "subcategory31");
        }

        [Test]
        public void CategoriesChain()
        {
            Assert.AreEqual("root -> category1 -> subcategory12 -> genre2", GenresHierarchy.GetCategoriesChain("genre2"));
        }
    }
}
