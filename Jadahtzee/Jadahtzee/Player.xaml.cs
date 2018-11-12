using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace Jadahtzee
{
    /// <summary>
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class Player : UserControl
    {

        public Player(double x, double y, Logic.Player player)
        {
            InitializeComponent();
            this.RenderTransform = this.Transform(x, y);
        }

        private void player_Load(object sender, EventArgs e)
        {
            this.Height = 300;
            this.Width = 230;
        }

        private TranslateTransform Transform(double x, double y)
        {
            var transform = new TranslateTransform();
            transform.X = x;
            transform.Y = y;
            return transform;
        }
    }
}
