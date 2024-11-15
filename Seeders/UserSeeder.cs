using AssessmentEmpleabilidad.Models;
using Microsoft.EntityFrameworkCore;

namespace AssessmentEmpleabilidad.Seeders
{
    public static class UserSeeder
    {
        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@example.com",
                    Password = "hashed_password_1",
                    Role = UserRole.Admin
                },
                new User
                {
                    Id = 2,
                    Username = "doctor1",
                    Email = "doctor1@example.com",
                    Password = "hashed_password_2",
                    Role = UserRole.Doctor
                },
                new User
                {
                    Id = 3,
                    Username = "doctor2",
                    Email = "doctor2@example.com",
                    Password = "hashed_password_3",
                    Role = UserRole.Doctor
                },
                new User
                {
                    Id = 4,
                    Username = "patient1",
                    Email = "patient1@example.com",
                    Password = "hashed_password_4",
                    Role = UserRole.Patient
                },
                new User
                {
                    Id = 5,
                    Username = "patient2",
                    Email = "patient2@example.com",
                    Password = "hashed_password_5",
                    Role = UserRole.Patient
                }
            );
        }
    }
}