using TrainMateServer.Application.Errors;
using TrainMateServer.Application.Interfaces;
using TrainMateServer.Core.Models;

namespace TrainMateServer.Application.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly ITraineeRepository _traineeRepository;

        public WorkoutService (
            IWorkoutRepository workoutRepository,
            IExerciseRepository exerciseRepository,
            ITraineeRepository traineeRepository)
        {
            _workoutRepository = workoutRepository;
            _exerciseRepository = exerciseRepository;
            _traineeRepository = traineeRepository;
        }
        public async Task<List<Workout>> GetAllWorkoutsByTraineeAsync(Guid traineeId, DateTime? start, DateTime? end)
        {
            start = start ?? DateTime.Today.AddDays(-30);
            end = end ?? start.Value.AddDays(30);

            return await _workoutRepository.GetAllWorkoutsByTraineeAsync(traineeId, start.Value, end.Value);
        }

        public async Task<Workout?> GetOneWorkoutAsync(Guid id)
        {
            return await _workoutRepository.GetOneWorkoutAsync(id);
        }

        public async Task<Workout> ReportExerciseAsync(DateTime workoutDate, Guid traineeId, Guid exerciseId)
        {
            var trainee = await _traineeRepository.GetOneAsync(traineeId);
            if (trainee == null) throw new BusinessException(ErrorCodes.TraineeInvalid);

            var exercise = await _exerciseRepository.GetOneExerciseAsync(exerciseId);
            if (exercise == null) throw new BusinessException(ErrorCodes.ExerciseInvalid);

            return await _workoutRepository.ReportExerciseAsync(workoutDate, trainee, exercise);
        }

        public async Task<Workout?> UpdateWorkoutAsync(Guid workoutId, DateTime workoutDate)
        {
            return await _workoutRepository.UpdateWorkoutAsync(workoutId, workoutDate);
        }

        public async Task<Workout?> DeleteWorkoutAsync(Guid id)
        {
            return await _workoutRepository.DeleteWorkoutAsync(id);
        }
    }
}
