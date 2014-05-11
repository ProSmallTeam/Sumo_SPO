using System.Collections.Generic;
using System.Linq;

namespace FormTotalMeta
{
    public class PrimaryWeightRanker
    {
        private readonly IList<string> _primaryValues;

        private static readonly List<string> ImportantFields = new List<string> { "ISBN", "Authors" };

        public PrimaryWeightRanker(IList<string> primaryValues)
        {
            _primaryValues = primaryValues;
        }

        public List<string> GetMaxWeightedValue(string key, IEnumerable<IList<string>> values)
        {
            return values
                .Select(v => new { Value = v, Weight = GetWeight(key, v) })
                .OrderByDescending(t => t.Weight)
                .Select(t => t.Value)
                .First()
                .ToList();
        }

        public double GetWeight(string key, IList<string> comparedList)
        {
            return ImportantFields.Contains(key) ?
                2 * DoGetWeight(comparedList) :
                DoGetWeight(comparedList) - (_primaryValues.Count - comparedList.Count);
        }

        private double DoGetWeight(IList<string> comparedList)
        {
            var weight = _primaryValues.Sum(i => LevenshteinDistance.Calculate(i, comparedList));

            return 1 - weight / _primaryValues.Sum(i => i.Length);
        }
    }
}