using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssessmentEmpleabilidad.Controllers.v1.Appointment
{
    [ApiController]
    [Route("api/v1/appointments")]
    [Tags("appointments")]
    public class AppointmentGetController : AppointmentController
    {
        public AppointmentGetController(IAppointmentRepository appointmentRepository) : base(appointmentRepository)
        {
        }

        // GET: api/appointments
        [HttpGet]
        [SwaggerOperation(
        Summary = "Retrieves all appointments",
        Description = "Gets a list of all appointments from the database."
        )]
        [Authorize]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await _appointmentRepository.GetAllAppointments();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Retrieves an appointment by its ID",
        Description = "Gets a specific appointment from the database by its ID."
        )]
        [Authorize]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }
    }
}