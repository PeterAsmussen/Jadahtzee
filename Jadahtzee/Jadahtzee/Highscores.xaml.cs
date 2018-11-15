using System.Windows.Controls;

namespace Jadahtzee
{
    /// <summary>
    /// Interaction logic for Highscores.xaml
    /// </summary>
    public partial class Highscores : UserControl
    {
        private HiHi.Highscores highscores;
        private HiHi.History history;

        public Highscores()
        {
            InitializeComponent();
            this.Init();
        }

        private void Init()
        {
            var io = new HiHi.IO();
            this.highscores = new HiHi.Highscores(io);
            this.history = new HiHi.History(io);
        }
    }
}
