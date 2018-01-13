using System;
using Newtonsoft.Json.Linq;
using ExtensionMethods;

namespace RESTModels
{
	public class CreatePatientResult
	{
		private Tuple<string, int> result;
		public string Error { get { return result.Item1; } }
		public bool HasError() { return string.IsNullOrWhiteSpace(result.Item1); }
		public int Result { get { return result.Item2; } }

		public CreatePatientResult(JToken RESTResult)
		{
			if (CreatePatientSucceeded(RESTResult))
			{
				result = Tuple.Create("", (int)RESTResult[0]["patientid"]);
			}
			else
			{
				result = Tuple.Create((string)RESTResult["error"], -1);
			}
		}

		private bool CreatePatientSucceeded(JToken token)
		{
			return token.IsJTokenArray();
		}
	}
}
