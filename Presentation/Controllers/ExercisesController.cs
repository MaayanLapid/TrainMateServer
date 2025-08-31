using Microsoft.AspNetCore.Mvc;
using TrainMateServer.Application.Interfaces;
using TrainMateServer.Application.Services;
using TrainMateServer.Core.Models;
using TrainMateServer.Presentation.Models;

namespace TrainMateServer.Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _exerciseService.GetAllExercisesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            Exercise? exerciseToReturn = await _exerciseService.GetOneExerciseAsync(id);
            if (exerciseToReturn == null)
            {
                return NotFound();
            }
            return Ok(exerciseToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExcercise([FromBody] CreateExerciseData data)
        {
            if (!ModelState.IsValid) return BadRequest();

            Exercise exerciseToReturn = await _exerciseService.CreatExerciseAsync(data.ExerciseTypeId, data.Repetitions, data.Sets);
            
            return CreatedAtAction(nameof(GetById), new { id = exerciseToReturn.ExerciseId }, exerciseToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExcercise(Guid id, [FromBody] UpdateExerciseData data)
        {
            if (!ModelState.IsValid) return BadRequest();

            Exercise? updatedExcercise = await _exerciseService.UpdateExerciseAsync(id, data.Repetitions, data.Sets);
            if (updatedExcercise == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExcercise(Guid id)
        {
            Exercise? removedExcercise = await _exerciseService.DeleteExerciseAsync(id);
            if (removedExcercise == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
