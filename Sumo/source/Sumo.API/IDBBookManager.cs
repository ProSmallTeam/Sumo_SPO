using System.Collections.Generic;

namespace Sumo.Api
{
    public interface IDbBookManager
    {
        void Save(Book mainBook, List<Book> listOfAltMeta);
    }
}