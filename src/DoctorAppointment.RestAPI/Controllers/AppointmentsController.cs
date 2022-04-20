using DoctorAppointment.Services.Appointments.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoctorAppointment.RestAPI.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _service;

        public AppointmentsController(AppointmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddAppointment(AddAppointmentDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetAppointmentDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public GetAppointmentDto GetAppointment(int id)
        {
            return _service.GetAppointment(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
