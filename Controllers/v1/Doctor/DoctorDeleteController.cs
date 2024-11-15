using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssessmentEmpleabilidad.Controllers.v1.Doctor
{
    [ApiController]
    [Route("api/v1/doctors")]
    [Tags("doctors")]
    public class DoctorDeleteController : DoctorController
    {
        public DoctorDeleteController(IDoctorRepository doctorRepository) : base(doctorRepository)
        {
        }

        // DELETE: api/doctors/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Deletes a doctor",
        Description = "Removes a doctor from the database by their ID."
        )]
        [Authorize]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _doctorRepository.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            await _doctorRepository.DeleteDoctor(id);
            return NoContent();
        }
    }
}