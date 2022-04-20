﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.patient.Contract
{
    public class GetPatientDto
    {
        public int Id { get; set; }
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
