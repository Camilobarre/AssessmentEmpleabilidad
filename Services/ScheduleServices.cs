using AssessmentEmpleabilidad.Data;
using AssessmentEmpleabilidad.DTOs;
using AssessmentEmpleabilidad.Models;
using AssessmentEmpleabilidad.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AssessmentEmpleabilidad.Services
{
    public class ScheduleServices : IScheduleRepository
    {
        private readonly ApplicationDbContext _context;

        public ScheduleServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ScheduleDto>> GetAllSchedules()
        {
            return await _context.Schedules
                .Select(s => new ScheduleDto
                {
                    Id = s.Id,
                    DoctorId = s.DoctorId,
                    DoctorName = s.Doctor.Name,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    IsAvailable = s.IsAvailable
                }).ToListAsync();
        }

        public async Task<ScheduleDto?> GetScheduleById(int id)
        {
            var schedule = await _context.Schedules
                .Include(s => s.Doctor) 
                .FirstOrDefaultAsync(s => s.Id == id);

            if (schedule == null) return null;

            return new ScheduleDto
            {
                Id = schedule.Id,
                DoctorId = schedule.DoctorId,
                DoctorName = schedule.Doctor.Name,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                IsAvailable = schedule.IsAvailable
            };
        }

        public async Task AddSchedule(ScheduleDto scheduleDto)
        {
            var schedule = new Schedule
            {
                DoctorId = scheduleDto.DoctorId,
                StartTime = scheduleDto.StartTime,
                EndTime = scheduleDto.EndTime,
                IsAvailable = scheduleDto.IsAvailable
            };

            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSchedule(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule != null)
            {
                _context.Schedules.Remove(schedule);
                await _context.SaveChangesAsync();
            }
        }
    }
}
