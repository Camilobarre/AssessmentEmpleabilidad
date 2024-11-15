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

        [Required]
        [StringLength(255)]
        [Column("PasswordHash")]
        public string? Password { get; set; } // Password hashed

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