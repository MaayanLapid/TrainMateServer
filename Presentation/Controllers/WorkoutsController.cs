using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainMateServer.Application.Interfaces;
using TrainMateServer.Application.Services;
using TrainMateServer.Core.Models;
using TrainMateServer.Presentation.Models;

namespace TrainMateServer.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutsController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkoutById([FromRoute] Guid id)
        {
            Workout? workoutToReturn = await _workoutService.GetOneWorkoutAsync(id);
            if (workoutToReturn == null)
            {
                return NotFound();
            }
            return Ok(workoutToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> ReportExercise([FromBody] ReportExerciseData data)
        {
            if (!ModelState.IsValid) return BadRequest();

            Workout workoutToReturn = await _workoutService.ReportExerciseAsync(data.workoutDate, data.traineeId, data.exerciseId);

            return CreatedAtAction(nameof(GetWorkoutById), new { id = workoutToReturn.WorkoutId }, workoutToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWorkout(Guid id, [FromBody] UpdateWorkoutData data)
        {
            if (!ModelState.IsValid) return BadRequest();

            Workout? updatedWorkout = await _workoutService.UpdateWorkoutAsync(id, data.workoutDate);
            if (updatedWorkout == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(Guid id)
        {
            Workout? removedWorkout = await _workoutService.DeleteWorkoutAsync(id);
            if (removedWorkout == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("by-trainee")] 
        public async Task<IActionResult> GetByTrainee(
    [FromQuery] Guid traineeId,
    [FromQuery] DateTime? start,
    [FromQuery] DateTime? end)
        {
            if (traineeId == Guid.Empty)
                return BadRequest("traineeId is required");

            var items = await _workoutService.GetAllWorkoutsByTraineeAsync(traineeId, start, end);
            return Ok(items);
        }



    }
}
