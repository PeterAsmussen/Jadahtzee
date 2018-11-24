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
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
            var entries = this.highscores.currenthighScores;
            var xMargin = 5.00;
            if (entries == null)
            {
                this.gridHigh.Children.Add(this.CreateAlignAndFill("Sorry", "No scores yet :(", true, xMargin));
                this.Trophies(0);
            }
            else
            {
                entries.Reverse();
                foreach (var entry in entries)
                {
                    this.gridHigh.Children.Add(this.CreateAlignAndFill(entry.Key.ToString(), entry.Value, true, xMargin));
                    xMargin += 20;
                }

                this.Trophies(entries.Count);
            }
        }

        /// <summary>
        /// Fills the history 
        /// </summary>
        private void FillHistory()
        {
            var entries = this.history.currenthistory;
            var xMargin = 5.00;
            if (entries == null)
            {
                this.gridHist.Children.Add(this.CreateAlignAndFill("Sorry", "No history yet :(", true, xMargin));
                this.Trophies(0);
            }
            else
            {
                var index = 0;
                foreach (var entry in entries)
                {
                    if (xMargin > 85.00)
                    {
                        xMargin = 5.00;
                    }

                    if (index > 4)
                    {
                        this.gridHist.Children.Add(this.CreateAlignAndFill(entry.Key.ToString(), entry.Value, false, xMargin, 127.00));
                    }
                    else
                    {
                        this.gridHist.Children.Add(this.CreateAlignAndFill(entry.Key.ToString(), entry.Value, false, xMargin));
                    }

                    xMargin += 20.00;
                    index++;
                }

                this.Trophies(entries.Count);
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
        private TextBlock CreateAlignAndFill(string score, string name, bool center, double xMargin, double yMargin = 0.00)
        {
            var txt = new TextBlock
            {
                Text = $"{score} - {name}",
                HorizontalAlignment = center ? HorizontalAlignment.Center : HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(yMargin, xMargin, 0.00, 0.00)
            };
            
            return txt;
        }

        /// <summary>
        /// Shows the trophies depending on the amount of highscores logged.
        /// </summary>
        /// <param name="entries">The logged scores</param>
        private void Trophies(int entries)
        {
            switch (entries)
            {
                case 0:
                    this.imgGold.Visibility = Visibility.Hidden;
                    this.imgSilver.Visibility = Visibility.Hidden;
                    this.imgBronze.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    this.imgSilver.Visibility = Visibility.Hidden;
                    this.imgBronze.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    this.imgBronze.Visibility = Visibility.Hidden;
                    break;
                default:
                    this.imgGold.Visibility = Visibility.Visible;
                    this.imgSilver.Visibility = Visibility.Visible;
                    this.imgBronze.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
