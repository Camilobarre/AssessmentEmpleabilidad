using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentEmpleabilidad.Models
{
    [Table("Doctors")]
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("DoctorId")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("FullName")]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        [Column("SpecializationArea")]
        public string? Specialization { get; set; }

        // Relationship: One doctor has one schedule
        [InverseProperty("Doctor")]
        public Schedule? Schedule { get; set; }

        // Relationship: One doctor has multiple appointments
        [InverseProperty("Doctor")]
        public ICollection<Appointment>? Appointments { get; set; }
    }
}