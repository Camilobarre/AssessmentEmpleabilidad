using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentEmpleabilidad.Models
{
    [Table("Patients")]
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PatientId")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("FullName")]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        [Column("EmailAddress")]
        public string? Email { get; set; }

        [Required]
        [Phone]
        [Column("PhoneNumber")]
        public string? Phone { get; set; }

        // Relationship: One patient has multiple appointments
        [InverseProperty("Patient")]
        public ICollection<Appointment>? Appointments { get; set; }
    }
}