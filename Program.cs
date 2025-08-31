using Microsoft.EntityFrameworkCore;
using TrainMateServer.Application.Interfaces;
using TrainMateServer.Application.Services;
using TrainMateServer.Infrastructure.Data;

namespace TrainMateServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:3000") //  React Address
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Add services to the container.

            builder.Services.AddControllers();

            // Dependency Injection
            builder.Services.AddScoped<ITraineeService, TraineeService>();
            builder.Services.AddScoped<IExerciseService, ExerciseService>();
            builder.Services.AddScoped<IExerciseTypeService, ExerciseTypeService>();
            builder.Services.AddScoped<IWorkoutService, WorkoutService>();

            string connectionString = "Server=MAAYANL-PC\\MSSQLSERVER2019;Database=TrainMate;Trusted_Connection=True;TrustServerCertificate=True;";

            builder.Services.AddDbContext<TrainMateDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
            });
            builder.Services.AddScoped<ITraineeRepository,  TraineeRepository>();
            builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
            builder.Services.AddScoped<IExerciseTypeRepository, ExerciseTypeRepository>();
            builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors();

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

            //using var scope = app.Services.CreateScope();
            //using var context = scope.ServiceProvider.GetRequiredService<TrainMateDbContext>();
            //var exercise = context.Exercises.FirstOrDefault();
        }
    }
}
