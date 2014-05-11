using System.Collections.Generic;
using System.Linq;

namespace FormTotalMeta
{
    public static class LevenshteinDistance
    {
        private static int[][] _matrix;

        /// <summary>
        /// Расстояние Левенштейна с учетом транспозиции.
        /// </summary>
        public static double Calculate(string input, string comparedTo, bool caseSensitive = false)
        {
            if (string.IsNullOrWhiteSpace(comparedTo)) 
                return input.Length;

            if (!caseSensitive)
            {
                input = input.ToLower();
                comparedTo = comparedTo.ToLower();
            }

            InitializeMatrixWithDimensions(input.Length, comparedTo.Length);

            FillMatrix(input, comparedTo);

            return _matrix[input.Length - 1][comparedTo.Length - 1];
        }

        /// <summary>
        /// Расстояние Левенштейна с учетом транспозиции.
        /// </summary>
        public static double Calculate(string input, IList<string> comparedTo, bool caseSensitive = false)
        {
            return comparedTo.Select(compared => Calculate(input, compared, caseSensitive)).Min();
        }

        #region Private Methods

        private static void InitializeMatrixWithDimensions(int rowNumber, int columnNumber)
        {
            _matrix = new int[rowNumber][];
            for (var i = 0; i < rowNumber; i++)
            {
                _matrix[i] = new int[columnNumber];
            }

            //первичная инициализация
            for (var i = 0; i < rowNumber; i++) _matrix[i][0] = i;
            for (var i = 0; i < columnNumber; i++) _matrix[0][i] = i;
        }

        private static void FillMatrix(string input, string comparedTo)
        {
            // Заполнение матрицы
            for (var i = 1; i < input.Length; i++)
            {
                for (var j = 1; j < comparedTo.Length; j++)
                {
                    var cost = (input[i - 1] == comparedTo[j - 1]) ? 0 : 1;

                    var above = _matrix[i - 1][j];
                    var left = _matrix[i][j - 1];
                    var diag = _matrix[i - 1][j - 1];
                    _matrix[i][j] = (new[] {above + 1, left + 1, diag + cost}).Min();

                    // транспозиция
                    if (i > 1 && j > 1)
                    {
                        var trans = _matrix[i - 2][j - 2] + 1;
                        if (input[i - 2] != comparedTo[j - 1]) trans++;
                        if (input[i - 1] != comparedTo[j - 2]) trans++;
                        if (_matrix[i][j] > trans) _matrix[i][j] = trans;
                    }
                }
            }
        }

        #endregion
    }
}
