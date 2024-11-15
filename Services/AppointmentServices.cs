using AssessmentEmpleabilidad.Data;
using AssessmentEmpleabilidad.DTOs;
using AssessmentEmpleabilidad.Models;
using AssessmentEmpleabilidad.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AssessmentEmpleabilidad.Services
{
    public class AppointmentServices : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAppointments()
        {
            return await _context.Appointments
                .Select(a => new AppointmentDto
                {
                    Id = a.Id,
                    Date = a.Date,
                    PatientId = a.PatientId,
                    DoctorId = a.DoctorId
                }).ToListAsync();
        }

        public async Task<AppointmentDto?> GetAppointmentById(int id)
        {
            var appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null) return null;

            return new AppointmentDto
            {
                Id = appointment.Id,
                Date = appointment.Date,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId
            };
        }

        public async Task<IEnumerable<AppointmentDto>> SearchAppointmentsByPatientId(int patientId)
        {
            return await _context.Appointments
                .Where(a => a.PatientId == patientId)
                .Select(a => new AppointmentDto
                {
                    Id = a.Id,
                    Date = a.Date,
                    PatientId = a.PatientId,
                    DoctorId = a.DoctorId
                }).ToListAsync();
        }

        public async Task AddAppointment(AppointmentDto appointmentDto)
        {
            var appointment = new Appointment
            {
                Date = appointmentDto.Date,
                PatientId = appointmentDto.PatientId,
                DoctorId = appointmentDto.DoctorId
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }
    }
}