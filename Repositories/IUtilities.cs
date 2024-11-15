using AssessmentEmpleabilidad.Models;

namespace AssessmentEmpleabilidad.Repositories
{
    public interface IUtilities
    {
        string EncryptSHA256(string input);
        string GenerateJwtToken(User user);
    }
}