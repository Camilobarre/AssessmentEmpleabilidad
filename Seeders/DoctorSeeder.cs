using AssessmentEmpleabilidad.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentEmpleabilidad.Seeders
{
    public static class DoctorSeeder
    {
        public static void SeedDoctors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Dr. Sarah Miller", Specialization = "Pediatrics" },
                new Doctor { Id = 2, Name = "Dr. James Wilson", Specialization = "Dermatology" },
                new Doctor { Id = 3, Name = "Dr. Emma Johnson", Specialization = "Cardiology" },
                new Doctor { Id = 4, Name = "Dr. William Garcia", Specialization = "Neurology" },
                new Doctor { Id = 5, Name = "Dr. Olivia Martinez", Specialization = "Orthopedics" }
            );
        }
    }
}