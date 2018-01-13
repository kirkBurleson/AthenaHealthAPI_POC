using Newtonsoft.Json.Linq;

namespace DomainModels
{
    public class Provider
    {
        public string FirstName { get; set; }
        public string Specialty { get; set; }
        public string SchedulingName { get; set; }
        public string ProviderTypeID { get; set; }
        public bool Billable { get; set; }
        public string ANSInameCode { get; set; }
        public string LastName { get; set; }
        public int ProviderID { get; set; }
        public string ANSIspecialtyCode { get; set; }
        public bool HideInPortal { get; set; }
        public string EntityType { get; set; }
        public string ProviderType { get; set; }

        public Provider() { }
        public Provider(JToken token)
        {
            //TODO: Do something or remove this
        }
    }
}