using DoctorAppointment.Entities;
using DoctorAppointment.Services.Doctors.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Doctors
{
    public class EFDoctorRepository : DoctorRepository
    {
        private readonly DbSet<Doctor> _doctors;

        public EFDoctorRepository(ApplicationDbContext dbcontext)
        {
            _doctors = dbcontext.Set<Doctor>();
        }

        public void Add(Doctor doctor)
        {
           _doctors.Add(doctor);
        }

        public List<GetDoctorDto> GetAll()
        {
            return _doctors.Select(_ => new GetDoctorDto
            {

                Id = _.Id,
                FirstName = _.FirstName,
                LastName = _.LastName,
                NationalCode = _.NationalCode,
                Field = _.Field,

            }).ToList();
        }

        public Doctor GetbyId(int id)
        {
            return _doctors.Find(id);
        }

        public GetDoctorDto GetDoctor(int id)
        {
            return _doctors.Where(_ => _.Id == id).Select(_ => new GetDoctorDto
            {

                Id = _.Id,
                FirstName = _.FirstName,
                LastName= _.LastName,
                NationalCode= _.NationalCode,
                Field= _.Field,

            }).FirstOrDefault();
        }

        public bool IsExistNationalCode(string nationalCode , int id)
        {
            return _doctors.Any(_ => _.NationalCode == nationalCode && _.Id!=id);
        }

        public void Remove(Doctor doctor)
        {
            _doctors.Remove(doctor);
        }
    }
}
