using AssessmentEmpleabilidad.DTOs;
using Microsoft.AspNetCore.Mvc;
using AssessmentEmpleabilidad.Repositories;

namespace AssessmentEmpleabilidad.Controllers.v1.Patient
{
    [ApiController]
    [Route("api/v1/patients")]
    [Tags("patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        // GET: api/patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients()
        {
            var patients = await _patientRepository.GetAllPatients();
            return Ok(patients);
        }

        // GET: api/patients/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatient(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        // POST: api/patients
        [HttpPost]
        public async Task<ActionResult<PatientDto>> CreatePatient([FromBody] PatientDto patientDto)
        {
            if (patientDto == null)
            {
                return BadRequest();
            }
            await _patientRepository.AddPatient(patientDto);
            return CreatedAtAction(nameof(GetPatient), new { id = patientDto.Id }, patientDto);
        }

        // PUT: api/patients/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientDto patientDto)
        {
            if (id != patientDto.Id)
            {
                return BadRequest();
            }

            var patient = await _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            // Assuming that the service updates the patient fields as needed.
            // If needed, add an UpdatePatient method in the service layer.
            await _patientRepository.AddPatient(patientDto); // This could be an update method
            return NoContent();
        }

        // DELETE: api/patients/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }

            await _patientRepository.DeletePatient(id);
            return NoContent();
        }
    }
}
