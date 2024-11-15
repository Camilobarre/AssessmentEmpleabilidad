using AssessmentEmpleabilidad.DTOs;

namespace AssessmentEmpleabilidad.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<PatientDto>> GetAllPatients();
        Task<PatientDto?> GetPatientById(int id);
        Task AddPatient(PatientDto patientDto);
        Task DeletePatient(int id);
    }
}