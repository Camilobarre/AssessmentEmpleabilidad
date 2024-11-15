using AssessmentEmpleabilidad.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentEmpleabilidad.Seeders
{
    public static class ScheduleSeeder
    {
        public static void SeedSchedules(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule { Id = 1, DoctorId = 1, StartTime = new DateTime(2024, 11, 20, 8, 0, 0), EndTime = new DateTime(2024, 11, 20, 16, 0, 0), IsAvailable = true },
                new Schedule { Id = 2, DoctorId = 2, StartTime = new DateTime(2024, 11, 21, 9, 0, 0), EndTime = new DateTime(2024, 11, 21, 17, 0, 0), IsAvailable = true },
                new Schedule { Id = 3, DoctorId = 3, StartTime = new DateTime(2024, 11, 22, 10, 0, 0), EndTime = new DateTime(2024, 11, 22, 18, 0, 0), IsAvailable = true },
                new Schedule { Id = 4, DoctorId = 4, StartTime = new DateTime(2024, 11, 23, 8, 0, 0), EndTime = new DateTime(2024, 11, 23, 16, 0, 0), IsAvailable = true },
                new Schedule { Id = 5, DoctorId = 5, StartTime = new DateTime(2024, 11, 24, 9, 0, 0), EndTime = new DateTime(2024, 11, 24, 17, 0, 0), IsAvailable = true }
            );
        }
    }
}