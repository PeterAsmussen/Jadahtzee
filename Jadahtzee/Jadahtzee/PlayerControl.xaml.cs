using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Jadahtzee
{
    /// <summary>
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        public PlayerControl(double x, double y, Logic.Player player)
        {
            InitializeComponent();
            this.RenderTransform = this.Transform(x, y);
            this.grpbPlayer.Header = player.Name;
        }

        public void Reset()
        {
            Logic.GameLogic.ResetPlayer(this);
        }

        /// <summary>
        /// Sets the dimensions of the player control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void player_Load(object sender, EventArgs e)
        {
            this.Height = 300;
            this.Width = 230;
        }

        /// <summary>
        /// Sets the position of the player control.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private TranslateTransform Transform(double x, double y)
        {
            var transform = new TranslateTransform();
            transform.X = x;
            transform.Y = y;
            return transform;
        }
        
        /// <summary>
        /// Validate the textbox input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Handles processing of upper section of the yahtzee paper.
        /// </summary>
        /// <param name="value">The value.</param>
        private void ProcessUpper()
        {
            Logic.GameLogic.AddToTotalUpper(this);

            if (Logic.GameLogic.IsDoneUpper(this))
            {
                Logic.GameLogic.SumAllUpper(this);
                Logic.GameLogic.ApplyBonus(this);
                this.ProcessLower();
                return;
            }

            this.txtBonus.Text = "";
        }

        /// <summary>
        /// Process the lower section of the yahtzee paper.
        /// </summary>
        private void ProcessLower()
        {
            Logic.GameLogic.AddToTotal(this);
        }

        #region Textbox handling for upper region
        private void txtAces_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessUpper();
        }

        private void txtTwos_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessUpper();
        }

        private void txtThrees_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessUpper();
        }

        private void txtFours_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessUpper();
        }

        private void txtFives_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessUpper();
        }

        private void txtSixes_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessUpper();
        }

        #endregion

        #region Textbox handling for total score
        private void txtToaK_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessLower();
        }

        private void txtFoaK_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessLower();
        }

        private void txtFH_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessLower();
        }

        private void txtSmall_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessLower();
        }

        private void txtLarge_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessLower();
        }

        private void txtYahtzee_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessLower();
        }

        private void txtChance_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessLower();
        }
        #endregion
    }
}
