
namespace TransferModels
{
    public class AppointmentSlotsInput
    {
        public string AppointmentDate { get; set; }
        public string[] AppointmentTime { get; set; }
        public int AppointmentTypeID { get; set; }
        public int DepartmentID { get; set; }
        public int ProviderID { get; set; }
        public int ReasonID { get; set; }

        public AppointmentSlotsInput() { }
    }
}
