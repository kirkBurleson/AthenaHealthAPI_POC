using System.Collections.Generic;
using Interfaces;

namespace ViewModels
{
	public class SearchForPatientVM : IServiceInput, IServiceResult
	{
		public string First { get; set; }
		public string Last { get; set; }
		public string Dob { get; set; }
		public string Id { get; set; }

		public IList<IDictionary<string, string>> SearchResults { get; set; }

		public SearchForPatientVM()
		{
			Id = "unknown";
			SearchResults = new List<IDictionary<string, string>>();
		}
	}
}
