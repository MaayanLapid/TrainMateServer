namespace TrainMateServer.Core.Models
{
    public class ExerciseType
    {
        public Guid ExerciseTypeId { get; set; } = Guid.NewGuid();
        public required string ExerciseTypeName { get; set; }
    }
}
