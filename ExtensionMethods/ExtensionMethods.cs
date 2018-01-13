using System.Text;
using Newtonsoft.Json.Linq;

namespace ExtensionMethods
{
	public static class ExtensionMethods
	{
		public static bool IsJTokenArray(this JToken token)
		{
			return token.Type == JTokenType.Array;
		}

		public static void RemoveTrailingComma(this StringBuilder builder)
		{
			if (builder.Length > 0)
			{
				builder.Remove(builder.Length, 1);
			}
		}
	}
}
