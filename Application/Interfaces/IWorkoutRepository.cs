using TrainMateServer.Core.Models;

namespace TrainMateServer.Application.Interfaces
{
    public interface IWorkoutRepository
    {
        Task<List<Workout>> GetAllWorkoutsByTraineeAsync(Guid traineeId, DateTime start, DateTime end);
        Task<Workout?> GetOneWorkoutAsync(Guid id);
        Task<Workout> ReportExerciseAsync(DateTime workoutDate, Trainee trainee, Exercise exercise);
        Task<Workout?> UpdateWorkoutAsync(Guid workoutId, DateTime workoutDate);
        Task<Workout?> DeleteWorkoutAsync(Guid workoutId);
    }
}
