using System.Collections.Generic;

namespace Sumo.API
{
    public interface IDbBookManager
    {
        void Save(Book mainBook, List<Book> listOfAltMeta);
    }
}