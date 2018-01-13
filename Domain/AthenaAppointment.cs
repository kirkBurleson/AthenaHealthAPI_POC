using System;

namespace DomainModels
{
	public class AthenaAppointment
	{
		public int AppointmentId { get; set; }
		public string AppointmentStatus { get; set; }
		public string AppointmentType { get; set; }
		public string Copay { get; set; }
		public int RescheduledAppointmentId { get; set; }
		public int Duration { get; set; }
		public DateTime Date { get; set; }
		public int ReferringProviderId { get; set; }
		public string PatientAppointmentTypeName { get; set; }
		public int PatientId { get; set; }
		public DateTime StopCheckin { get; set; }
		public int ProvederId { get; set; }
		public AthenaPatient Patient { get; set; }
		public int RenderingProviderId { get; set; }
		public AthenaProcedureCode[] UseExpectedProcedureCodes { get; set; }
		public int DepartmentId { get; set; }
		public AthenaClaim Claims { get; set; }
		public AthenaInsurance[] Insurances { get; set; }
        public bool UrgentYN { get; set; }
        public bool FrozenYN { get; set; }
        public DateTime StartCheckin { get; set; }
        public int AppointmentTypeId { get; set; }
        public DateTime StartTime { get; set; }

        public AthenaAppointment() { }
	}
}
