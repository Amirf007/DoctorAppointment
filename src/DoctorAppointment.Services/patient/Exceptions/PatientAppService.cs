using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.patient.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.patient.Exceptions
{
    public class PatientAppService : PatientService
    {
        private readonly PatientRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public PatientAppService(
            PatientRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddPatientDto dto)
        {
            var patient = new Patient
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                NationalCode = dto.NationalCode,
            };

            var isPatientExist = _repository
                .IsExistNationalCode(patient.NationalCode , patient.Id);

            if (isPatientExist)
            {
                throw new PatientNotFoundException();
            }

            _repository.Add(patient);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var patient = _repository.GetbyId(id);
            if (patient == null)
            {
                throw new PatientNotFoundException();
            }
            _repository.Remove(patient);
            _unitOfWork.Commit();
        }

        public List<GetPatientDto> GetAll()
        {
            return _repository.GetAll();
        }

        public GetPatientDto GetPatient(int id)
        {
            return _repository.GetPatient(id);
        }

        public void Update(int id, UpdatePatientDto dto)
        {
            var patient = _repository.GetbyId(id);
            if (patient == null)
            {
                throw new PatientNotFoundException();
            }

            patient.NationalCode = dto.NationalCode;
            patient.FirstName = dto.FirstName;
            patient.LastName = dto.LastName;

            var isDoctorExist = _repository
                .IsExistNationalCode(dto.NationalCode, patient.Id);

            if (isDoctorExist)
            {
                throw new PatientAlreadyExistException();
            }
            _unitOfWork.Commit();
        }
    }
}
