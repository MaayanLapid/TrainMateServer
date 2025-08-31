using Microsoft.AspNetCore.Mvc;
using TrainMateServer.Application.Interfaces;
using TrainMateServer.Application.Services;
using TrainMateServer.Core.Models;
using TrainMateServer.Presentation.Filters;

namespace TrainMateServer.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    // try catch for every request
    [CustomExceptionFilter]
    public class TraineesController : ControllerBase
    {
        private readonly ITraineeService _traineeService;
        private readonly IWorkoutService _workoutService;

        public TraineesController(ITraineeService traineeService, IWorkoutService workoutService)
        {
            _traineeService = traineeService;
            _workoutService = workoutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainees()
        {
            return Ok(await _traineeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTraineeById([FromRoute] Guid id)
        {
            Trainee? traineeToReturn = await _traineeService.GetOneAsync(id);
            if (traineeToReturn == null)
            {
                return NotFound();
            }
            return Ok(traineeToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainee([FromBody] Trainee trainee)
        {
            if (!ModelState.IsValid) return BadRequest();

            Trainee traineeToReturn = await _traineeService.CreateAsync(trainee);

            return CreatedAtAction(nameof(GetTraineeById), new { id = traineeToReturn.TraineeId }, traineeToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainee(Guid id, [FromBody] Trainee trainee)
        {
            if (!ModelState.IsValid) return BadRequest();

            Trainee? updatedTrainee = await _traineeService.UpdateAsync(id, trainee);
            if (updatedTrainee == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainee(Guid id)
        {
            Trainee? removedTrainee = await _traineeService.DeleteAsync(id);
            if (removedTrainee == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id}/workouts")]
        public async Task<IActionResult> Get(Guid id, [FromQuery] DateTime? start, [FromQuery] DateTime? end)
        {
            return Ok(await _workoutService.GetAllWorkoutsByTraineeAsync(id, start, end));
        }
    }
}
