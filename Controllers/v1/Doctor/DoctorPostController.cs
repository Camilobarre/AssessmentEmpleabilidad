using AssessmentEmpleabilidad.DTOs;
using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssessmentEmpleabilidad.Controllers.v1.Doctor
{
    [ApiController]
    [Route("api/v1/doctors")]
    [Tags("doctors")]
    public class DoctorPostController : DoctorController
    {
        public DoctorPostController(IDoctorRepository doctorRepository) : base(doctorRepository)
        {
        }

        // POST: api/doctors
        [HttpPost]
        [SwaggerOperation(
        Summary = "Creates a new doctor",
        Description = "Adds a new doctor to the database."
        )]
        [Authorize]
        public async Task<ActionResult<DoctorDto>> CreateDoctor([FromBody] DoctorDto doctorDto)
        {
            if (doctorDto == null)
            {
                return BadRequest();
            }
            await _doctorRepository.AddDoctor(doctorDto);
            return CreatedAtAction(nameof(DoctorController), new { id = doctorDto.Id }, doctorDto);
        }
    }
}