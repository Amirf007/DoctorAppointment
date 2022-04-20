using DoctorAppointment.Entities;
using DoctorAppointment.Services.patient.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Patients
{
    public class EFPatientRepository : PatientRepository
    {
        private readonly DbSet<Patient> _patients;

        public EFPatientRepository(ApplicationDbContext dbcontext)
        {
            _patients = dbcontext.Set<Patient>();
        }

        public void Add(Patient patient)
        {
            _patients.Add(patient);
        }

        public List<GetPatientDto> GetAll()
        {
            return _patients.Select(_ => new GetPatientDto
            {

                Id = _.Id,
                FirstName = _.FirstName,
                LastName = _.LastName,
                NationalCode = _.NationalCode,

            }).ToList();
        }

        public Patient GetbyId(int id)
        {
            return _patients.Find(id);
        }

        public GetPatientDto GetPatient(int id)
        {
            return _patients.Where(_ => _.Id == id).Select(_ => new GetPatientDto
            {

                Id = _.Id,
                FirstName = _.FirstName,
                LastName = _.LastName,
                NationalCode = _.NationalCode,

            }).FirstOrDefault();
        }

        public bool IsExistNationalCode(string nationalCode , int id)
        {
            return _patients.Any(_ => _.NationalCode == nationalCode && _.Id!=id);
        }

        public void Remove(Patient patient)
        {
            _patients.Remove(patient);
        }
    }
}
