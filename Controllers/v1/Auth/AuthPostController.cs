using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssessmentEmpleabilidad.Data;
using AssessmentEmpleabilidad.Models;
using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Identity.Data;

namespace AssessmentEmpleabilidad.Controllers.v1.Auth
{
    [ApiController]
    [Route("api/v1/auth")]
    [Tags("auth")]
    public class AuthPostController : AuthController
    {
        private readonly ApplicationDbContext _context;
        private readonly IUtilities _utilities;

        public AuthPostController(IUserRepository userRepository, ApplicationDbContext context, IUtilities utilities)
            : base(userRepository)
        {
            _context = context;
            _utilities = utilities;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar si el nombre de usuario ya existe
            if (await _context.Users.AnyAsync(u => u.Username == newUser.Username))
            {
                return BadRequest("Username already exists");
            }

            // Hashear la contraseña
            newUser.Password = _utilities.EncryptSHA256(newUser.Password);

            // Asignar un rol por defecto si no se especifica
            if (newUser.Role == 0)
            {
                newUser.Role = UserRole.Patient;
            }

            // Guardar el nuevo usuario en la base de datos
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            // Retornar la respuesta con el ID y nombre de usuario
            return CreatedAtAction(nameof(Login), new { id = newUser.Id }, new
            {
                newUser.Id,
                newUser.Username,
                newUser.Password,
                Role = newUser.Role.ToString()
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Buscar al usuario por su nombre de usuario
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            // Verificar si la contraseña es válida
            if (user.Password != _utilities.EncryptSHA256(request.Password))
            {
                return Unauthorized("Invalid username or password.");
            }

            // Generar el token JWT
            var token = _utilities.GenerateJwtToken(user);

            // Retornar el token
            return Ok(new
            {
                message = "Please, save this token",
                jwt = token
            });
        }
    }
}
