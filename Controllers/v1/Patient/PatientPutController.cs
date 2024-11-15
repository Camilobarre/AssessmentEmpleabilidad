using AssessmentEmpleabilidad.DTOs;
using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssessmentEmpleabilidad.Controllers.v1.Patient
{
    [ApiController]
    [Route("api/v1/patients")]
    [Tags("patients")]
    public class PatientPutController : PatientController
    {
        public PatientPutController(IPatientRepository patientRepository) : base(patientRepository)
        {
        }

        // PUT: api/patients/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(
        Summary = "Updates a patient",
        Description = "Updates the details of a patient in the database by their ID."
        )]
        [Authorize]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientDto patientDto)
        {
            if (id != patientDto.Id)
            {
                return BadRequest();
            }

            var patient = await _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            await _patientRepository.AddPatient(patientDto);
            return NoContent();
        }
    }
}