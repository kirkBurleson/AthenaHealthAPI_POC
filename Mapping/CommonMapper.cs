using System.Text;
using ExtensionMethods;

namespace Mapping
{
    public class CommonMapper
    {
        public static string MapStringArraryToCSV(string[] strings)
        {
            var builder = new StringBuilder(100);

            foreach (var time in strings)
            {
                if (!string.IsNullOrWhiteSpace(time))
                {
                    builder.Append(time);
                    builder.Append(",");
                }
            }

            builder.RemoveTrailingComma();
            return builder.ToString();
        }
    }
}
