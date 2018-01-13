using System.Collections.Generic;
using Interfaces;

namespace ViewModels
{
	public class UpdatePatientVM : IServiceInput, IServiceResult
	{
		private string[] keys = { "firstname", "lastname", "dob" };

		public IDictionary<string, string> Patient { get; set; }
		public string Id { get; set; }
		public string UpdateResult { get; set; }

		public UpdatePatientVM()
		{
			Patient = new Dictionary<string, string>();
			InitPatientKeys();
			UpdateResult = "No Results";
		}

		public IList<string> getPatientFields()
		{
			return new List<string>(keys);
		}

		private void InitPatientKeys()
		{
			foreach (var key in keys)
			{
				Patient.Add(key, "");
			}
		}
	}
}
