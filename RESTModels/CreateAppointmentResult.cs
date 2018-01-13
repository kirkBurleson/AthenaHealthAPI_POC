using System;
using Newtonsoft.Json.Linq;
using ExtensionMethods;

namespace RESTModels
{
    public class CreateAppointmentResult
    {
        private Tuple<string, string> result;
        public string Error { get { return result.Item1; } }
        public bool HasError() { return string.IsNullOrWhiteSpace(result.Item1); }
        public string Result { get { return result.Item2; } }

        public CreateAppointmentResult(JToken RESTResult)
        {
            if (CreateAppointmentSucceeded(RESTResult))
            {
                result = Tuple.Create("", "appointment created");
            }
            else
            {
                result = Tuple.Create((string)RESTResult["error"], "error");
            }
        }

        private bool CreateAppointmentSucceeded(JToken token)
        {
            return token.IsJTokenArray();
        }
    }
}
