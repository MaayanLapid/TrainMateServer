using TrainMateServer.Application.Interfaces;
using TrainMateServer.Core.Models;

namespace TrainMateServer.Application.Services
{
    public class TraineeService : ITraineeService
    {

        private readonly ITraineeRepository _traineeRepository;

        public TraineeService(ITraineeRepository traineeRepository)
        {
            _traineeRepository = traineeRepository;
        }

        public async Task<List<Trainee>> GetAllAsync()
        {
            return await _traineeRepository.GetAllAsync();
        }
        public async Task<Trainee?> GetOneAsync(Guid id)
        {
            return await _traineeRepository.GetOneAsync(id);
        }
        public async Task<Trainee> CreateAsync(Trainee trainee)
        {
            return await _traineeRepository.CreateAsync(trainee);
        }
        public async Task<Trainee?> UpdateAsync(Guid id, Trainee trainee)
        {
            return await _traineeRepository.UpdateAsync(id, trainee);
        }
        public async Task<Trainee?> DeleteAsync(Guid id)
        {
            return await _traineeRepository.DeleteAsync(id);
        }
    }
}
