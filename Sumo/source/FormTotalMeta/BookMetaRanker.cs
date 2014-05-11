using System;
using System.Collections.Generic;
using System.Linq;
using Sumo.Api;
using XmlBookConverter;

namespace FormTotalMeta
{
    public class BookMetaRanker
    {
        #region Private Fields

        #endregion

        public static List<Book> RankMeta(OriginalMetaInformation meta, int baseMetasCount = 3)
        {
            return new BookMetaRanker().Rank(meta, baseMetasCount);
        }

        #region Private Methods

        private BookMetaRanker()
        {
        }

        private List<Book> Rank(OriginalMetaInformation meta, int baseMetasCount)
        {
            baseMetasCount = Math.Min(baseMetasCount, meta.AlternativeMeta.Count);

            var primaryBook = meta.PrimaryMeta.ToBook();
            var altBooks = meta.AlternativeMeta.Select(BookConverter.ToBook).ToList();
            
            var bookWeightRanker = new BookWeightRanker(primaryBook);
            
            // сортировка xml относительно веса
            var books = altBooks
                .Select(book => new
                    {
                        Book = book,
                        Weight = bookWeightRanker.CalculateWeight(book)
                    })
                .OrderByDescending(t => t.Weight)
                .Select(t => t.Book)
                .Take(baseMetasCount)
                .ToList();

            return books;
        }

        #endregion
    }
}