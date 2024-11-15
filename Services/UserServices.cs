using AssessmentEmpleabilidad.Data;
using AssessmentEmpleabilidad.DTOs;
using AssessmentEmpleabilidad.Models;
using AssessmentEmpleabilidad.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AssessmentEmpleabilidad.Services
{
    public class UserServices : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            return await _context.Users
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Role = u.Role.ToString()
                }).ToListAsync();
        }

        public async Task<UserDto?> GetUserById(int id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role.ToString()
            };
        }

        public async Task AddUser(UserDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Role = Enum.TryParse(userDto.Role, out UserRole role) ? role : UserRole.Patient
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
