using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssessmentEmpleabilidad.Controllers.v1.Patient
{
    [ApiController]
    [Route("api/v1/patients")]
    [Tags("patients")]
    public class PatientDeleteController : PatientController
    {
        public PatientDeleteController(IPatientRepository patientRepository) : base(patientRepository)
        {
        }

        // DELETE: api/patients/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Deletes a patient",
        Description = "Removes a patient from the database by their ID."
        )]
        [Authorize]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            await _patientRepository.DeletePatient(id);
            return NoContent();
        }
    }
}