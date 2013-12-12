namespace Sumo.API
{
    using System.Collections.Generic;

    /// <summary>
    /// The BookShop interface.
    /// </summary>
    public interface IBookShop
    {
        /// <summary>
        /// The search.
        /// </summary>
        /// <param name="pattern">
        /// The pattern.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        IList<Book> Search(Book pattern);
    }
}
