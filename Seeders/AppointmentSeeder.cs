using AssessmentEmpleabilidad.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentEmpleabilidad.Seeders
{
    public static class AppointmentSeeder
    {
        public static void SeedAppointments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, PatientId = 1, DoctorId = 1, Date = new DateTime(2024, 11, 20, 10, 0, 0), Reason = "Routine check-up", Status = AppointmentStatus.Scheduled },
                new Appointment { Id = 2, PatientId = 2, DoctorId = 2, Date = new DateTime(2024, 11, 21, 11, 0, 0), Reason = "Skin rash consultation", Status = AppointmentStatus.Scheduled },
                new Appointment { Id = 3, PatientId = 3, DoctorId = 3, Date = new DateTime(2024, 11, 22, 9, 30, 0), Reason = "Heart check-up", Status = AppointmentStatus.Scheduled },
                new Appointment { Id = 4, PatientId = 4, DoctorId = 4, Date = new DateTime(2024, 11, 23, 14, 0, 0), Reason = "Neurological evaluation", Status = AppointmentStatus.Scheduled },
                new Appointment { Id = 5, PatientId = 5, DoctorId = 5, Date = new DateTime(2024, 11, 24, 13, 0, 0), Reason = "Knee pain assessment", Status = AppointmentStatus.Scheduled }
            );
        }
    }
}