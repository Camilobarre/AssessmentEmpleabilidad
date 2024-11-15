using AssessmentEmpleabilidad.DTOs;

namespace AssessmentEmpleabilidad.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<AppointmentDto>> GetAllAppointments();
        Task<AppointmentDto?> GetAppointmentById(int id);
        Task<IEnumerable<AppointmentDto>> SearchAppointmentsByPatientId(int patientId);
        Task AddAppointment(AppointmentDto appointmentDto);
        Task DeleteAppointment(int id);
    }
}