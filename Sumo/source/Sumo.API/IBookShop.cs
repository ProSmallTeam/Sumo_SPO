namespace Sumo.API
{
    using System.Collections.Generic;

    /// <summary>
    /// The BookShop interface.
    /// </summary>
    public interface IBookShop
    {
        IList<Book> Search(Book pattern);
    }
}
