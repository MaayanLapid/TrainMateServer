namespace TrainMateServer.Presentation.Models
{
    public class CreateExerciseTypeData
    {
        public Guid ExerciseTypeId { get; set; }
        public required string ExerciseTypeName { get; set; }
    }
}
