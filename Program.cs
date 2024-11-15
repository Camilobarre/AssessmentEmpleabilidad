using AssessmentEmpleabilidad.Config;
using AssessmentEmpleabilidad.Data;
using AssessmentEmpleabilidad.Repositories;
using AssessmentEmpleabilidad.Services;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

Env.Load();

// Get the environment variables needed to connect to the database
var host = Environment.GetEnvironmentVariable("DB_HOST");
var databaseName = Environment.GetEnvironmentVariable("DB_NAME");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var username = Environment.GetEnvironmentVariable("DB_USERNAME");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

// Builds the connection string using the environment variables
var connectionString = $"server={host};port={port};database={databaseName};uid={username};password={password}";

var builder = WebApplication.CreateBuilder(args);

// Database connection using MySQL and the specified version
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.Parse("8.0.20-mysql")));

// Add services to the container.
builder.Services.AddScoped<IAppointmentRepository, AppointmentServices>();
builder.Services.AddScoped<IDoctorRepository, DoctorServices>();
builder.Services.AddScoped<IPatientRepository, PatientServices>();
builder.Services.AddScoped<IUserRepository, UserServices>();
builder.Services.AddScoped<IScheduleRepository, ScheduleServices>();
builder.Services.AddScoped<IUtilities, Utilities>();

builder.Services.AddSingleton<Utilities>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
