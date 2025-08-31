using Microsoft.AspNetCore.Mvc;
using TrainMateServer.Core.Models;

namespace TrainMateServer.Application.Interfaces
{
    public interface ITraineeService
    {
        Task<List<Trainee>> GetAllAsync();
        Task<Trainee?> GetOneAsync(Guid id);
        Task<Trainee> CreateAsync(Trainee trainee);
        Task<Trainee?> UpdateAsync(Guid id, Trainee trainee);
        Task<Trainee?> DeleteAsync(Guid id);
    }
}
