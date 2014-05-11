using NUnit.Framework;

namespace FormTotalMeta.Tests
{
    [TestFixture]
    class LevenshteinDistanceTests
    {
        private const string anyNotEmptyString = "abcde";
        
        [Test]
        public void LevenshteinDistanceNotEmptyAndEmptyString()
        {
            var levenshteinDistance = LevenshteinDistance.Calculate(anyNotEmptyString, string.Empty);

            Assert.AreEqual(anyNotEmptyString.Length, levenshteinDistance);
        }

        [Test]
        public void LevenshteinDistanceWithTranspositionChar()
        {
            var levenshteinDistance = LevenshteinDistance.Calculate(anyNotEmptyString, "abced");

            Assert.AreEqual(1, levenshteinDistance);
        }

        [Test]
        public void LevenshteinDistanceWithReplaceChar()
        {
            var levenshteinDistance = LevenshteinDistance.Calculate(anyNotEmptyString, "bbcde");

            Assert.AreEqual(1, levenshteinDistance);
        }

        [Test]
        public void LevenshteinDistanceWithRemoveChar()
        {
            var levenshteinDistance = LevenshteinDistance.Calculate(anyNotEmptyString, "abcd");

            Assert.AreEqual(1, levenshteinDistance);
        }
    }
}
