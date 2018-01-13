using System.Collections.Generic;
using ViewModels;
using DomainModels;
using RESTModels;

namespace Mapping
{
	public static class PatientMapper
	{
		public static Dictionary<string, string> MapToPOSTData(Patient patient, string departmentID)
		{
			var result = new Dictionary<string, string>();
			if (!string.IsNullOrWhiteSpace(patient.First))
				result.Add("firstname", patient.First);

			if (!string.IsNullOrWhiteSpace(patient.Last))
				result.Add("lastname", patient.Last);

			if (!string.IsNullOrWhiteSpace(patient.DOB) && patient.DOB != Patient.missingDOB)
				result.Add("dob", patient.DOB);

			if (!string.IsNullOrWhiteSpace(patient.HomePhone))
				result.Add("homephone", patient.HomePhone);

			if (!string.IsNullOrWhiteSpace(patient.Email))
				result.Add("email", patient.Email);

			if (!string.IsNullOrWhiteSpace(patient.GuarantorEmail))
				result.Add("guarantoremail", patient.GuarantorEmail);

			if (!string.IsNullOrWhiteSpace(patient.SSN))
				result.Add("ssn", patient.SSN);

			if (!string.IsNullOrWhiteSpace(patient.ZipCode))
				result.Add("zipcode", patient.ZipCode);

			if (!string.IsNullOrWhiteSpace(departmentID))
			result.Add("departmentid", departmentID);

			return result;
		}

		public static Dictionary<string, string> MapToGETData(Patient patient)
		{
			var result = new Dictionary<string, string>();

			if (!string.IsNullOrWhiteSpace(patient.First))
				result["firstname"] = patient.First;

			if (!string.IsNullOrWhiteSpace(patient.Last))
				result["lastname"] = patient.Last;

			if (patient.ID != Patient.missingPatientID)
				result["patientid"] = patient.ID.ToString();

			if (!string.IsNullOrWhiteSpace(patient.DOB) && patient.DOB != Patient.missingDOB)
				result["dob"] = patient.DOB;

			return result;
		}

		public static Dictionary<string, string> MapToPUTData(Patient patient)
		{
			var result = new Dictionary<string, string>();
			result["firstname"] = patient.First;
			result["lastname"] = patient.Last;
			result["dob"] = patient.DOB;

			return result;
		}

		public static CreatePatientVM MapToCreatePatientVM(Patient patient, CreatePatientResult results)
		{
			var vm = new CreatePatientVM()
			{
				First = patient.First,
				Last = patient.Last,
				Dob = patient.DOB,
				HomePhone = patient.HomePhone,
				Email = patient.Email,
				GuarantorEmail = patient.GuarantorEmail,
				SSN = patient.SSN,
				ZipCode = patient.ZipCode				
			};

			vm.Error = results.Error;
			vm.Id = results.Result.ToString();

			return vm;
		}

		public static SearchForPatientVM MapToSearchForPatientVM(IList<IDictionary<string, string>> patients)
		{
			var result = new SearchForPatientVM()
			{
				SearchResults = patients
			};

			return result;
		}

		public static UpdatePatientVM MapToUpdatePatientVM(string patientId)
		{
			return new UpdatePatientVM() { UpdateResult = patientId };
		}
	}

	public static class CreatePatientVMMapper
	{
		public static Patient MapToPatient(CreatePatientVM vm)
		{
			var patient = new Patient()
			{
				First = vm.First,
				Last = vm.Last,
				DOB = vm.Dob,
				HomePhone = vm.HomePhone,
				Email = vm.Email,
				GuarantorEmail = vm.GuarantorEmail,
				SSN = vm.SSN,
				ZipCode = vm.ZipCode
			};
			int id = -1;

			int.TryParse(vm.Id, out id);
			patient.ID = id;

			return patient;
		}
	}

	public static class SearchForPatientVMMapper
	{
		public static Patient MapToPatient(SearchForPatientVM vm)
		{
			var patient = new Patient() { First = vm.First, Last = vm.Last, DOB = vm.Dob };

			return patient;
		}
	}

	public static class UpdatePatientVMMapper
	{
		public static Patient MapToPatient(UpdatePatientVM vm)
		{
			var patient = new Patient() { };

			var firstname = "";
			vm.Patient.TryGetValue("firstname", out firstname);
			if (!string.IsNullOrEmpty(firstname))
			{
				patient.First = firstname;
			}

			var lastname = "";
			vm.Patient.TryGetValue("lastname", out lastname);
			if (!string.IsNullOrEmpty(lastname))
			{
				patient.Last = lastname;
			}

			var dob = "";
			vm.Patient.TryGetValue("dob", out dob);
			if (!string.IsNullOrEmpty(dob))
			{
				patient.DOB = dob;
			}

			var id = -1;
			int.TryParse(vm.Id, out id);
			patient.ID = id;

			return patient;
		}
	}
}
