using System;

namespace Leaderboard.Models
{
public class Player
    {
        public Player(){

        }
        public Guid Id {get; set;}
        public string Name {get; set;}
        public int Score {get; set;}
        public DateTime CreationTime {get; set;}
    }
}