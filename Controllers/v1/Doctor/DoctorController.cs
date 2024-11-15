using AssessmentEmpleabilidad.DTOs;
using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentEmpleabilidad.Controllers.v1.Doctor
{
    [ApiController]
    [Route("api/v1/doctors")]
    [Tags("doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorService;

        public DoctorController(IDoctorRepository doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: api/doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors()
        {
            var doctors = await _doctorService.GetAllDoctors();
            return Ok(doctors);
        }

        // GET: api/doctors/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        // POST: api/doctors
        [HttpPost]
        public async Task<ActionResult<DoctorDto>> CreateDoctor([FromBody] DoctorDto doctorDto)
        {
            if (doctorDto == null)
            {
                return BadRequest();
            }
            await _doctorService.AddDoctor(doctorDto);
            return CreatedAtAction(nameof(GetDoctor), new { id = doctorDto.Id }, doctorDto);
        }

        // PUT: api/doctors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorDto doctorDto)
        {
            if (id != doctorDto.Id)
            {
                return BadRequest();
            }

            await _doctorService.UpdateDoctor(doctorDto);
            return NoContent();
        }

        // DELETE: api/doctors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }

            await _doctorService.DeleteDoctor(id);
            return NoContent();
        }
    }
}