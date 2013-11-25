using HtmlAgilityPack;

namespace MetaInformationLoader.Ozon
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
        public readonly List<string> Chain  = new List<string>();

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
                return (this.Chain.Count > 0) ? this.Chain[this.Chain.Count - 1] : null;
            }
        }

        /// <summary>
        /// Получает первую категорию в списке.
        /// </summary>
        public string First
        {
            get
            {
                return (this.Chain.Count > 0) ? this.Chain[0] : null;
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
            if ((index < 0) || (this.Chain.Count - 1 < index))
            {
                throw new IndexOutOfRangeException();
            }

            return this.Chain[index];
        }

        /// <summary>
        /// Добавляет категорию в конец списка.
        /// </summary>
        /// <param name="category">
        /// Новая категория.
        /// </param>
        public void Add(string category)
        {
            this.Chain.Add(category);
        }

        /// <summary>
        /// Мотод преобразования цепочки категорий в текст.
        /// </summary>
        /// <returns>
        /// Текстовое представление цепочки категорий.
        /// </returns>
        public override string ToString()
        {
            return this.Chain.Aggregate<string, string>(null, (current, category) => current + (category + " > "));
        }
    }
}
