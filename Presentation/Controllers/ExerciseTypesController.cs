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
    public class ExerciseTypesController : ControllerBase
    {
        private readonly IExerciseTypeService _exerciseTypeService;

        public ExerciseTypesController (IExerciseTypeService exerciseTypeService)
        {
            _exerciseTypeService = exerciseTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _exerciseTypeService.GetAllExerciseTypesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            ExerciseType? exerciseTypeToReturn = await _exerciseTypeService.GetOneExerciseTypeAsync(id);
            if (exerciseTypeToReturn == null)
            {
                return NotFound();
            }
            return Ok(exerciseTypeToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExcerciseType([FromBody] CreateExerciseTypeData data)
        {
            if (!ModelState.IsValid) return BadRequest();

            ExerciseType exerciseTypeToReturn = await _exerciseTypeService.CreatExerciseTypeAsync(data.ExerciseTypeName);

            return CreatedAtAction(nameof(GetById), new { id = exerciseTypeToReturn.ExerciseTypeId }, exerciseTypeToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExcerciseType(Guid id, [FromBody] UpdateExerciseTypeData data)
        {
            if (!ModelState.IsValid) return BadRequest();

            ExerciseType? updatedExcerciseType = await _exerciseTypeService.UpdateExerciseTypeAsync(id, data.ExerciseTypeName);
            if (updatedExcerciseType == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExcerciseType(Guid id)
        {
            ExerciseType? removedExcerciseType = await _exerciseTypeService.DeleteExerciseTypeAsync(id);
            if (removedExcerciseType == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
