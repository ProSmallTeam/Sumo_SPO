using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Sumo.API;

namespace MetaRanker
{
    public static class MetaRanker
    {
        private static List<Book> _rankedAltBooks = new List<Book>();

        private static readonly List<string> ImportantFields = new List<string> {"ISBN", "Authors"};

        private static double GetWeight(IList<string> inputList, IList<string> comparedList)
        {
            var weight = inputList.Sum(inputString => LevenshteinDistance.GetLevenshteinDistance(inputString, comparedList));

            return 1 - (double)weight / inputList.Sum(inputString => inputString.Length);
        }

        private static double GetWeight(string input, string compared)
        {
            return 1 - (double)LevenshteinDistance.GetLevenshteinDistance(input, compared) / input.Length;
        }

        private static void RankMeta(XDocument primaryMeta, IEnumerable<XDocument> altMetas)
        {
            var primaryBook = XmlBookConverter.XmlBookConverter.ToBook(primaryMeta);
            var altBooks = altMetas.Select(XmlBookConverter.XmlBookConverter.ToBook).ToList();

            // задание веса каждой xml
            var weights = new List<double>();

            for (var i = 0; i < altBooks.Count(); i++)
            {
                var weight  = 2 * GetWeight(primaryBook.Name, altBooks[i].Name);

                foreach (var key in primaryBook.SecondaryFields.Keys.Where(key => altBooks[i].SecondaryFields.ContainsKey(key)))
                {
                    weight += ImportantFields.Contains(key)
                                      ? 2 * GetWeight(primaryBook.SecondaryFields[key], altBooks[i].SecondaryFields[key])
                                      : GetWeight(primaryBook.SecondaryFields[key], altBooks[i].SecondaryFields[key])
                                        - (primaryBook.SecondaryFields[key].Count - altBooks[i].SecondaryFields[key].Count);
                }

                weights.Add(weight);
            }

            // Упорядочивание мета данных
            for (int counter = 0; counter < weights.Count; counter++)
            {
                var imax = weights.IndexOf(weights.Max());

                _rankedAltBooks.Add(altBooks[imax]);

                weights[imax] = double.MinValue;
            }
        }

        public static XDocument GetTotalXml(XDocument primaryMeta, IList<XDocument> altMetas, int baseMetasCount = 3)
        {
            var totalBook = new Book();
            var primaryBook = XmlBookConverter.XmlBookConverter.ToBook(primaryMeta);

            RankMeta(primaryMeta, altMetas);

            baseMetasCount = Math.Min(baseMetasCount, altMetas.Count);

            // формируем totalBook

            // формируем имя
            var weights = new List<double>();

            for (int i = 0; i < baseMetasCount; i++)
            {
                weights.Add(GetWeight(primaryBook.Name, _rankedAltBooks[i].Name));
            }

            totalBook.Name = _rankedAltBooks[weights.IndexOf(weights.Max())].Name;

            // формируем md5 hash и путь
            totalBook.Md5Hash = primaryBook.Md5Hash;
            totalBook.Path = primaryBook.Path;

            //формируем поля которые есть в primary book
            foreach (var key in primaryBook.SecondaryFields.Keys)
            {
                weights = new List<double>();
                for (int i = 0; i < baseMetasCount; i++)
                {
                    if (_rankedAltBooks[i].SecondaryFields.ContainsKey(key))
                    {
                        weights[i] += ImportantFields.Contains(key)
                                      ? 2 * GetWeight(primaryBook.SecondaryFields[key], _rankedAltBooks[i].SecondaryFields[key])
                                      : GetWeight(primaryBook.SecondaryFields[key], _rankedAltBooks[i].SecondaryFields[key])
                                        - (primaryBook.SecondaryFields[key].Count - _rankedAltBooks[i].SecondaryFields[key].Count);
                    }
                }

                totalBook.SecondaryFields.Add(key, _rankedAltBooks[weights.IndexOf(weights.Max())].SecondaryFields[key]);
            }

            // формируем поля которых пока нет в totalBook
            for (int i = 0; i < baseMetasCount; i++)
            {
                foreach (var key in _rankedAltBooks[i].SecondaryFields.Keys)
                {
                    if (!totalBook.SecondaryFields.ContainsKey(key))
                    {
                        totalBook.SecondaryFields.Add(key, _rankedAltBooks[i].SecondaryFields[key]);
                    }
                }
            }

            return XmlBookConverter.XmlBookConverter.ToXml(totalBook);
        }
    }
}
