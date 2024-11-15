using AssessmentEmpleabilidad.DTOs;
using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentEmpleabilidad.Controllers.v1.Schedule
{
    [ApiController]
    [Route("api/v1/schedules")]
    [Tags("schedules")]
    public class ScheduleGetController : ScheduleController
    {
        public ScheduleGetController(IScheduleRepository scheduleRepository) : base(scheduleRepository)
        {
        }

        // GET: api/schedules
        [HttpGet]
        public async Task<IActionResult> GetSchedules()
        {
            var schedules = await _scheduleRepository.GetAllSchedules();
            return Ok(schedules);
        }

        // GET: api/schedules/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchedule(int id)
        {
            var schedule = await _scheduleRepository.GetScheduleById(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }
    }
}