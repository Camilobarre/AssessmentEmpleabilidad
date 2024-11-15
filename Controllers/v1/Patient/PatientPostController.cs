using AssessmentEmpleabilidad.DTOs;
using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssessmentEmpleabilidad.Controllers.v1.Patient
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientPostController : PatientController
    {
        public PatientPostController(IPatientRepository patientRepository) : base(patientRepository)
        {
        }

        // POST: api/patients
        [HttpPost]
        [SwaggerOperation(
        Summary = "Creates a new patient",
        Description = "Adds a new patient to the database."
        )]
        [Authorize]
        public async Task<ActionResult<PatientDto>> CreatePatient([FromBody] PatientDto patientDto)
        {
            if (patientDto == null)
            {
                return BadRequest();
            }
            await _patientRepository.AddPatient(patientDto);
            return CreatedAtAction(nameof(PatientController), new { id = patientDto.Id }, patientDto);
        }

    }
}