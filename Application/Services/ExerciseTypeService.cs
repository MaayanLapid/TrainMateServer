using TrainMateServer.Application.Errors;
using TrainMateServer.Application.Interfaces;
using TrainMateServer.Core.Models;

namespace TrainMateServer.Application.Services
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        private readonly IExerciseTypeRepository _exerciseTypeRepository;

        public ExerciseTypeService(IExerciseTypeRepository exerciseTypeRepository)
        {
            _exerciseTypeRepository = exerciseTypeRepository;
        }

        public async Task<List<ExerciseType>> GetAllExerciseTypesAsync()
        {
            return await _exerciseTypeRepository.GetAllExerciseTypesAsync();
        }
        public async Task<ExerciseType?> GetOneExerciseTypeAsync(Guid id)
        {
            return await _exerciseTypeRepository.GetOneExerciseTypeAsync(id);
        }
        public async Task<ExerciseType> CreatExerciseTypeAsync(string exerciseTypeName)
        {
            //var exerciseType = await _exerciseTypeRepository.GetOneExerciseTypeAsync(exerciseTypeId);
            //if (exerciseType == null) throw new BusinessException(ErrorCodes.ExerciseTypeInvalid);

            return await _exerciseTypeRepository.CreatExerciseTypeAsync(exerciseTypeName);
        }
        public async Task<ExerciseType?> UpdateExerciseTypeAsync(Guid id, string exerciseTypeName)
        {
            return await _exerciseTypeRepository.UpdateExerciseTypeAsync(id, exerciseTypeName);
        }
        public async Task<ExerciseType?> DeleteExerciseTypeAsync(Guid id)
        {
            return await _exerciseTypeRepository.DeleteExerciseTypeAsync(id);
        }



    }
}
