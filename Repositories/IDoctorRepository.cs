using AssessmentEmpleabilidad.DTOs;

namespace AssessmentEmpleabilidad.Repositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctors();
        Task<DoctorDto?> GetDoctorById(int id);
        Task AddDoctor(DoctorDto doctorDto);
        Task DeleteDoctor(int id);
    }
}