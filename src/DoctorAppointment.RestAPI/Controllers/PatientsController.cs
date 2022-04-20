
using DoctorAppointment.Services.patient.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoctorAppointment.RestAPI.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService _service;

        public PatientsController(PatientService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddPatient(AddPatientDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetPatientDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public GetPatientDto GetDoctor(int id)
        {
            return _service.GetPatient(id);
        }

        [HttpPut("{id}")]
        public void Update(int id, UpdatePatientDto dto)
        {
            _service.Update(id, dto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
