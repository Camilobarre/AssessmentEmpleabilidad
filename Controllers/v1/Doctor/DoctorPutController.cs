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
    public class DoctorPutController : DoctorController
    {
        public DoctorPutController(IDoctorRepository doctorRepository) : base(doctorRepository)
        {
        }

        // PUT: api/doctors/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(
        Summary = "Updates a doctor",
        Description = "Updates the details of a doctor in the database by their ID."
        )]
        [Authorize]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorDto doctorDto)
        {
            if (id != doctorDto.Id)
            {
                return BadRequest();
            }

            await _doctorRepository.UpdateDoctor(doctorDto);
            return NoContent();
        }
    }
}