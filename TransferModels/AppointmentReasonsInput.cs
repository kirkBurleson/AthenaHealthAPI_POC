
namespace TransferModels
{
    public class AppointmentReasonsInput
    {
        public int DepartmentID { get; set; }
        public int ProviderID { get; set; }
        public string ProviderType { get; set; }

        public AppointmentReasonsInput()
        {
            //TODO: fill in providerID with static value
        }

    }
}
