namespace AssessmentEmpleabilidad.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string? PatientName { get; set; }

        public int DoctorId { get; set; }

        public string? DoctorName { get; set; }

        public DateTime Date { get; set; }

        public string? Reason { get; set; }

        public string? Status { get; set; }
    }
}