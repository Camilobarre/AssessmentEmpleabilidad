using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentEmpleabilidad.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("UserId")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Username")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [MaxLength(100, ErrorMessage = "Email must be at most {1} characters.")]
        [Column("email")]
        public required string Email { get; set; }

        [Required]
        [StringLength(255)]
        [Column("PasswordHash")]
        public string? Password { get; set; }

        [Required]
        [Column("UserRole")]
        public UserRole Role { get; set; }
    }

    public enum UserRole
    {
        Patient,
        Doctor,
        Admin
    }
}