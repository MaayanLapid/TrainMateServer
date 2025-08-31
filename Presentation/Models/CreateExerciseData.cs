namespace TrainMateServer.Presentation.Models
{
    public class CreateExerciseData
    {
        public int Repetitions { get; set; }
        public int Sets { get; set; }
        public required Guid ExerciseTypeId { get; set; }
    }
}
