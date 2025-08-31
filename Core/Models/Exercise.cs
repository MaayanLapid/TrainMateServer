using System.ComponentModel.DataAnnotations;

namespace TrainMateServer.Core.Models
{
    public class Exercise
    {
        public Guid ExerciseId { get; set; } = Guid.NewGuid();
        public int Repetitions { get; set; }
        public int Sets { get; set; }

        // FK
        public required Guid ExerciseTypeId { get; set; }

        // Navigation property
        public ExerciseType? ExerciseType { get; set; }
    }
}
