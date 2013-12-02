namespace MetaLoaderLib.Interfaces
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Интерфейс для цепочки категорий.
    /// </summary>
    public interface IChainCategories
    {
        /// <summary>
        /// Список категорий по порядку их следования.
        /// </summary>
        List<string> Chain { get; }

        /// <summary>
        /// Получает последнюю категорию в списке.
        /// </summary>
        string Last { get; }

        /// <summary>
        /// Получает первую категорию в списке.
        /// </summary>
        string First { get; }

        /// <summary>
        /// Парсинг блока комментариев.
        /// </summary>
        /// <param name="textOfCategoriesBlock">
        /// Содержимое блока строки категорий.
        /// </param>
        void Parse(string textOfCategoriesBlock);

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
        string Get(int index);
    }
}
