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
    public class SchedulePostController : ScheduleController
    {
        public SchedulePostController(IScheduleRepository scheduleRepository) : base(scheduleRepository)
        {
        }

        // POST: api/schedules
        [HttpPost]
        [SwaggerOperation(
        Summary = "Creates a new schedule",
        Description = "Adds a new schedule to the database."
        )]
        [Authorize]
        public async Task<ActionResult<ScheduleDto>> CreateSchedule([FromBody] ScheduleDto scheduleDto)
        {
            if (scheduleDto == null)
            {
                return BadRequest();
            }
            await _scheduleRepository.AddSchedule(scheduleDto);
            return CreatedAtAction(nameof(ScheduleController), new { id = scheduleDto.Id }, scheduleDto);
        }
    }
}