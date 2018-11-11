using Jadahtzee.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jadahtzee
{
    /// <summary>
    /// Interaction logic for YahtzeeWindow.xaml
    /// </summary>
    public partial class YahtzeeWindow : Window
    {
        private GameLogic logic;

        public YahtzeeWindow()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            this.logic = new GameLogic(null);
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            logic.AddPlayer(new Player(e.ToString()));
        }

        private void btnRemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            logic.RemovePlayer(0); // 0 for now
        }

        private void btn2NewGame_Click(object sender, RoutedEventArgs e)
        {
            this.logic = new GameLogic(null);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
