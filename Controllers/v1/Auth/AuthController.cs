using AssessmentEmpleabilidad.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentEmpleabilidad.Controllers.v1.Auth
{
    [ApiController]
    [Route("api/v1/auth")]
    [Tags("auth")]
    public class AuthController : ControllerBase
    {
        protected readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}