using Jadahtzee.Logic;
using System;
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
        private GameLogic logic;
        private List<Logic.Player> playersToAdd;

        public YahtzeeWindow()
        {
            InitializeComponent();
        }

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
                this.cnvMain.Children.RemoveRange(1, this.playersToAdd.Count);
            }
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            //logic.AddPlayer(new Logic.Player(e.ToString()));
        }

        private void btnRemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            //logic.RemovePlayer(0); // 0 for now
        }

        private void btn2NewGame_Click(object sender, RoutedEventArgs e)
        {
            var input = this.txtNewGame.Text;
            if (input != string.Empty)
            {
                playersToAdd = new List<Logic.Player>();
                for (int i = 1; i <= Int32.Parse(input); i++)
                {
                    playersToAdd.Add(new Logic.Player("Player " + i));
                }

                this.AddPlayerToWindow(playersToAdd);
                this.logic = new GameLogic(playersToAdd);
                this.cnvNewGame.Visibility = Visibility.Hidden;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void AddPlayerToWindow(List<Logic.Player> players)
        {
            var index = 0;
            foreach(var player in players)
            {
                var x = index * 230;
                var y = this.expOptions.Height;

                if (index > 4)
                {
                    y = this.expOptions.Height + 305;
                    index = 0;
                    x = index * 230;
                }

                this.cnvMain.Children.Add(new Player(x, y, player));
                index += 1;
            }
        }
    }
}
