using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TransferModels
{
    public class AppointmentSlotsResult
    {
        private Dictionary<DateTime, int> appointmentSlots;
        private Tuple<string, Dictionary<DateTime, int>> result;

        public string Error { get { return result.Item1; } }
        public bool HasError() { return string.IsNullOrWhiteSpace(result.Item1); }
        public Dictionary<DateTime, int> Result { get { return result.Item2; } }

        public AppointmentSlotsResult(JToken token)
        {

        }
    }
}
