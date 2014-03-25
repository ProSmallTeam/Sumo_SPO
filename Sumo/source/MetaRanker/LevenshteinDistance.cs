using System.Collections.Generic;
using System.Linq;

namespace MetaRanker
{
    public static class LevenshteinDistance
    {
        /// <summary>
        /// Расстояние Левенштейна с учетом транспозиции.
        /// </summary>
        public static int GetLevenshteinDistance(string input, string comparedTo, bool caseSensitive = false)
        {
            if (string.IsNullOrWhiteSpace(comparedTo)) 
                return input.Length;

            if (!caseSensitive)
            {
                input = input.ToLower();
                comparedTo = comparedTo.ToLower();
            }

            var inputLen = input.Length;
            var comparedToLen = comparedTo.Length;

            var matrix = new int[inputLen, comparedToLen];

            //первичная инициализация
            for (var i = 0; i < inputLen; i++) matrix[i, 0] = i;
            for (var i = 0; i < comparedToLen; i++) matrix[0, i] = i;

            //сравнение
            for (var i = 1; i < inputLen; i++)
            {
                var si = input[i - 1];
                for (var j = 1; j < comparedToLen; j++)
                {
                    var tj = comparedTo[j - 1];
                    var cost = (si == tj) ? 0 : 1;

                    var above = matrix[i - 1, j];
                    var left = matrix[i, j - 1];
                    var diag = matrix[i - 1, j - 1];
                    var cell = (new[] {above + 1, left + 1, diag + cost}).Min();

                    // транспозиция
                    if (i > 1 && j > 1)
                    {
                        var trans = matrix[i - 2, j - 2] + 1;
                        if (input[i - 2] != comparedTo[j - 1]) trans++;
                        if (input[i - 1] != comparedTo[j - 2]) trans++;
                        if (cell > trans) cell = trans;
                    }
                    matrix[i, j] = cell;
                }
            }
            return matrix[inputLen - 1, comparedToLen - 1];
        }

        /// <summary>
        /// Расстояние Левенштейна с учетом транспозиции.
        /// </summary>
        public static int GetLevenshteinDistance(string input, IList<string> comparedTo, bool caseSensitive = false)
        {
            return comparedTo.Select(compared => GetLevenshteinDistance(input, compared)).ToList().Min();
        }
    }
}
