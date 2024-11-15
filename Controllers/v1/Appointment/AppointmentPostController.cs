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
    public class AppointmentPostController : AppointmentController
    {
        public AppointmentPostController(IAppointmentRepository appointmentRepository) : base(appointmentRepository)
        {
        }

        // POST: api/appointments
        [HttpPost]
        [SwaggerOperation(
        Summary = "Creates a new appointment",
        Description = "Adds a new appointment to the database."
        )]
        [Authorize]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentDto appointmentDto)
        {
            if (appointmentDto == null)
            {
                return BadRequest();
            }
            await _appointmentRepository.AddAppointment(appointmentDto);
            return CreatedAtAction(nameof(AppointmentGetController), new { id = appointmentDto.Id }, appointmentDto);
        }
    }
}