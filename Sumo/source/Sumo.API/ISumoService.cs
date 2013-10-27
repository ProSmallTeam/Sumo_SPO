using System.Collections.Generic;

namespace Sumo.API
{
    public interface ISumoService
    {
        //просто добавить информацию о книге в глобальное хранилище
        void SaveBookMeta(Book book);

        bool IsHaveBookMeta(string md5Hash);

        // Todo: плохо, непонятно, переделать
        int GetStatistic(string typeOfStatistic, string inputValue);

        IList<Book> GetBooksByFolderId(List<int> foldersId, int offset);
    }
}