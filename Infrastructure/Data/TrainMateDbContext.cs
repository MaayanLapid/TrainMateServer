using Microsoft.EntityFrameworkCore;
using TrainMateServer.Core.Models;


namespace TrainMateServer.Infrastructure.Data;

public class TrainMateDbContext : DbContext
{
    public DbSet<ExerciseType> ExerciseTypes { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<Workout> Workouts { get; set; }

    public TrainMateDbContext(DbContextOptions<TrainMateDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Exercise>()
            .HasMany<Workout>()
            .WithMany(x => x.Exercises);
    }
}

