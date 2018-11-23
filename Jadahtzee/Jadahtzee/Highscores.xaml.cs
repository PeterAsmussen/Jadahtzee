using System.Windows;
using System.Windows.Controls;

namespace Jadahtzee
{
    /// <summary>
    /// Interaction logic for Highscores.xaml
    /// </summary>
    public partial class Highscores : Window
    {
        private HiHi.Highscores highscores;
        private HiHi.History history;

        public Highscores()
        {
            InitializeComponent();
            this.Init();
            this.FillHighscores();
            this.FillHistory();
        }

        private void Init()
        {
            var io = new HiHi.IO();
            this.highscores = new HiHi.Highscores(io);
            this.history = new HiHi.History(io);
        }

        /// <summary>
        /// Fills the highscores
        /// </summary>
        private void FillHighscores()
        {
            var xMargin = 5.00;
            var entries = this.highscores.currenthighScores;
            entries.Reverse();
            foreach(var entry in entries)
            {
                var txt = this.CreateAlignAndFill(entry.Key.ToString(), entry.Value, true, xMargin);
                this.gridHigh.Children.Add(txt);
                xMargin += 20;
            }
        }

        /// <summary>
        /// Fills the history 
        /// </summary>
        private void FillHistory()
        {
            var xMargin = 5.00;
            var entries = this.history.currenthistory;
            foreach (var entry in entries)
            {
                var txt = this.CreateAlignAndFill(entry.Key.ToString(), entry.Value, false, xMargin);
                this.gridHist.Children.Add(txt);
                xMargin += 20;
            }
        }

        /// <summary>
        /// Creates a textblock.
        /// </summary>
        /// <param name="score">The score</param>
        /// <param name="name">The name</param>
        /// <param name="isHighscore">Highscore if true, history if false</param>
        /// <param name="xMargin">The x margin</param>
        /// <returns>A <see cref="TextBlock"/></returns>
        private TextBlock CreateAlignAndFill(string score, string name, bool isHighscore, double xMargin)
        {
            var txt = new TextBlock
            {
                Text = $"{score} - {name}",
                HorizontalAlignment = isHighscore ? HorizontalAlignment.Center : HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = isHighscore ? new Thickness(0.00, xMargin, 0.00, 0.00) : new Thickness(xMargin == 85.00 ? 127.00 : 2.00, xMargin, 0.00, 0.00)
            };
            
            return txt;
        }

        /// <summary>
        /// Shows the trophies depending on the amount of highscores logged.
        /// </summary>
        /// <param name="entries">The logged scores</param>
        private void Trophies(int entries)
        {
            this.imgGold.Visibility = Visibility.Visible;
            this.imgSilver.Visibility = Visibility.Visible;
            this.imgBronze.Visibility = Visibility.Visible;

            switch (entries)
            {
                case 1:
                    this.imgSilver.Visibility = Visibility.Hidden;
                    this.imgBronze.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    this.imgBronze.Visibility = Visibility.Hidden;
                    break;
            }
        }
    }
}
