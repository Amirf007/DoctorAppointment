using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Appointments.Contracts;
using DoctorAppointment.Services.Doctors.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointments.Exceptions
{
    public class AppointmentAppService : AppointmentService
    {
        private readonly AppointmentRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public AppointmentAppService(
            AppointmentRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddAppointmentDto dto)
        {
            var appointment = new Appointment
            {

                Date = dto.Date,
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,

            };

            if (_repository.IsDuplicateMeeting(dto.Date,dto.DoctorId,dto.PatientId))
            {
                throw new IsDuplicateMeetingException();
            }
            else if(_repository.MoreCapacitydoctorsAppointments
                (dto.Date,dto.DoctorId))
            {
                throw new IsMoreCapacitydoctorsAppointments();
            }
            _repository.Add(appointment);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var appointment = _repository.GetbyId(id);
            if (appointment == null)
            {
                throw new AppointmentNotFoundException();
            }
            _repository.Remove(appointment);
            _unitOfWork.Commit();
        }

        public List<GetAppointmentDto> GetAll()
        {
            return _repository.GetAll();
        }

        public GetAppointmentDto GetAppointment(int id)
        {
            return _repository.GetAppointment(id);
        }
    }
}
