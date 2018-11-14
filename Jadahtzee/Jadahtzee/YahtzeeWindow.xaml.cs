using Jadahtzee.Logic;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Jadahtzee
{
    /// <summary>
    /// Interaction logic for YahtzeeWindow.xaml
    /// </summary>
    public partial class YahtzeeWindow : Window
    {
        private Game game;

        private List<Player> playersToAdd;

        private List<PlayerControl> playerControllers;

        public YahtzeeWindow()
        {
            InitializeComponent();

            this.ResetWindowSize();

            this.playersToAdd = new List<Player>();
            this.playerControllers = new List<PlayerControl>();
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
            foreach (var player in players)
            {
                var x = index * 240;

                if (index == 4)
                {
                    y += 305;
                    index -= 4;
                    x = index * 230;
                }

                var playerControl = new PlayerControl(x, y, player);
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
        private void ResetWindowSize()
        {
            this.Height = this.MinHeight = this.MaxHeight = 500;
            this.Width = this.MinWidth = this.MaxWidth = 350;
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
                this.cnvNewGame.Visibility = Visibility.Visible;
                this.expOptions.IsExpanded = false;
                this.cnvMain.Children.RemoveRange(0, this.playersToAdd.Count);
                this.ResetWindowSize();
            }
        }

        private void btn2NewGame_Click(object sender, RoutedEventArgs e)
        {
            var input = this.txtNewGame.Text;
            if (input != string.Empty)
            {
                for (int i = 1; i <= Int32.Parse(input); i++)
                {
                    var name = Microsoft.VisualBasic.Interaction.InputBox($"Enter a name for player {i}!","Names","[name goes here]");
                    playersToAdd.Add(new Player(name.ToString()));
                }

                this.DrawPlayerOnCanvas(playersToAdd);
                this.game = new Game(playersToAdd);
                this.cnvNewGame.Visibility = Visibility.Hidden;
            }
        }

        private void btnResetGame_Click(object sender, RoutedEventArgs e)
        {
            foreach (var control in this.playerControllers)
            {
                control.Reset();
            }
        }
        #endregion
    }
}
