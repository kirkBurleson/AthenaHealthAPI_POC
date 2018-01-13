namespace DomainModels
{
	public class AthenaBalance
	{
		public AthenaBalance()
		{
			Contracts = new AthenaContract();
		}

		public int ProviderGroupId { get; set; }
		public string DepartmentIds { get; set; }
		public string Balance { get; set; }
		public string CleanBalance { get; set; }
		public AthenaContract Contracts { get; set; }
		public string CollectionsBalance { get; set; }
		public string PaymentPlanBalance { get; set; }

		public class AthenaContract
		{
			public string AvailableBalance { get; set; }
			public int ContractClass { get; set; }
			public string MaxAmount { get; set; }
		}
	}
}
