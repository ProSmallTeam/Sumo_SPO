using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Sumo.Api;
using XmlBookConverter;

namespace MetaRanker
{
    public class MetaRanker
    {
        #region Private Fields

        private static readonly List<string> ImportantFields = new List<string> { "ISBN", "Authors" };

        private List<Book> _rankedAlternativeBooks = new List<Book>();

        private readonly Book _totalBook;

        #endregion

        public static XDocument GetTotalMetaFor(OriginalMetaInformation meta, int baseMetasCount = 3)
        {
            return new MetaRanker().GetTotalMeta(meta, baseMetasCount);
        }

        #region Private Methods

        private MetaRanker()
        {
            _totalBook = new Book();   
        }

        private XDocument GetTotalMeta(OriginalMetaInformation meta, int baseMetasCount)
        {            
            Book primaryBook = BookConverter.ToBook(meta.PrimaryMeta);

            RankMeta(meta, baseMetasCount);

            // формируем totalBook

            var weights = _rankedAlternativeBooks.Select(book => GetWeight(primaryBook.Name, book.Name)).ToList();
            
            // формируем имя
            _totalBook.Name = _rankedAlternativeBooks[weights.IndexOf(weights.Max())].Name;

            // формируем md5 hash и путь
            _totalBook.Md5Hash = primaryBook.Md5Hash;
            _totalBook.Path = primaryBook.Path;

            //формируем поля которые есть в primary book
            foreach (string key in primaryBook.SecondaryFields.Keys)
            {
                weights = new List<double>();
                foreach (var book in _rankedAlternativeBooks)
                {
                    if (book.SecondaryFields.ContainsKey(key))
                    {
                        weights.Add(ImportantFields.Contains(key)
                            ? 2 * GetWeight(primaryBook.SecondaryFields[key], book.SecondaryFields[key])
                            : GetWeight(primaryBook.SecondaryFields[key], book.SecondaryFields[key])
                              - (primaryBook.SecondaryFields[key].Count - book.SecondaryFields[key].Count));
                    }
                    else
                    {
                        weights.Add(0);
                    }
                }

                _totalBook.SecondaryFields.Add(key, _rankedAlternativeBooks[weights.IndexOf(weights.Max())].SecondaryFields[key]);
            }

            // формируем поля которых пока нет в totalBook
            foreach (Book book in _rankedAlternativeBooks)
            {
                foreach (string key in book.SecondaryFields.Keys)
                {
                    if (!_totalBook.SecondaryFields.ContainsKey(key))
                    {
                        _totalBook.SecondaryFields.Add(key, book.SecondaryFields[key]);
                    }
                }
            }

            return BookConverter.ToXml(_totalBook);
        }


        private double GetWeight(IList<string> inputList, IList<string> comparedList)
        {
            int weight =
                inputList.Sum(inputString => LevenshteinDistance.GetLevenshteinDistance(inputString, comparedList));

            return 1 - (double)weight / inputList.Sum(inputString => inputString.Length);
        }

        private double GetWeight(string input, string compared)
        {
            return 1 - (double)LevenshteinDistance.GetLevenshteinDistance(input, compared) / input.Length;
        }

        private void RankMeta(OriginalMetaInformation meta, int baseMetasCount)
        {
            baseMetasCount = Math.Min(baseMetasCount, meta.AlternativeMeta.Count);

            Book primaryBook = BookConverter.ToBook(meta.PrimaryMeta);
            List<Book> altBooks = meta.AlternativeMeta.Select(BookConverter.ToBook).ToList();

            // задание веса каждой xml
            var weights = new List<double>();

            for (int i = 0; i < altBooks.Count(); i++)
            {
                double weight = 2 * GetWeight(primaryBook.Name, altBooks[i].Name);

                foreach (
                    string key in
                        primaryBook.SecondaryFields.Keys.Where(key => altBooks[i].SecondaryFields.ContainsKey(key)))
                {
                    weight += ImportantFields.Contains(key)
                        ? 2 * GetWeight(primaryBook.SecondaryFields[key], altBooks[i].SecondaryFields[key])
                        : GetWeight(primaryBook.SecondaryFields[key], altBooks[i].SecondaryFields[key])
                          - (primaryBook.SecondaryFields[key].Count - altBooks[i].SecondaryFields[key].Count);
                }

                weights.Add(weight);
            }


            SortAlternativeBooksByWeights(altBooks, weights.ToArray());

            _rankedAlternativeBooks = _rankedAlternativeBooks.Take(baseMetasCount).ToList();
        }

        private void SortAlternativeBooksByWeights(List<Book> altBooks, double [] weights)
        {
            var indices = new int[weights.Length];
            for (int i = 0; i < weights.Length; ++i) // заполнение от 0 до weights.Length - 1
                indices[i] = i;

            Array.Sort(weights, indices);

            for (int i = indices.Length - 1; i >= 0; --i)
                _rankedAlternativeBooks.Add(altBooks[indices[i]]);
        }

        #endregion

    }

}