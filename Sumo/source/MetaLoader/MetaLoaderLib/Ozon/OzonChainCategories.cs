﻿namespace MetaLoaderLib.Ozon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using HtmlAgilityPack;

    using MetaLoaderLib.Interfaces;

    /// <summary>
    /// Класс, реализующий хранение цепочки комментариев.
    /// </summary>
    public class OzonChainCategories : IChainCategories
    {
        /// <summary>
        /// Конструктор класса цепочки категорий.
        /// </summary>
        public OzonChainCategories()
        {
            this.Chain = new List<string>();
        }

        /// <summary>
        /// Список категорий по порядку их следования.
        /// </summary>
        public List<string> Chain { get; private set; }

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
        /// Парсинг блока комментариев.
        /// </summary>
        /// <param name="textOfCategoriesBlock">
        /// Содержимое блока строки категорий.
        /// </param>
        public void Parse(string textOfCategoriesBlock)
        {
            var document = new HtmlDocument();
            document.LoadHtml(textOfCategoriesBlock);

            var categoryList = document.DocumentNode.SelectNodes("//li");

            foreach (var category in categoryList)
            {
                this.Chain.Add(category.InnerText);
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
