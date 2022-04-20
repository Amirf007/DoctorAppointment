using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Doctors.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Doctors
{
    public class DoctorAppService : DoctorService
    {
        private readonly DoctorRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public DoctorAppService(
            DoctorRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddDoctorDto dto)
        {
            var doctor = new Doctor
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Field = dto.Field,
                NationalCode = dto.NationalCode,
            };

            var isDoctorExist = _repository
                .IsExistNationalCode(doctor.NationalCode,doctor.Id);

            if(isDoctorExist)
            {
                throw new DoctorAlreadyExistException();
            }

            _repository.Add(doctor);
            _unitOfWork.Commit();
        }

        public List<GetDoctorDto> GetAll()
        {
            return _repository.GetAll();
        }

        public GetDoctorDto GetDoctor(int id)
        {
            return _repository.GetDoctor(id);
        }

        public void Update(int id, UpdateDoctorDto dto)
        {
             var doctor= _repository.GetbyId(id);
            if (doctor == null)
            {
                throw new DoctorNotFoundException();
            }

            doctor.Field = dto.Field;
            doctor.NationalCode = dto.NationalCode;
            doctor.FirstName = dto.FirstName;
            doctor.LastName = dto.LastName;

            var isDoctorExist = _repository
                .IsExistNationalCode(dto.NationalCode , doctor.Id);

            if (isDoctorExist)
            {
                throw new DoctorAlreadyExistException();
            }
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var doctor = _repository.GetbyId(id);
            if (doctor == null)
            {
                throw new DoctorNotFoundException();
            }
            _repository.Remove(doctor);
            _unitOfWork.Commit();
        }

    }
}
