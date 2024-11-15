using AssessmentEmpleabilidad.DTOs;
using Microsoft.AspNetCore.Mvc;
using AssessmentEmpleabilidad.Repositories;

namespace AssessmentEmpleabilidad.Controllers.v1.Patient
{
    [ApiController]
    [Route("api/v1/patients")]
    [Tags("patients")]
    public class PatientController : ControllerBase
    {
        protected readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
    }
}
