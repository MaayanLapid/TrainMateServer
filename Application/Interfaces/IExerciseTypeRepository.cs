using TrainMateServer.Core.Models;

namespace TrainMateServer.Application.Interfaces
{
    public interface IExerciseTypeRepository
    {
        Task<List<ExerciseType>> GetAllExerciseTypesAsync();
        Task<ExerciseType?> GetOneExerciseTypeAsync(Guid id);
        Task<ExerciseType> CreatExerciseTypeAsync(string exerciseTypeName);
        Task<ExerciseType?> UpdateExerciseTypeAsync(Guid id, string exerciseTypeName);
        Task<ExerciseType?> DeleteExerciseTypeAsync(Guid id);
    }
}
