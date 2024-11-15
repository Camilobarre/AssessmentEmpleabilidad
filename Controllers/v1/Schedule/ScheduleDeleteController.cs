using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssessmentEmpleabilidad.Controllers.v1.Schedule
{
    [ApiController]
    [Route("api/v1/schedules")]
    [Tags("schedules")]
    public class ScheduleDeleteController : ScheduleController
    {
        public ScheduleDeleteController(IScheduleRepository scheduleRepository) : base(scheduleRepository)
        {
        }

        // DELETE: api/schedules/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Deletes a doctor",
        Description = "Removes a doctor from the database by their ID."
        )]
        [Authorize]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var schedule = await _scheduleRepository.GetScheduleById(id);
            if (schedule == null)
            {
                return NotFound();
            }

            await _scheduleRepository.DeleteSchedule(id);
            return NoContent();
        }
    }
}