using System;
using Newtonsoft.Json.Linq;
using Mapping;
using ViewModels;
using DomainModels;
using TransferModels;
using RESTModels;
using Interfaces;

namespace Services
{
    public class AppointmentService : IAthenaService
    {
        private APIConnection api;
        private IAthenaService providerService;

        public AppointmentService()
        {
            api = new APIConnection();
            providerService = new ProviderService();
        }

        public IServiceResult Create(IServiceInput input)
        {
            var vm = input as CreateAppointmentVM;

            //var providers = providerService.Search(new ProviderSearchInput());

            //TODO: pass in provider ID


            var apptReasons = GetAppointmentReasons(vm.ProviderID);
            //var apptSlots = GetAppointmentSlots();
            
            // map patient
            Appointment appointment = CreateAppointmentVMMapper.MapToAppointment(vm);

            // call core method
            CreateAppointmentResult retval = Create(appointment, vm.DepartmentID);

            // return mapped result
            return AppointmentMapper.MapToCreateAppointmentVM(appointment, retval);
        }
        public IServiceResult Search(IServiceInput input)
        {
            throw new NotImplementedException();
        }
        public IServiceResult Update(IServiceInput input)
        {
            throw new NotImplementedException();
        }

        private CreateAppointmentResult Create(Appointment appointment, string departmentID)
        {
            var postData = AppointmentMapper.MapToPOSTData(appointment, departmentID);
            var restUrl = "/appointments";

            JToken action = api.POST(restUrl, postData);

            return GetCreateResults(action);
        }

        private AppointmentReasonsResult GetAppointmentReasons(string providerID)
        {
            var postData = AppointmentMapper.MapToAppointmentReasonsPOSTData(providerID);
            var restUrl = "/patientappointmentreasons ";

            JToken action = api.GET(restUrl, postData);

            return GetReasonsResults(action);
        }
        private AppointmentSlotsResult GetAppointmentSlots()
        {
            var postData = AppointmentMapper.MapToAppointmentSlotsPOSTData();
            var restUrl = "/appointments/open";

            JToken action = api.POST(restUrl, postData);

            return GetSearchResults(action);
        }
        

        private CreateAppointmentResult GetCreateResults(JToken action)
        {
            return new CreateAppointmentResult(action);
        }
        private AppointmentSlotsResult GetSearchResults(JToken action)
        {
            return new AppointmentSlotsResult(action);
        }
        private AppointmentReasonsResult GetReasonsResults(JToken action)
        {
            return new AppointmentReasonsResult(action);
        }

    }
}
