using System.Collections.Generic;
using System.Linq;

namespace FormTotalMeta
{
    public class SingleValueWeightRanker
    {
        private readonly PrimaryWeightRanker _ranker;

        public SingleValueWeightRanker(string primaryValue)
        {
            _ranker = new PrimaryWeightRanker(new List<string> {primaryValue});
        }

        public string GetMaxWeightedValue(IList<string> values)
        {
            return _ranker.GetMaxWeightedValue(string.Empty, new List<IList<string>> {values}).First();
        }

        public double GetWeight(string compared)
        {
            return _ranker.GetWeight(string.Empty, new List<string> { compared });
        }
    }
}