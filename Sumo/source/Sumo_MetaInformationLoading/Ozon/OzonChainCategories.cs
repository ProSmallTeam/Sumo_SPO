using HtmlAgilityPack;

namespace Sumo_MetaInformationLoading.Ozon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Класс, реализующий хранение цепочки коментариев.
    /// </summary>
    public class OzonChainCategories
    {
        /// <summary>
        /// Список категорий по порядку их следования.
        /// </summary>
        private readonly List<string> chain  = new List<string>();

        public static OzonChainCategories Parse(string textOfCategoriesBlock)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(textOfCategoriesBlock);

            var categoryList = document.DocumentNode.SelectNodes("//li");

            OzonChainCategories ozonChainCategories = new OzonChainCategories();
            foreach (var category in categoryList)
            {
                ozonChainCategories.Add(category.InnerText);
            }

            return ozonChainCategories;
        }

        /// <summary>
        /// Получает последнюю категорию в списке.
        /// </summary>
        public string Last
        {
            get
            {
                return (this.chain.Count > 0) ? this.chain[this.chain.Count - 1] : null;
            }
        }

        /// <summary>
        /// Получает первую категорию в списке.
        /// </summary>
        public string First
        {
            get
            {
                return (this.chain.Count > 0) ? this.chain[0] : null;
            }
        }

        /// <summary>
        /// Получает категорию по индексу в списке.
        /// </summary>
        /// <param name="index">
        /// Индекс категории в списке.
        /// </param>
        /// <returns>
        /// Категория с инвексом index.
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Индекс находится за пределами диапазона
        /// </exception>
        public string Get(int index)
        {
            if ((index < 0) || (this.chain.Count - 1 < index))
            {
                throw new IndexOutOfRangeException();
            }

            return this.chain[index];
        }

        /// <summary>
        /// Добавляет категорию в конец списка.
        /// </summary>
        /// <param name="category">
        /// Новая категория.
        /// </param>
        public void Add(string category)
        {
            this.chain.Add(category);
        }

        /// <summary>
        /// Мотод преобразования цепочки категорий в текст.
        /// </summary>
        /// <returns>
        /// Текстовое представление цепочки категорий.
        /// </returns>
        public override string ToString()
        {
            return this.chain.Aggregate<string, string>(null, (current, category) => current + (category + " > "));
        }
    }
}
