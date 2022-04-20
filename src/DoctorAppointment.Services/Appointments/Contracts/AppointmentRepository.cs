using System;
using DoctorAppointment.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments.Contracts
{
    public interface AppointmentRepository
    {
        void Add(Appointment appointment);
        List<GetAppointmentDto> GetAll();
        GetAppointmentDto GetAppointment(int id);
        Appointment GetbyId(int id);
        void Remove(Appointment Appointment);
        bool IsDuplicateMeeting(DateTime date, int doctorid, int patientid);
        bool MoreCapacitydoctorsAppointments
            (DateTime appointmenttime, int doctorid);

    }
}
