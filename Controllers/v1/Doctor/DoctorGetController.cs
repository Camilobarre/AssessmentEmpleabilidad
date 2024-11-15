using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AssessmentEmpleabilidad.Controllers.v1.Doctor
{
    [ApiController]
    [Route("api/v1/doctors")]
    [Tags("doctors")]
    public class DoctorGetController : DoctorController
    {
        public DoctorGetController(IDoctorRepository doctorService) : base(doctorService)
        {
        }

        // GET: api/doctors
        [HttpGet]
        [SwaggerOperation(
        Summary = "Retrieves a list of doctors",
        Description = "Gets all doctors from the database."
        )]
        [Authorize]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _doctorRepository.GetAllDoctors();
            return Ok(doctors);
        }

        // GET: api/doctors/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Retrieves a specific doctor",
        Description = "Gets a doctor from the database by their ID."
        )]
        [Authorize]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _doctorRepository.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
    }
}