using AssessmentEmpleabilidad.DTOs;
using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssessmentEmpleabilidad.Controllers.v1.Schedule
{
    [ApiController]
    [Route("api/v1/schedules")]
    [Tags("schedules")]
    public class SchedulePutcontroller : ScheduleController
    {
        public SchedulePutcontroller(IScheduleRepository scheduleRepository) : base(scheduleRepository)
        {
        }

        // PUT: api/schedules/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(
        Summary = "Updates a schedule",
        Description = "Updates the details of a schedule in the database by their ID."
        )]
        [Authorize]
        public async Task<IActionResult> UpdateSchedule(int id, [FromBody] ScheduleDto scheduleDto)
        {
            if (id != scheduleDto.Id)
            {
                return BadRequest();
            }

            var schedule = await _scheduleRepository.GetScheduleById(id);
            if (schedule == null)
            {
                return NotFound();
            }

            await _scheduleRepository.AddSchedule(scheduleDto);
            return NoContent();
        }
    }
}