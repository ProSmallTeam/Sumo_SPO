using System.Collections;
using System.Collections.Generic;

namespace DataBase
{
    static class GenresHierarchy
    {
        static ArrayList root = new ArrayList();

        static Dictionary<string, string> categoryCodeDictionary = new Dictionary<string, string>();

        public static ArrayList FindCategory(string categoryName)
        {
            if (categoryName == "root")
            {
                return root;
            }

            var categoryList = root;

            var categoryCode = categoryCodeDictionary[categoryName];

            for (int i = 0; i < categoryCode.Length; i++)
            {
                categoryList = (ArrayList) categoryList[i];
            }

            return categoryList;
        }

        public static void AddCategory(string categoryName, string parentCategoryName)
        {
            if (parentCategoryName == null || categoryName == null)
            {
                return;
            }

            if (categoryCodeDictionary.ContainsKey(categoryName))
            {
                return;
            }

            var categoryCode = parentCategoryName == "root" ? "" : categoryCodeDictionary[categoryName];

            var parentCategoryList = FindCategory(parentCategoryName);
            categoryCodeDictionary.Add(categoryName, categoryCode + parentCategoryList.Count);
            parentCategoryList.Add(new ArrayList());
        }

        public static void DeleteCategory(string categoryName)
        {
            if (categoryName == "root")
            {
                return;
            }

            // удаление узла из дерева

            var categoryCode = categoryCodeDictionary[categoryName];

            var parentCategoryCode = categoryCode.Remove(categoryCode.Length - 1);

            var parentCategoryName = "";

            foreach (var key in categoryCodeDictionary.Keys)
            {
                if (categoryCodeDictionary[key] == parentCategoryCode)
                {
                    parentCategoryName = key;
                    break;
                }
            }

            FindCategory(parentCategoryName).Remove(categoryCode[categoryCode.Length - 1]);

            // удаление из dictionary категории и всех подкатегорий

            foreach (var key in categoryCodeDictionary.Keys)
            {
                if (categoryCodeDictionary[key].StartsWith(categoryName))
                {
                    categoryCodeDictionary.Remove(key);
                }
            }
        }

        public static string GetCategoriesChain(string categoryName)
        {
            if (categoryName == "root")
            {
                return "root";
            }

            var categoryCode = categoryCodeDictionary[categoryName];

            var result = "root";

            for (int i = 0; i < categoryCode.Length; i++)
            {
                foreach (var key in categoryCodeDictionary.Keys)
                {
                    if (categoryCodeDictionary[key] == categoryCode.Substring(0, i + 1))
                    {
                        result += " -> " + categoryCode.Substring(0, i + 1);
                        break;
                    }
                }
                
            }

            return result;
        }
    }
}
