using System.IO;
using System.Text;

namespace Sumo.Test.Utilities
{
    public static class StringUtils
    {
        public static string RemoveWhiteSpaces(this string str)
        {
            var builder = new StringBuilder();
            using (var stream = new StringReader(str))
            {
                for (; ; )
                {
                    var line = stream.ReadLine();
                    if (line == null) break;

                    builder.Append(line.Trim());

                }
            }

            return builder.ToString();
        }
    }
}