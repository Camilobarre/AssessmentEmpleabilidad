using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AssessmentEmpleabilidad.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableAndSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpecializationArea = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ConsultationReason = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AppointmentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "FullName", "SpecializationArea" },
                values: new object[,]
                {
                    { 1, "Dr. Sarah Miller", "Pediatrics" },
                    { 2, "Dr. James Wilson", "Dermatology" },
                    { 3, "Dr. Emma Johnson", "Cardiology" },
                    { 4, "Dr. William Garcia", "Neurology" },
                    { 5, "Dr. Olivia Martinez", "Orthopedics" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "EmailAddress", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "John Doe", "1234567890" },
                    { 2, "jane.smith@example.com", "Jane Smith", "9876543210" },
                    { 3, "michael.johnson@example.com", "Michael Johnson", "4567891230" },
                    { 4, "emily.davis@example.com", "Emily Davis", "3216549870" },
                    { 5, "david.brown@example.com", "David Brown", "6541237890" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "PasswordHash", "UserRole", "Username" },
                values: new object[,]
                {
                    { 1, "hashed_password_1", 2, "admin" },
                    { 2, "hashed_password_2", 1, "doctor1" },
                    { 3, "hashed_password_3", 1, "doctor2" },
                    { 4, "hashed_password_4", 0, "patient1" },
                    { 5, "hashed_password_5", 0, "patient2" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "AppointmentDate", "DoctorId", "PatientId", "ConsultationReason", "AppointmentStatus" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Routine check-up", 0 },
                    { 2, new DateTime(2024, 11, 21, 11, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Skin rash consultation", 0 },
                    { 3, new DateTime(2024, 11, 22, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, 3, "Heart check-up", 0 },
                    { 4, new DateTime(2024, 11, 23, 14, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, "Neurological evaluation", 0 },
                    { 5, new DateTime(2024, 11, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, "Knee pain assessment", 0 }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "ScheduleId", "DoctorId", "EndTime", "IsAvailable", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 11, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 11, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2024, 11, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 11, 21, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2024, 11, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 11, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2024, 11, 23, 16, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 11, 23, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2024, 11, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2024, 11, 24, 9, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DoctorId",
                table: "Schedules",
                column: "DoctorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
