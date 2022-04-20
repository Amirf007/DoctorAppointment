using DoctorAppointment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.patient.Contract
{
    public interface PatientRepository
    {
        void Add(Patient patient);
        bool IsExistNationalCode(string nationalCode, int id);
        List<GetPatientDto> GetAll();
        GetPatientDto GetPatient(int id);
        Patient GetbyId(int id);
        void Remove(Patient patient);
    }
}
