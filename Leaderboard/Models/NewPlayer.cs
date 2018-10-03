using System;

namespace Leaderboard.Models
{
    public class NewPlayer
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name {get; set;}
        [Required]
        [Range(1,999)]
        public int Score {get; set;}
    }
}
