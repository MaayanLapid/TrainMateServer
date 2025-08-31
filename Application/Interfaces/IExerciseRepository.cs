using TrainMateServer.Core.Models;

namespace TrainMateServer.Application.Interfaces
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAllExercisesAsync();
        Task<Exercise?> GetOneExerciseAsync(Guid id, bool includeType = false);
        Task<Exercise> CreatExerciseAsync(ExerciseType exerciseType, int repetitions, int sets);
        Task<Exercise?> UpdateExerciseAsync(Guid id, int repetitions, int sets);
        Task<Exercise?> DeleteExerciseAsync(Guid id);
    }
}
