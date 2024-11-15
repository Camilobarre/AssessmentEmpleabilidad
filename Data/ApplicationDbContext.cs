using AssessmentEmpleabilidad.Models;
using AssessmentEmpleabilidad.Seeders;
using Microsoft.EntityFrameworkCore;

namespace AssessmentEmpleabilidad.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Define DbSets for your entities
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call seeders
            PatientSeeder.SeedPatients(modelBuilder);
            DoctorSeeder.SeedDoctors(modelBuilder);
            AppointmentSeeder.SeedAppointments(modelBuilder);
            UserSeeder.SeedUsers(modelBuilder);
            ScheduleSeeder.SeedSchedules(modelBuilder);

            // Relationships configuration (if needed)

            // Appointment -> Patient (many-to-one)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            // Appointment -> Doctor (many-to-one)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            // Schedule -> Doctor (one-to-one)
            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Doctor)
                .WithOne(d => d.Schedule)
                .HasForeignKey<Schedule>(s => s.DoctorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
