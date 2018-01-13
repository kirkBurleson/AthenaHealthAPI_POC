using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Mapping;
using ViewModels;
using DomainModels;
using RESTModels;
using ExtensionMethods;
using Interfaces;

namespace Services
{
    public class PatientService : IPatientService
    {
        private APIConnection api;

        public PatientService(APIConnection apiConnection)
        {
            api = apiConnection;
        }

        public IServiceResult Create(IServiceInput input)
        {
            var vm = input as CreatePatientVM;

            // map patient
            Patient patient = CreatePatientVMMapper.MapToPatient(vm);

            // call core method
            CreatePatientResult retval = Create(patient, vm.DepartmentID);

            // return mapped result
            return PatientMapper.MapToCreatePatientVM(patient, retval);
        }
        public IServiceResult Search(IServiceInput input)
        {
            var vm = input as SearchForPatientVM;

            // map patient
            var patient = SearchForPatientVMMapper.MapToPatient(vm);

            // call core method
            var retval = Retrieve(patient);

            //return mapped result
            return PatientMapper.MapToSearchForPatientVM(retval);
        }
        public IServiceResult Update(IServiceInput input)
        {
            var vm = input as UpdatePatientVM;

            // map patient
            var patient = UpdatePatientVMMapper.MapToPatient(vm);

            // call core method
            var retval = Update(patient);

            // return mapped result
            return PatientMapper.MapToUpdatePatientVM(retval);
        }

        private CreatePatientResult Create(Patient patient, string departmentID)
        {
            var postData = PatientMapper.MapToPOSTData(patient, departmentID);
            var restUrl = "/patients";

            JToken action = api.POST(restUrl, postData);

            return GetCreateResults(action);
        }
        private IList<IDictionary<string, string>> Retrieve(Patient patient)
        {
            var patientInfo = PatientMapper.MapToGETData(patient);
            var restUrl = "/patients";

            JToken action = api.GET(restUrl, patientInfo);

            return GetSearchResults(action);
        }
        private string Update(Patient patient)
        {
            var putData = PatientMapper.MapToPUTData(patient);
            var restUrl = string.Format("/patients/{0}", patient.ID);

            JToken action = api.PUT(restUrl, putData);

            return GetUpdateResults(action);
        }

        private IList<IDictionary<string, string>> GetSearchResults(JToken action)
        {
            IList<IDictionary<string, string>> results = new List<IDictionary<string, string>>();

            if (SearchSucceeded(action))
            {
                foreach (var item in action["patients"])
                {
                    IDictionary<string, string> currentPatient = new Dictionary<string, string>();
                    currentPatient.Add("firstname", (string)item["firstname"]);
                    currentPatient.Add("lastname", (string)item["lastname"]);
                    currentPatient.Add("dob", (string)item["dob"]);
                    currentPatient.Add("patientid", (string)item["patientid"]);
                    results.Add(currentPatient);
                }
            }

            return results;
        }
        private CreatePatientResult GetCreateResults(JToken action)
        {
            return new CreatePatientResult(action);
        }
        private string GetUpdateResults(JToken action)
        {
            if (UpdateSucceeded(action))
            {
                return (string)action[0]["patientid"];
            }

            return (string)action["error"];
        }

        private bool UpdateSucceeded(JToken token)
        {
            return token.IsJTokenArray();
        }
        private bool SearchSucceeded(JToken action)
        {
            return (int)action["totalcount"] > 0;
        }
    }
}
