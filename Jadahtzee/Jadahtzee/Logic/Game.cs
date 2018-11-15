using System.Collections.Generic;

namespace Jadahtzee.Logic
{
    public class Game
    {
        public List<Player> Players { get; set; }

        public Game(List<Player> players)
        {
            this.Players = players;
        }
                
        public void AddPlayer(Player newPlayer)
        {
            this.Players.Add(newPlayer);
        }
    }
}
