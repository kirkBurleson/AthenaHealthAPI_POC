namespace RESTModels
{
	public class CreateAppointmentInput
	{
		public string PatientID { get; set; }
		public string ReasonID { get; set; }
		public string AppointmentID { get; set; }
		public bool IsPartOfBulk { get; set; }

		public CreateAppointmentInput() { }
	}
}
