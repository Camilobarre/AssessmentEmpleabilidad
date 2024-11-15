using AssessmentEmpleabilidad.Data;
using AssessmentEmpleabilidad.DTOs;
using AssessmentEmpleabilidad.Models;
using AssessmentEmpleabilidad.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AssessmentEmpleabilidad.Services
{
    public class DoctorServices : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctors()
        {
            return await _context.Doctors
                .Select(d => new DoctorDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Specialization = d.Specialization
                }).ToListAsync();
        }

        public async Task<DoctorDto?> GetDoctorById(int id)
        {
            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(d => d.Id == id);

            if (doctor == null) return null;

            return new DoctorDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Specialization = doctor.Specialization
            };
        }

        public async Task AddDoctor(DoctorDto doctorDto)
        {
            var doctor = new Doctor
            {
                Name = doctorDto.Name,
                Specialization = doctorDto.Specialization
            };

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDoctor(DoctorDto doctorDto)
        {
            var doctor = await _context.Doctors.FindAsync(doctorDto.Id);
            if (doctor == null) return;
            doctor.Name = doctorDto.Name;
            doctor.Specialization = doctorDto.Specialization;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}