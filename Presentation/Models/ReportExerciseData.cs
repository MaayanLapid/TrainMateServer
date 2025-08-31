namespace TrainMateServer.Presentation.Models
{
    public class ReportExerciseData
    {
        public DateTime workoutDate { get; set; }
        public Guid traineeId { get; set; }
        public Guid exerciseId { get; set; }
    }
}
