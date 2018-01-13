namespace DomainModels
{
	public class AthenaPortalStatus
	{
		public AthenaPortalStatus() { }

		public string LastLoginEntity { get; set; }
		public bool FamilyRegisteredYN { get; set; }
		public bool NoPortalYN { get; set; }
		public string PortalRegistrationDate { get; set; }
		public string EntityToDisplay { get; set; }
		public bool TermsAccepted { get; set; }
		public bool RegisteredYN { get; set; }
		public bool BlockedFailedLoginsYN { get; set; }
		public string LastLoginDate { get; set; }
		public bool FamilyBlockedFailedLoginYN { get; set; }
		public string Status { get; set; }
	}
}
