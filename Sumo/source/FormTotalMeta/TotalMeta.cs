using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Sumo.Api;
using XmlBookConverter;

namespace FormTotalMeta
{
    public class TotalMeta
    {
        #region Private Fields

        private List<Book> _rankedAlternativeBooks = new List<Book>();

        private readonly Book _resultBook;

        #endregion

        public static XDocument GetTotalMetaFor(OriginalMetaInformation meta, int baseMetasCount = 3)
        {
            return new TotalMeta().GetTotalMeta(meta, baseMetasCount);
        }

        #region Private Methods

        private TotalMeta()
        {
            _resultBook = new Book();   
        }

        private XDocument GetTotalMeta(OriginalMetaInformation meta, int baseMetasCount)
        {            
            var primaryBook = meta.PrimaryMeta.ToBook();

            _rankedAlternativeBooks = BookMetaRanker.RankMeta(meta, baseMetasCount);

            // формируем totalBook
            var singleRanker = new SingleValueWeightRanker(primaryBook.Name);
            _resultBook.Name = singleRanker.GetMaxWeightedValue(_rankedAlternativeBooks.Select(b => b.Name).ToList());

            // формируем md5 hash и путь
            _resultBook.Md5Hash = primaryBook.Md5Hash;
            _resultBook.Path = primaryBook.Path;

            //формируем поля которые есть в primary book
            foreach (string key in primaryBook.SecondaryFields.Keys)
            {
                var secondaryRanker = new PrimaryWeightRanker(primaryBook.SecondaryFields[key]);
                string theKey = key;
                var maxWeightedValue = secondaryRanker.GetMaxWeightedValue(key, 
                    _rankedAlternativeBooks
                    .Where(b => b.SecondaryFields.ContainsKey(theKey))
                    .Select(b => b.SecondaryFields[theKey]));

                _resultBook.SecondaryFields.Add(key, maxWeightedValue);
            }

            // формируем все оставшееся
            foreach (var book in _rankedAlternativeBooks)
            {
                foreach (var key in book.SecondaryFields.Keys.Where(key => !_resultBook.SecondaryFields.ContainsKey(key)))
                {
                    _resultBook.SecondaryFields.Add(key, book.SecondaryFields[key]);
                }
            }

            return BookConverter.ToXml(_resultBook);
        }

        #endregion
    }
}
