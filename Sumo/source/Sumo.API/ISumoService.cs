using System.Collections.Generic;

namespace Sumo.API
{
    //для Sumo.exe
    public interface ISumoService
    {
        SumoSession CreateQuery(string query);

        List<Book> GetDocuments(SumoSession session, int offset, int count);

        ISumoStatistic GetStatistic(SumoSession session);

        void CloseSession(SumoSession session);

        //удаляет мета книги, и отвязывает её от пользователя
        void DeleteBook(string md5Hash);

        //просто добавить информацию о книге в глобальное хранилище
        void SaveBook(Book book);

        
    }
}