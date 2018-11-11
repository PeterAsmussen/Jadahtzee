using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jadahtzee.Logic
{
    public class GameLogic
    {
        public List<Player> Players { get; set; }

        public GameLogic(List<Player> players)
        {
            this.Players = players;
        }
                
        public void AddPlayer(Player newPlayer)
        {
            this.Players.Add(newPlayer);
        }

        public void RemovePlayer(int index)
        {
            this.Players.RemoveAt(index);
        }
    }
}
