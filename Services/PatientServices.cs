using AssessmentEmpleabilidad.Data;
using AssessmentEmpleabilidad.DTOs;
using AssessmentEmpleabilidad.Models;
using AssessmentEmpleabilidad.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AssessmentEmpleabilidad.Services
{
    public class PatientServices : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatients()
        {
            return await _context.Patients
                .Select(p => new PatientDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Email = p.Email,
                    Phone = p.Phone
                }).ToListAsync();
        }

        public async Task<PatientDto?> GetPatientById(int id)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null) return null;

            return new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Email = patient.Email,
                Phone = patient.Phone
            };
        }

        public async Task AddPatient(PatientDto patientDto)
        {
            var patient = new Patient
            {
                Name = patientDto.Name,
                Email = patientDto.Email,
                Phone = patientDto.Phone
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}