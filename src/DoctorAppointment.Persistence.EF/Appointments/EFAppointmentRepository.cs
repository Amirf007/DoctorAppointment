using DoctorAppointment.Entities;
using DoctorAppointment.Services.Appointments.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Appointments
{
    public class EFAppointmentRepository : AppointmentRepository
    {

        private readonly DbSet<Appointment> _appointments;

        public EFAppointmentRepository(ApplicationDbContext dbcontext)
        {
            _appointments = dbcontext.Set<Appointment>();
        }

        public void Add(Appointment appointment)
        {
          _appointments.Add(appointment);  
        }

        public List<GetAppointmentDto> GetAll()
        {
            return _appointments.Select(_ => new GetAppointmentDto
            {

                Id = _.Id,
               Date = _.Date,
               DoctorId = _.DoctorId,
               PatientId = _.PatientId,

            }).ToList();
        }

        public GetAppointmentDto GetAppointment(int id)
        {
            return _appointments.Where(_ => _.Id == id).Select(_ => new GetAppointmentDto
            {

                Id = _.Id,
                Date = _.Date,
                DoctorId= _.DoctorId,
                PatientId= _.PatientId,

            }).FirstOrDefault();
        }

        public Appointment GetbyId(int id)
        {
           return  _appointments.Find(id);
        }

        public void Remove(Appointment Appointment)
        {
            _appointments.Remove(Appointment);
        }

        public bool IsDuplicateMeeting
            (DateTime date , int doctorid , int patientid)
        {
            return _appointments.Any(_ => _.Date == date
            && _.DoctorId == doctorid && _.PatientId == patientid);
        }

        public bool MoreCapacitydoctorsAppointments
            (DateTime appointmenttime , int doctorid)
        {
          return _appointments
                .Count(_ => _.Date == appointmenttime && _.DoctorId == doctorid)>4;
        }
    }
}
