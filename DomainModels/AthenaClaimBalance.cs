using System;

namespace DomainModels
{
	public class AthenaClaimBalance
	{
		public AthenaClaimBalance()
		{
			ClaimDetails = new ClaimDetail();
		}

		public ClaimDetail ClaimDetails { get; set; }
		public double ProviderGroupId { get; set; }
		public string DepartmentIds { get; set; }

		public class ClaimDetail
		{
			public ClaimDetail()
			{
				ChargeLevelDetail = new ChargeLevel();
			}

			public ChargeLevel ChargeLevelDetail { get; set; }
			public string CleanBalance { get; set; }
			public double Amount { get; set; }
			public DateTime ServiceDate { get; set; }
			public double SupervisingProviderId { get; set; }
			public double DepartmentId { get; set; }
			public double ClaimId { get; set; }
			public double PatientBalance { get; set; }

			public class ChargeLevel
			{
				public ChargeLevel()
				{
					Transactions = new Transaction();
				}

				public DateTime ServiceData { get; set; }
				public Transaction Transactions { get; set; }
				public double Id { get; set; }
				public double Amount { get; set; }
				public string Description { get; set; }

				public class Transaction
				{
					public DateTime Date { get; set; }
					public double Id { get; set; }
					public double Amount { get; set; }
					public string Type { get; set; }
					public double EpaymentId { get; set; }
					public double Description { get; set; }
					public string TransferType { get; set; }
				}
			}
		}
	}
}
