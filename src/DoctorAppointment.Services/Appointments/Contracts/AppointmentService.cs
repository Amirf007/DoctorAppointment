using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments.Contracts
{
    public interface AppointmentService
    {
        void Add(AddAppointmentDto dto);
        List<GetAppointmentDto> GetAll();
        GetAppointmentDto GetAppointment(int id);
        void Delete(int id);
    }
}
