using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssessmentEmpleabilidad.Controllers.v1.Patient
{
    [ApiController]
    [Route("api/v1/patients")]
    [Tags("patients")]
    public class PatientGetController : PatientController
    {
        public PatientGetController(IPatientRepository patientRepository) : base(patientRepository)
        {
        }

        // GET: api/patients
        [HttpGet]
        [SwaggerOperation(
        Summary = "Retrieves a list of patients",
        Description = "Gets all doctors from the database."
        )]
        [Authorize]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _patientRepository.GetAllPatients();
            return Ok(patients);
        }

        // GET: api/patients/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Retrieves a specific patient",
        Description = "Gets a patient from the database by their ID."
        )]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
    }
}