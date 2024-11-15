using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentEmpleabilidad.Models
{
    [Table("Schedules")]
    public class Schedule
    {
        [Key]
        [Column("ScheduleId")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        [Column("DoctorId")]
        public int DoctorId { get; set; }

        [Required]
        [Column("StartTime")]
        public DateTime StartTime { get; set; }

        [Required]
        [Column("EndTime")]
        public DateTime EndTime { get; set; }

        [Required]
        [Column("IsAvailable")]
        public bool IsAvailable { get; set; }

        // Relationship: one schedule belongs to one doctor
        public Doctor? Doctor { get; set; }
    }
}