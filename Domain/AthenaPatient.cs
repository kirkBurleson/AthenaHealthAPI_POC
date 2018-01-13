namespace DomainModels
{
	public class AthenaPatient
	{
		public AthenaPatient()
		{
			Balances = new AthenaBalance();
			Insurances = new AthenaInsurance();
			PortalStatus = new AthenaPortalStatus();
			CustomFields = new AthenaCustomField();
			ClaimBalanceDetails = new AthenaClaimBalance();
		}

		public int EthnicityCode { get; set; }
		public int IndustryCode { get; set; }
		public string Status { get; set; }
		public bool HomeBoundYN { get; set; }
		public string DeceasedDate { get; set; }
		public bool EmailExistsYN { get; set; }
		public int Language6392Code { get; set; }
		public int OccupationCode { get; set; }
		public string FirstAppointment { get; set; }
		public string LastEmail { get; set; }
		public int PrimaryProviderId { get; set; }
		public int PrimaryDepartmentId { get; set; }
		public string Race { get; set; }
		public string LastAppointment { get; set; }
		public int PatientId { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Suffix { get; set; }
		public string PreferredName { get; set; }
		public string address1 { get; set; }
		public string address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string CountryCode { get; set; }
		public string CountryCode3166 { get; set; }
		public string HomePhone { get; set; }
		public string MobilePhone { get; set; }
		public bool HasMobileYN { get; set; }
		public string WorkPhone { get; set; }
		public string Email { get; set; }
		public string SSN { get; set; }
		public string RaceName { get; set; }
		public string Sex { get; set; }
		public string DOB { get; set; }
		public int MaritalStatus { get; set; }
		public string ContactPreference { get; set; }
		public string ContactName { get; set; }
		public string ContactRelationship { get; set; }
		public string ContactHomePhone { get; set; }
		public string ContactMobilePhone { get; set; }
		public string NextKinName { get; set; }
		public string NextKinRelationship { get; set; }
		public string NextKinPhone { get; set; }
		public string GuardianFirstName { get; set; }
		public string GuardianMiddleName { get; set; }
		public string GuardianLastName { get; set; }
		public string GuardianSuffix { get; set; }
		public string GuarantorFirstName { get; set; }
		public string GuarantorMiddleName { get; set; }
		public string GuarantorLastName { get; set; }
		public string GuarantorSuffix { get; set; }
		public string GuarantorAddress1 { get; set; }
		public string GuarantorAddress2 { get; set; }
		public string GuarantorCity { get; set; }
		public string GuarantorState { get; set; }
		public string GuarantorZip { get; set; }
		public string GuarantorCountryCode { get; set; }
		public string GuarantorCountryCode3166 { get; set; }
		public string GuarantorDOB { get; set; }
		public string GuarantorSSN { get; set; }
		public string GuarantorEmail { get; set; }
		public string GuarantorPhone { get; set; }
		public int GuarantorRelationshipToPatient { get; set; }
		public bool GuarantorAddressSameAsPatient { get; set; }
		public int DepartmentId { get; set; }
		public bool PortalTermsOnFile { get; set; }
		public bool PortalSignatureOnFile { get; set; }
		public bool PrivacyInformationVerified { get; set; }
		public bool MedicationHistoryConsentVerified { get; set; }
		public AthenaBalance Balances { get; set; }
		public string MaritalStatusName { get; set; }
		public int EmployerId { get; set; }
		public string EmployerPhone { get; set; }
		public int GuarantorEmployerId { get; set; }
		public string EmployerName { get; set; }
		public string EmployerAddress { get; set; }
		public string EmployerCity { get; set; }
		public AthenaInsurance Insurances { get; set; }
		public bool PortalAccessGiven { get; set; }
		public string EmployerState { get; set; }
		public bool OnlineStatementOnlyYN { get; set; }
		public string EmployerZip { get; set; }
		public bool ConsentToCall { get; set; }
		public bool ConsentToText { get; set; }
		public int ReferralSourceId { get; set; }
		public string CareSummaryDeliveryPreference { get; set; }
		public string EmployerFax { get; set; }
		public int DefaultPharmacyNCPDPId { get; set; }
		public int MobileCarrierId { get; set; }
		public bool PatientPhotoYN { get; set; }
		public string Notes { get; set; }
		public AthenaPortalStatus PortalStatus { get; set; }
		public string PatientPhotoUrl { get; set; }
		public string PovertyLevelFamilySize { get; set; }
		public int PovertyLevelCalculated { get; set; }
		public bool PovertyLevelFamilySizeDeclined { get; set; }
		public string PovertyLevelIncomePerPayPeriod { get; set; }
		public bool PovertyLevelIncomeDeclined { get; set; }
		public string PovertyLevelIncomePayPeriod { get; set; }
		public bool DriversLicenseYN { get; set; }
		public string AgriculturalWorker { get; set; }
		public string AgriculturalWorkerType { get; set; }
		public string Homeless { get; set; }
		public string HomelessType { get; set; }
		public string Veteran { get; set; }
		public string SchoolBasedHealthCenter { get; set; }
		public string PublicHousing { get; set; }
		public string DriversLicenseUrl { get; set; }
		public AthenaCustomField CustomFields { get; set; }
		public bool ContactPreferenceAnnouncementEmail { get; set; }
		public AthenaClaimBalance ClaimBalanceDetails { get; set; }
		public bool ContactPreferenceAnnouncementSMS { get; set; }
		public bool ContactPreferenceAnnouncementPhone { get; set; }
		public bool ContactPreferenceAppointmentEmail { get; set; }
		public bool ContactPreferenceAppointmentSMS { get; set; }
		public bool ContactPreferenceAppointmentPhone { get; set; }
		public bool ContactPreferenceBillingEmail { get; set; }
		public bool ContactPreferenceBillingSMS { get; set; }
		public bool ContactPreferenceBillingPhone { get; set; }
		public bool ContactPreferenceLabEmail { get; set; }
		public bool ContactPreferenceLabSMS { get; set; }
		public bool ContactPreferenceLabPhone { get; set; }
	}
}
