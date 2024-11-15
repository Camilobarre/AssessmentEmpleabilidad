using AssessmentEmpleabilidad.DTOs;

namespace AssessmentEmpleabilidad.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto?> GetUserById(int id);
        Task AddUser(UserDto userDto);
        Task DeleteUser(int id);
    }
}