using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentEmpleabilidad.Controllers.v1.Appointment
{
    [ApiController]
    [Route("api/v1/appointments")]
    [Tags("appointments")]
    public class AppointmentController : ControllerBase
    {
        protected readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
    }
}