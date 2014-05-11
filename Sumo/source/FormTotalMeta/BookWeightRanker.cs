using System.Collections.Generic;
using System.Linq;
using Sumo.Api;

namespace FormTotalMeta
{
    public class BookWeightRanker
    {
        private readonly Book _primaryBook;
        
        private readonly SingleValueWeightRanker _singleRanker;

        public BookWeightRanker(Book primaryBook)
        {
            _primaryBook = primaryBook;
            _singleRanker = new SingleValueWeightRanker(_primaryBook.Name);
        }

        public double CalculateWeight(Book otherBook)
        {
            var nameWeight = 2 *_singleRanker.GetWeight(otherBook.Name);

            var secondaryFieldsWeightsSum = GetSafeFieldsFrom(otherBook)
                .Sum(field => GetBookSecondaryFieldWeight(field, otherBook));
            return nameWeight + secondaryFieldsWeightsSum;
        }

        private double GetBookSecondaryFieldWeight(string fieldName, Book otherBook)
        {
            var ranker = new PrimaryWeightRanker(_primaryBook.SecondaryFields[fieldName]);
            return ranker.GetWeight(fieldName, otherBook.SecondaryFields[fieldName]);
        }

        private IEnumerable<string> GetSafeFieldsFrom(Book otherBook)
        {
            return _primaryBook.SecondaryFields.Keys.Where(key => otherBook.SecondaryFields.ContainsKey(key));
        }
    }
}