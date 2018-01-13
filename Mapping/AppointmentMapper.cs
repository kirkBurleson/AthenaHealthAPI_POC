using System.Collections.Generic;
using DomainModels;
using TransferModels;
using System;
using ViewModels;
using RESTModels;

namespace Mapping
{
    public class AppointmentMapper
    {
        public static AppointmentSlotsInput MapToAppointmentSlotsInput(Appointment appointment)
        {
            throw new NotImplementedException();
        }
        public static AppointmentReasonsInput MapToAppointmentReasonInput(CreateAppointmentVM vm)
        {
            var retval = new AppointmentReasonsInput();
            retval.DepartmentID = int.Parse(vm.DepartmentID);
            retval.ProviderID = int.Parse(vm.ProviderID);
            retval.ProviderType = vm.ProviderType;

            return retval;
        }
        public static Dictionary<string, string> MapToAppointmentSlotsPOSTData()
        {
            return new Dictionary<string, string>();
        }
        public static Dictionary<string, string> MapToAppointmentReasonsPOSTData(string providerId)
        {
            var retval = new Dictionary<string, string>();
            retval.Add("departmentid", "1");
            retval.Add("providerid", providerId);

            return retval;
        }
        public static Dictionary<string, string> MapToPOSTData(Appointment appointment, string departmentID)
        {
            var data = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(departmentID))
                data.Add("departmentid", departmentID);

            data.Add("patientid", appointment.PatientID.ToString());

            return data;
        }
        public static CreateAppointmentVM MapToCreateAppointmentVM(Appointment appointment, CreateAppointmentResult result)
        {
            var retval = new CreateAppointmentVM();

            //TODO: should be doing something here
            return retval;
        }

    }

    public class CreateAppointmentVMMapper
    {
        public static Appointment MapToAppointment(CreateAppointmentVM vm)
        {
            var patientID = -1;
            var departmentID = -1;

            int.TryParse(vm.PatientID, out patientID);
            int.TryParse(vm.DepartmentID, out departmentID);

            var appointment = new Appointment((int.Parse(vm.ProviderID)))
            {
                PatientID = patientID,
                DepartmentID = departmentID
            };

            return appointment;
        }
    }
}