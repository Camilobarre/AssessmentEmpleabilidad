using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssessmentEmpleabilidad.Controllers.v1.Appointment
{
    [ApiController]
    [Route("api/v1/appointments")]
    [Tags("appointments")]
    public class AppointmentDeleteController : AppointmentController
    {
        public AppointmentDeleteController(IAppointmentRepository appointmentRepository) : base(appointmentRepository)
        {
        }

        // DELETE: api/appointments/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Deletes an appointment",
        Description = "Removes an appointment from the database by its ID."
        )]
        [Authorize]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            await _appointmentRepository.DeleteAppointment(id);
            return NoContent();
        }
    }
}