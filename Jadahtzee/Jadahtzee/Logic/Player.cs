namespace Jadahtzee.Logic
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public int ScoreUpper { get; set; }

        public int ScoreTotal { get; set; }
    }
}
