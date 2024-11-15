using AssessmentEmpleabilidad.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentEmpleabilidad.Seeders
{
    public static class PatientSeeder
    {
        public static void SeedPatients(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Phone = "1234567890" },
                new Patient { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Phone = "9876543210" },
                new Patient { Id = 3, Name = "Michael Johnson", Email = "michael.johnson@example.com", Phone = "4567891230" },
                new Patient { Id = 4, Name = "Emily Davis", Email = "emily.davis@example.com", Phone = "3216549870" },
                new Patient { Id = 5, Name = "David Brown", Email = "david.brown@example.com", Phone = "6541237890" }
            );
        }
    }
}