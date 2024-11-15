using AssessmentEmpleabilidad.DTOs;
using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssessmentEmpleabilidad.Controllers.v1.Appointment
{
    [ApiController]
    [Route("api/v1/appointments")]
    [Tags("appointments")]
    public class AppointmentPutController : AppointmentController
    {
        public AppointmentPutController(IAppointmentRepository appointmentRepository) : base(appointmentRepository)
        {
        }

        // PUT: api/appointments/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(
        Summary = "Updates an appointment",
        Description = "Updates the details of an existing appointment in the database."
        )]
        [Authorize]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] AppointmentDto appointmentDto)
        {
            if (id != appointmentDto.Id)
            {
                return BadRequest();
            }

            await _appointmentRepository.UpdateAppointment(appointmentDto);
            return NoContent();
        }
    }
}