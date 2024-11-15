namespace AssessmentEmpleabilidad.DTOs
{
    public class ScheduleDto
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public string? DoctorName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsAvailable { get; set; }
    }
}