using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using Sumo.API;

namespace VisualSumoWPF
{

    class MetaManagerStub : IDbMetaManager
    {
        private int _operationsCounter = 0;
        public SumoSession CreateQuery(string query)
        {
            _operationsCounter++;
            var session = new SumoSession {SessionId = 10, Count = _operationsCounter};
            return session;
        }

        public List<Sumo.API.Book> GetDocuments(int sessionId, int count, int offset = 0)
        {
            _operationsCounter++;

            var list = new List<Sumo.API.Book>();
            var myBookFields = new Dictionary<string, List<string>>
                {
                    {"Авторы", new List<string>{"Герберт Шилдт"}},
                    {"Жанр", new List<string>{"C++"}},
                    {"Год", new List<string>{"2008"}},
                    {"Издательство", new List<string>{"Вильямс"}},
                    {"ISBN", new List<string>{"978-5-8459-0768-4"}},
                    {"Содержание", new List<string>{"В этой книге описаны все основные средства " +
                                                 "языка С++ - от элементарных понятий до супервозможностей. " +
                                                 "После рассмотрения основ программирования на C++ (переменных," +
                                                 " операторов, инструкций управления, функций, классов и объектов)" +
                                                 " читатель освоит такие более сложные средства языка, как механизм" +
                                                 " обработки исключительных ситуаций (исключений), шаблоны," +
                                                 " пространства имен, динамическая идентификация типов, стандартная" +
                                                 " библиотека шаблонов (STL), а также познакомится с расширенным набором" +
                                                 " ключевых слов, используемым в .NET-программировании. Автор справочника" +
                                                 " - общепризнанный авторитет в области программирования на языках C и C++," +
                                                 " Java и C# - включил в текст своей книги и советы программистам, которые позволят" +
                                                 " повысить эффективность их работы.","Книга рассчитана на широкий круг читателей," +
                                                 " желающих изучить язык программирования С++. "}}
                };

            var myBook = new Sumo.API.Book("MyBook", "1", "C:/", myBookFields);
            list.Add(myBook);

            for (var i = 1; i < count; i++)
            {
                var book = new Sumo.API.Book();
                book.Name += System.DateTime.Now.Millisecond;
                list.Add(book);
            }

            return list;
        }

        public CategoriesMultiList GetStatistic(int sessionId)
        {

            _operationsCounter++;

            var root = new CategoryNode { Id = 0, Name = "Все книги", Count = 1 };
            var authors = new CategoryNode {Id = 1, Name = "Авторы", Count = 3};
            var genres = new CategoryNode {Id = 2, Name = "Жанры", Count = 3};

            var authorsList = new CategoriesMultiList(authors, new List<CategoriesMultiList>{});
            var genresList = new CategoriesMultiList(genres, new List<CategoriesMultiList> {});

            var rootList = new CategoriesMultiList(root, new List<CategoriesMultiList> { authorsList, genresList });

            return rootList;
        }

        public void CloseSession(SumoSession session)
        {
            _operationsCounter++;

            Trace.WriteLine("CloseSession called");
        }

    }
}