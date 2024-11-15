using AssessmentEmpleabilidad.DTOs;
using Microsoft.AspNetCore.Mvc;
using AssessmentEmpleabilidad.Repositories;

namespace AssessmentEmpleabilidad.Controllers.v1.Schedule
{
    [ApiController]
    [Route("api/v1/schedules")]
    [Tags("schedules")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        // GET: api/schedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleDto>>> GetSchedules()
        {
            var schedules = await _scheduleRepository.GetAllSchedules();
            return Ok(schedules);
        }

        // GET: api/schedules/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleDto>> GetSchedule(int id)
        {
            var schedule = await _scheduleRepository.GetScheduleById(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }

        // POST: api/schedules
        [HttpPost]
        public async Task<ActionResult<ScheduleDto>> CreateSchedule([FromBody] ScheduleDto scheduleDto)
        {
            if (scheduleDto == null)
            {
                return BadRequest();
            }
            await _scheduleRepository.AddSchedule(scheduleDto);
            return CreatedAtAction(nameof(GetSchedule), new { id = scheduleDto.Id }, scheduleDto);
        }

        // PUT: api/schedules/{id}
        [HttpPut("{id}")]
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

            // Assuming that the service updates the schedule fields as needed.
            // If needed, add an UpdateSchedule method in the service layer.
            await _scheduleRepository.AddSchedule(scheduleDto); // This could be an update method
            return NoContent();
        }

        // DELETE: api/schedules/{id}
        [HttpDelete("{id}")]
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
