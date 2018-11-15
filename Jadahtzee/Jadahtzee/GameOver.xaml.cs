using System.Collections.Generic;
using System.Windows.Controls;

namespace Jadahtzee
{
    /// <summary>
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : UserControl
    {
        public GameOver(KeyValuePair<int, string> winner)
        {
            InitializeComponent();

            var io = new HiHi.IO();
            io.CreateFiles();

            var hs = new HiHi.Highscores(io);
            var his = new HiHi.History(io);

            hs.WriteToFile(winner);
            his.WriteToFile(winner);
        }
    }
}
