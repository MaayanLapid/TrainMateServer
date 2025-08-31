namespace TrainMateServer.Core.Models
{
    public class Workout
    {
        public Guid WorkoutId { get; set; } = Guid.NewGuid();
        public DateTime WorkoutDate { get; set; }

        // FK
        public Guid TraineeId { get; set; }

        // One to one Navigation Property
        public Trainee? Trainee { get; set; }
        // Many to Many Navigation Property
        public ICollection<Exercise> Exercises { get; set; } = [];
    }
}
