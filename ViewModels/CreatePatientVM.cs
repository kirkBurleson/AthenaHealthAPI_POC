using Interfaces;

namespace ViewModels
{
	public class CreatePatientVM : IServiceResult, IServiceInput
	{
		public string First { get; set; }
		public string Last { get; set; }
		public string Dob { get; set; }
		public string Id { get; set; }
		public string HomePhone { get; set; }
		public string Email { get; set; }
		public string GuarantorEmail { get; set; }
		public string SSN { get; set; }
		public string ZipCode { get; set; }
		public string Error { get; set; }
		public string DepartmentID { get; set; }

		public CreatePatientVM() {}
	}
}
