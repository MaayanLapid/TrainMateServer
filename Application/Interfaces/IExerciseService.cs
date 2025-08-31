using TrainMateServer.Core.Models;

namespace TrainMateServer.Application.Interfaces
{
    public interface IExerciseService
    {
        Task<List<Exercise>> GetAllExercisesAsync();
        Task<Exercise?> GetOneExerciseAsync(Guid id);
        Task<Exercise> CreatExerciseAsync(Guid exerciseTypeId, int repetitions, int sets);
        Task<Exercise?> UpdateExerciseAsync(Guid id, int repetitions, int sets);
        Task<Exercise?> DeleteExerciseAsync(Guid id);
    }
}
