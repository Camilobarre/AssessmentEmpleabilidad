using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentEmpleabilidad.Models
{
    [Table("Appointments")]
    public class Appointment
    {
        [Key]
        [Column("AppointmentId")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Patient")]
        [Column("PatientId")]
        public int PatientId { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        [Column("DoctorId")]
        public int DoctorId { get; set; }

        [Required]
        [Column("AppointmentDate")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(500)]
        [Column("ConsultationReason")]
        public string? Reason { get; set; }

        [Required]
        [Column("AppointmentStatus")]
        public AppointmentStatus Status { get; set; }

        //Relationship: each appointment has one patient and one doctor
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
    }

    public enum AppointmentStatus
    {
        Scheduled,
        Rescheduled,
        Cancelled
    }
}