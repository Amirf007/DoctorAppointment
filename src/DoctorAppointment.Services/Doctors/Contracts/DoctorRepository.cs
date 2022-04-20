using DoctorAppointment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Doctors.Contracts
{
    public interface DoctorRepository 
    {
        void Add(Doctor doctor);
        bool IsExistNationalCode(string nationalCode , int id);
        List<GetDoctorDto> GetAll();
        GetDoctorDto GetDoctor(int id);
        Doctor GetbyId(int id);
        void Remove(Doctor doctor);
    }
}
