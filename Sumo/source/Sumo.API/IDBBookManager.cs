using System.Collections.Generic;

namespace Sumo.API
{
    public interface IDBBookManager
    {
        void Save(Book mainBook, List<Book> listOfAltMeta);
    }
}