using Microsoft.AspNetCore.Mvc;
using AssessmentEmpleabilidad.Repositories;

namespace AssessmentEmpleabilidad.Controllers.v1.Schedule
{
    [ApiController]
    [Route("api/v1/schedules")]
    [Tags("schedules")]
    public class ScheduleController : ControllerBase
    {
        protected readonly IScheduleRepository _scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
    }
}
