using AssessmentEmpleabilidad.DTOs;

namespace AssessmentEmpleabilidad.Repositories
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<ScheduleDto>> GetAllSchedules();
        Task<ScheduleDto?> GetScheduleById(int id);
        Task AddSchedule(ScheduleDto scheduleDto);
        Task DeleteSchedule(int id);
    }
}