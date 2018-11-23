using Jadahtzee.Logic;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Jadahtzee
{
    /// <summary>
    /// Interaction logic for YahtzeeWindow.xaml
    /// </summary>
    public partial class YahtzeeWindow : Window
    {
        private Game game;

        private static List<Player> playersToAdd;

        private List<PlayerControl> playerControllers;

        public YahtzeeWindow()
        {
            InitializeComponent();
            this.DefaultWindowSize();
            playersToAdd = new List<Player>();
            this.playerControllers = new List<PlayerControl>();
        }

        /// <summary>
        /// Determines if the game is over or not.
        /// </summary>
        public static void IsGameOver()
        {
            var index = 0;
            var highestScore = 0;
            var winner = string.Empty;
            foreach(var player in playersToAdd)
            {
                var score = player.ScoreTotal;
                if (score > 0)
                {
                    index++;

                    if (score > highestScore)
                    {
                        highestScore = score;
                        winner = player.Name;
                    }
                }
            }

            if (index == playersToAdd.Count)
            {
                new GameOver(new KeyValuePair<int, string>(highestScore, winner));
            }
        }

        /// <summary>
        /// Makes sure the textbox input is numeric.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Draws the players.
        /// </summary>
        /// <param name="players">The players.</param>
        private void DrawPlayerOnCanvas(List<Player> players)
        {
            this.SetWindowSize(players.Count);

            var index = 0;
            var y = this.expOptions.Height + 20;
            var template = new PlayerControl();
            
            foreach (var player in players)
            {
                if (index == 4)
                {
                    y += template.PlayerHeight + 10;
                    index -= 4;
                }

                var playerControl = new PlayerControl(template.PlayerWidth*index, y, player);
                this.playerControllers.Add(playerControl);
                this.cnvMain.Children.Add(playerControl);
                index += 1;
            }
        }

        /// <summary>
        /// Sets the window size.
        /// </summary>
        /// <param name="players">The amount of players.</param>
        private void SetWindowSize(int players)
        {
            if (players >= 4)
            {
                this.Width = 240 * 4 + 25;

                if (players > 4)
                {
                    this.Height = 800;
                }
            }
            else if (players == 1)
            {
                this.DefaultWindowSize();
            }
            else
            {
                this.Width = (250 * players) + (2 * players);
            }

            this.MinWidth = this.MaxWidth = this.Width;
            this.MinHeight = this.MaxHeight = this.Height;
        }

        /// <summary>
        /// Resets the window size to the default.
        /// </summary>
        private void DefaultWindowSize()
        {
            this.Height = this.MinHeight = this.MaxHeight = 500;
            this.Width = this.MinWidth = this.MaxWidth = 265;
        }

        /// <summary>
        /// Sets the window when a new game is initiated.
        /// </summary>
        /// <param name="isFromMenu">Is the buttonpress from the options menu</param>
        private void InitWindow(bool isFromMenu)
        {
            switch (isFromMenu)
            {
                case true:
                    this.cnvNewGame.Visibility = Visibility.Visible;
                    this.expOptions.IsExpanded = false;
                    this.cnvMain.Children.RemoveRange(0, playersToAdd.Count);
                    this.playerControllers.Clear();
                    playersToAdd.Clear();
                    this.DefaultWindowSize();
                    break;
                case false:
                    this.SetWindowSize(playersToAdd.Count);
                    this.DrawPlayerOnCanvas(playersToAdd);
                    this.game = new Game(playersToAdd);
                    this.cnvNewGame.Visibility = Visibility.Hidden;
                    break;
            }
        }

        #region Button handlers
        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to start a new game?", 
                "Confirmation", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Exclamation);

            if (result == MessageBoxResult.Yes)
            {
                this.InitWindow(true);
            }
        }

        private void btn2NewGame_Click(object sender, RoutedEventArgs e)
        {
            var input = this.txtNewGame.Text;
            if (GameLogic.TryParse(input) > 8)
            {
                MessageBox.Show("A maximum of 8 players are allowed. Sorry :(");
            }
            else if (input != string.Empty)
            {
                for (int i = 1; i <= GameLogic.TryParse(input); i++)
                {
                    var name = Microsoft.VisualBasic.Interaction.InputBox($"Enter a name for player {i}!","Names", $"Player{i}");
                    playersToAdd.Add(new Player(name.ToString()));
                }

                this.InitWindow(false);
            }
        }

        private void btnResetGame_Click(object sender, RoutedEventArgs e)
        {
            foreach (var control in this.playerControllers)
            {
                control.Reset();
                control.IsEnabled = true;
            }
        }

        private void btnHighscores_Click(object sender, RoutedEventArgs e)
        {
            new Highscores().Show();
        }
        #endregion
    }
}
