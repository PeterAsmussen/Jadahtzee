using System.Collections.Generic;
using System.Windows;

namespace Jadahtzee
{
    /// <summary>
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : Window
    {
        public GameOver(Logic.Player player)
        {
            var winner = new KeyValuePair<int, string>(player.ScoreTotal, player.Name);
            InitializeComponent();
            this.HandleIO(winner);
            this.WriteWinner(winner);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void WriteWinner(KeyValuePair<int, string> winner)
        {
            this.txtWinner.Text = $"{winner.Value} won with {winner.Key} points!";
        }

        private void HandleIO(KeyValuePair<int, string> winner)
        {
            var io = new HiHi.IO();
            io.CreateFiles();

            var hs = new HiHi.Highscores(io);
            var his = new HiHi.History(io);

            hs.WriteToFile(winner);
            his.WriteToFile(winner);
        }
    }
}
