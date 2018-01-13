using System;


namespace DomainModels
{
    public class Patient
    {
        private DateTime dob;

		public const int missingPatientID = -1;
		public const string missingDOB = "1/1/0001";

		public string First { get; set; }
        public string Last { get; set; }
		public string HomePhone { get; set; }
		public string Email { get; set; }
		public string GuarantorEmail { get; set; }
		public string SSN { get; set; }
		public string ZipCode { get; set; }
		public int ID { get; set; }
        public string DOB {
            get
            {
                return dob.ToShortDateString();
            }

            set
            {
				dob = Convert.ToDateTime(value);
            }
        }

        public Patient()
        {
            ID = missingPatientID;
            DOB = missingDOB;
        }
    }
}