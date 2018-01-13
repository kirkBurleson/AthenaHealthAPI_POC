using System;

namespace DomainModels
{
	public class AthenaInsurance
	{
		public AthenaInsurance() { }

		public string EligibilityMessage { get; set; }
		public string EligibilityReason { get; set; }
		public int InsurancePackageId { get; set; }
		public string EligibilityStatus { get; set; }
		public int InsuranceId { get; set; }
		public string InsurancePolicyHolder { get; set; }
		public string InsurancePolicyHolderAddress1 { get; set; }
		public string InsurancePolicyHolderAddress2 { get; set; }
		public string InsurancePolicyHolderCity { get; set; }
		public string InsurancePolicyHolderCountryCode { get; set; }
		public string InsurancePolicyHolderCountryISO3166 { get; set; }
		public string InsurancePolicyHolderFirstName { get; set; }
		public string InsurancePolicyHolderLastName { get; set; }
		public string InsurancePolicyHolderMiddleName { get; set; }
		public string InsurancePolicyHolderSex { get; set; }
		public string InsurancePolicyHolderSSN { get; set; }
		public string InsurancePhone { get; set; }
		public string InsurancePolicyHolderDOB { get; set; }
		public string InsurancePolicyHolderState { get; set; }
		public string InsurancePolicyHolderSuffix { get; set; }
		public string RelationshipToInsured { get; set; }
		public string CCMStatusName { get; set; }
		public int SequenceNumber { get; set; }
		public string InsuranceType { get; set; }
		public DateTime ExpirationDate { get; set; }
		public string InsuranceIdNumber { get; set; }
		public string InsurancePolicyHolderZip { get; set; }
		public string PolicyNumber { get; set; }
		public string IRCName { get; set; }
		public int SlidingFeePlanId { get; set; }
		public string InsurancePlanName { get; set; }
		public DateTime EligibilityLastChecked { get; set; }
		public int RelationshipToInsuredId { get; set; }
		public int CCMStatusId { get; set; }
		public int InsuredEntityTypeId { get; set; }
		public DateTime IssueDate { get; set; }
	}
}
