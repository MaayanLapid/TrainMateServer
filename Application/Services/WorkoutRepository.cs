using Microsoft.EntityFrameworkCore;
using TrainMateServer.Application.Interfaces;
using TrainMateServer.Core.Models;
using TrainMateServer.Infrastructure.Data;

namespace TrainMateServer.Application.Services
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly TrainMateDbContext _context;

        public WorkoutRepository (TrainMateDbContext context)
        {
            _context = context;
        }

        public async Task<List<Workout>> GetAllWorkoutsByTraineeAsync(Guid traineeId, DateTime start, DateTime end)
        {
            return await _context.Workouts
                .Where(w =>
                    w.TraineeId == traineeId &&
                    w.WorkoutDate >= start &&
                    w.WorkoutDate <= end
                )
                .ToListAsync();
        }

        public async Task<Workout?> GetOneWorkoutAsync(Guid id)
        {
            return await _context.Workouts
                .Include(w => w.Trainee)
                .Include(w => w.Exercises).ThenInclude(w => w.ExerciseType)
                .FirstOrDefaultAsync(w => w.WorkoutId == id);
        }

        public async Task<Workout> ReportExerciseAsync(DateTime workoutDate, Trainee trainee, Exercise exercise)
        {
            var workout = await _context.Workouts
                .FirstOrDefaultAsync(x =>
                    x.WorkoutDate == workoutDate &&
                    x.TraineeId == trainee.TraineeId
                );

            if (workout == null)
            {
                workout = new Workout
                {
                    WorkoutId = Guid.NewGuid(),
                    WorkoutDate = workoutDate,
                    Trainee = trainee,
                };

                _context.Workouts.Add(workout);
            }

            workout.Exercises.Add(exercise);

            await _context.SaveChangesAsync();

            return workout;
        }

        public async Task<Workout?> UpdateWorkoutAsync(Guid workoutId, DateTime workoutDate)
        {
            Workout? workoutToUpdate = await _context.Workouts.FirstOrDefaultAsync(w => w.WorkoutId == workoutId);
            if (workoutToUpdate == null)
            {
                return null;
            }
            workoutToUpdate.WorkoutDate = workoutDate;
            
            await _context.SaveChangesAsync();

            return workoutToUpdate;
        }

        public async Task<Workout?> DeleteWorkoutAsync(Guid id)
        {
            Workout? workoutToDelete = await _context.Workouts.FirstOrDefaultAsync(w => w.WorkoutId == id);
            if (workoutToDelete == null)
            {
                return null;
            }
            _context.Workouts.Remove(workoutToDelete);
            await _context.SaveChangesAsync();
            return workoutToDelete;
        }



    }
}
