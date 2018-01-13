namespace DomainModels
{
    public class Appointment
    {
        private int _providerID;

        public int AppointmentID { get; set; }
        public int AppointmentTypeID { get; set; }
        public string BookingNote { get; set; }
        public int DepartmentID { get; set; }
        public bool DoNotSendConfirmationEmail { get; set; }
        public bool IgnoreScheduleablePermission { get; set; }
        public AthenaInsurance InsuranceInfo { get; set; }
        public bool NoPatientCase { get; set; }
        public int PatientID { get; set; }
        public int ReasonID { get; set; }
        public bool UrgentYN { get; set; }

        public Appointment(int providerID)
        {
            _providerID = providerID;
        }
    }
}
