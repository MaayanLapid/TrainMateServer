using Microsoft.Identity.Client;
using TrainMateServer.Application.Errors;
using TrainMateServer.Application.Interfaces;
using TrainMateServer.Core.Models;

namespace TrainMateServer.Application.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IExerciseTypeRepository _exerciseTypeRepository;

        public ExerciseService (
            IExerciseRepository exerciseRepository,
            IExerciseTypeRepository exerciseTypeRepository
        )
        {
            _exerciseRepository = exerciseRepository;
            _exerciseTypeRepository = exerciseTypeRepository;
        }
        public async Task<List<Exercise>> GetAllExercisesAsync()
        {
            return await _exerciseRepository.GetAllExercisesAsync();
        }

        public async Task<Exercise?> GetOneExerciseAsync(Guid id)
        {
            return await _exerciseRepository.GetOneExerciseAsync(id, includeType: true);
        }

        public async Task<Exercise> CreatExerciseAsync(Guid exerciseTypeId, int repetitions, int sets)
        {
            var exerciseType = await _exerciseTypeRepository.GetOneExerciseTypeAsync(exerciseTypeId);
            if (exerciseType == null) throw new BusinessException(ErrorCodes.ExerciseTypeInvalid);

            return await _exerciseRepository.CreatExerciseAsync(exerciseType, repetitions, sets);
        }

        public async Task<Exercise?> UpdateExerciseAsync(Guid id, int repetitions, int sets)
        {
            return await _exerciseRepository.UpdateExerciseAsync(id, repetitions, sets);
        }

        public async Task<Exercise?> DeleteExerciseAsync(Guid id)
        {
            return await _exerciseRepository.DeleteExerciseAsync(id);
        }
    }
}
