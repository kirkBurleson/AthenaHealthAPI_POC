using System;
using System.Collections.Generic;

namespace DomainModels
{
	public class AthenaClaim
	{
		public InsurancePayer PrimaryInsurancePayer { get; set; }
		public Diagnosis[] Diagnoses { get; set; }
		public InsurancePayer PatientPayer { get; set; }
		public string ClaimCreatedDate { get; set; }
		public Procedure[] Procedures { get; set; }
		public DateTime BilledServiceDate { get; set; }
		public int BilledProviderId { get; set; }
		public int AppointmentId { get; set; }
		public InsurancePayer SecondaryInsurancePayer { get; set; }
		public decimal ChargeAmount { get; set; }
		public Dictionary<int, decimal> TransactionDetails { get; set; }
		public int TransactionId { get; set; }
		public int ClaimId { get; set; }

		public class InsurancePayer
		{
			public string Note { get; set; }
			public string Status { get; set; }
			public InsurancePayer() { }
		}
		public class Diagnosis
		{
			public int DiagnosisId { get; set; }
			public string DiagnosisDescription { get; set; }
			public string DiagnosesRawCode { get; set; }
			public string DiagnosisCategory { get; set; }
			public string DeletedDiagnosis { get; set; }
			public string DiagnosisCodeSet { get; set; }

			public Diagnosis() { }
		}
		public class Procedure
		{
			public string ProcedureCategory { get; set; }
			public decimal AllowableMin { get; set; }
			public string ProcedureDescription { get; set; }
			public decimal ChargeAmount { get; set; }
			public int TransactionId { get; set; }
			public string ProcedureCode { get; set; }
			public decimal AllowableMax { get; set; }
			public decimal AllowableAmount { get; set; }

			public Procedure() { }
		}
	}
}
