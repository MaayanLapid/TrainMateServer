using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TrainMateServer.Application.Errors;
using TrainMateServer.Application.Interfaces;
using TrainMateServer.Core.Models;
using TrainMateServer.Infrastructure.Data;

namespace TrainMateServer.Application.Services
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly TrainMateDbContext _context;
        private readonly ILogger<TraineeRepository> _logger;

        public TraineeRepository(TrainMateDbContext context, ILogger<TraineeRepository> logger) 
        { 
            _context = context;
            _logger = logger;
        }

        public async Task<List<Trainee>> GetAllAsync()
        {
            return await _context.Trainees.ToListAsync();
        }

        public async Task<Trainee?> GetOneAsync(Guid id)
        {
           return await _context.Trainees.FirstOrDefaultAsync(t => t.TraineeId == id);
        }

        public async Task<Trainee> CreateAsync(Trainee trainee)
        {
            //try
            //{
            trainee.TraineeId = Guid.NewGuid();

            _context.Trainees.Add(trainee);
            await _context.SaveChangesAsync();
            return trainee;
            //}
            //catch (DbUpdateException ex) when (ex.InnerException is SqlException {
            //    Number: 2627 or // Primary Key violation
            //            2601    // Unique Constraint violation
            //})
            //{
            //    throw new BusinessException(ErrorCodes.TraineeExists);
            //}
        }

        public async Task<Trainee?> UpdateAsync(Guid id, Trainee trainee)
        {
            Trainee? traineeToUpdate = await _context.Trainees.FirstOrDefaultAsync(t => t.TraineeId == id);
            if (traineeToUpdate == null)
            {
                return null;
            }
            traineeToUpdate.TraineeName = trainee.TraineeName;
            traineeToUpdate.Password = trainee.Password;
            await _context.SaveChangesAsync();

            return traineeToUpdate;
        }

        public async Task<Trainee?> DeleteAsync(Guid id)
        {
            Trainee? traineeToDelete = await _context.Trainees.FirstOrDefaultAsync(t => t.TraineeId == id);
            if (traineeToDelete == null)
            {
                return null;
            }
            _context.Trainees.Remove(traineeToDelete);
            await _context.SaveChangesAsync();
            return traineeToDelete;
        }
    }
}
