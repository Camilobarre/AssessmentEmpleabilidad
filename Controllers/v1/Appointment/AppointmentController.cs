using AssessmentEmpleabilidad.DTOs;
using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentEmpleabilidad.Controllers.v1.Appointment
{
    [ApiController]
    [Route("api/v1/appointments")]
    [Tags("appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentService;

        public AppointmentController(IAppointmentRepository appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: api/appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointments();
            return Ok(appointments);
        }

        // GET: api/appointments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        // POST: api/appointments
        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> CreateAppointment([FromBody] AppointmentDto appointmentDto)
        {
            if (appointmentDto == null)
            {
                return BadRequest();
            }
            await _appointmentService.AddAppointment(appointmentDto);
            return CreatedAtAction(nameof(GetAppointment), new { id = appointmentDto.Id }, appointmentDto);
        }

        // PUT: api/appointments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] AppointmentDto appointmentDto)
        {
            if (id != appointmentDto.Id)
            {
                return BadRequest();
            }

            await _appointmentService.UpdateAppointment(appointmentDto);
            return NoContent();
        }

        // DELETE: api/appointments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            await _appointmentService.DeleteAppointment(id);
            return NoContent();
        }
    }
}