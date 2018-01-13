using System.Collections.Generic;
using System.Web.Mvc;
using Interfaces;

namespace ViewModels
{
	public class CreateAppointmentVM : IServiceInput, IServiceResult
	{
		private List<int> _providerIDs;
		private List<string> _providerNames;

		public string DepartmentID { get; set; }
		public string PatientID { get; set; }
		public string ProviderID { get; set; }
		public string ProviderType { get; set; }

		public CreateAppointmentVM()
		{
			_providerIDs = new List<int>();
			_providerNames = new List<string>();
		}

		public IEnumerable<SelectListItem> ProviderListItems
		{
			get { return new SelectList(_providerIDs); }
		}

		public IEnumerable<SelectListItem> ProviderNamesListItems
		{
			get { return new SelectList(_providerNames); }
		}

		public IEnumerable<int> ProviderIDs
		{
			get { return _providerIDs; }

			set { _providerIDs = (List<int>)value; }
		}

		public IEnumerable<string> ProviderNames
		{
			get { return _providerNames; }

			set { _providerNames = (List<string>)value; }
		}
	}
}
