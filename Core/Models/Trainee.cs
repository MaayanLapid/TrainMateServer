using System.ComponentModel.DataAnnotations;

namespace TrainMateServer.Core.Models
{
    public class Trainee
    {
        public Guid TraineeId { get; set; } = Guid.NewGuid();
        [MaxLength(50)]
        public required string TraineeName { get; set; }
        [MinLength(8), MaxLength(50)]
        public required string Password { get; set; }
    }
}
