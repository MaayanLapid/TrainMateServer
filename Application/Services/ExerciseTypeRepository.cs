using Microsoft.EntityFrameworkCore;
using TrainMateServer.Application.Interfaces;
using TrainMateServer.Core.Models;
using TrainMateServer.Infrastructure.Data;

namespace TrainMateServer.Application.Services
{
    public class ExerciseTypeRepository : IExerciseTypeRepository
    {
        private readonly TrainMateDbContext _context;

        public ExerciseTypeRepository(TrainMateDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExerciseType>> GetAllExerciseTypesAsync()
        {
            return await _context.ExerciseTypes.ToListAsync();
        }

        public async Task<ExerciseType?> GetOneExerciseTypeAsync(Guid id)
        {
            return await _context.ExerciseTypes.FirstOrDefaultAsync(e => e.ExerciseTypeId == id);

        }
        public async Task<ExerciseType> CreatExerciseTypeAsync(string exerciseTypeName)
        {
            var exerciseType = new ExerciseType
            {
                ExerciseTypeId = Guid.NewGuid(),
                ExerciseTypeName = exerciseTypeName,
            };
            _context.ExerciseTypes.Add(exerciseType);

            await _context.SaveChangesAsync();
            return exerciseType;

        }
        public async Task<ExerciseType?> UpdateExerciseTypeAsync(Guid id, string exerciseTypeName)
        {
            ExerciseType? excerciseTypeToUpdate = await _context.ExerciseTypes.FirstOrDefaultAsync(e => e.ExerciseTypeId == id);
            if (excerciseTypeToUpdate == null)
            {
                return null;
            }
            excerciseTypeToUpdate.ExerciseTypeName = exerciseTypeName;
            await _context.SaveChangesAsync();

            return excerciseTypeToUpdate;
        }
        public async Task<ExerciseType?> DeleteExerciseTypeAsync(Guid id)
        {
            ExerciseType? excerciseTypeToDelete = await _context.ExerciseTypes.FirstOrDefaultAsync(e => e.ExerciseTypeId == id);
            if (excerciseTypeToDelete == null)
            {
                return null;
            }
            _context.ExerciseTypes.Remove(excerciseTypeToDelete);
            await _context.SaveChangesAsync();
            return excerciseTypeToDelete;
        }


    }
}
