using Microsoft.EntityFrameworkCore;
using TrainMateServer.Application.Interfaces;
using TrainMateServer.Core.Models;
using TrainMateServer.Infrastructure.Data;

namespace TrainMateServer.Application.Services
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly TrainMateDbContext _context;

        public ExerciseRepository(TrainMateDbContext context)
        {
            _context = context;
        }

        public async Task<List<Exercise>> GetAllExercisesAsync()
        {
            return await _context.Exercises
             .Include(e => e.ExerciseType)
             .ToListAsync();

        }

        public async Task<Exercise?> GetOneExerciseAsync(Guid id, bool includeType)
        {
            if (includeType)
            {
                return await _context.Exercises
                    .Include(w => w.ExerciseType)
                    .FirstOrDefaultAsync(e => e.ExerciseId == id);
            }
            else
            {
                return await _context.Exercises
                    .FirstOrDefaultAsync(e => e.ExerciseId == id);
            }
        }

        public async Task<Exercise> CreatExerciseAsync(ExerciseType exerciseType, int repetitions, int sets)
        {
            var exercise = new Exercise
            {
                ExerciseId = Guid.NewGuid(),
                ExerciseType = exerciseType,
                ExerciseTypeId = exerciseType.ExerciseTypeId,
                Repetitions = repetitions,
                Sets = sets,
            };
            _context.Exercises.Add(exercise);

            await _context.SaveChangesAsync();
            return exercise;
        }
        public async Task<Exercise?> UpdateExerciseAsync(Guid id, int repetitions, int sets)
        {
            Exercise? excerciseToUpdate = await _context.Exercises.FirstOrDefaultAsync(e => e.ExerciseId == id);
            if (excerciseToUpdate == null)
            {
                return null;
            }
            excerciseToUpdate.Repetitions = repetitions;
            excerciseToUpdate.Sets = sets;
            await _context.SaveChangesAsync();

            return excerciseToUpdate;
        }
        public async Task<Exercise?> DeleteExerciseAsync(Guid id)
        {
            Exercise? excerciseToDelete = await _context.Exercises.FirstOrDefaultAsync(e => e.ExerciseId == id);
            if (excerciseToDelete == null)
            {
                return null;
            }
            _context.Exercises.Remove(excerciseToDelete);
            await _context.SaveChangesAsync();
            return excerciseToDelete;
        }


    }
}
