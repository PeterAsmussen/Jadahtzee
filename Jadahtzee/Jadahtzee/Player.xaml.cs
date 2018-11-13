using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Jadahtzee
{
    /// <summary>
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class Player : UserControl
    {

        private bool HasFinishedUpper;

        public Player(double x, double y, Logic.Player player)
        {
            InitializeComponent();
            this.RenderTransform = this.Transform(x, y);
            this.grpbPlayer.Header = player.Name;
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
        /// Adds an amount of points to the total of the upper section of the yahtzee paper.
        /// </summary>
        /// <param name="points"></param>
        private void AddToTotalUpper()
        {
            this.txtTotalUpper.Text = SumAllUpper().ToString();
        }

        /// <summary>
        /// Adds an amount of points to the total score.
        /// </summary>
        /// <param name="points"></param>
        private void AddToTotal()
        {
            this.txtTotal.Text = SumAll().ToString();
        }

        /// <summary>
        /// Tries to parse an input string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The parsed value.</returns>
        private int TryParse(string input)
        {
            if (Int32.TryParse(input, out int result))
            {
                return result;
            }

            return 0;
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
        /// Handles the bonus of the upper section of the yahtzee paper.
        /// </summary>
        /// <param name="value"></param>
        private void IsBonusValid(int value)
        {
            if (value > 62)
            {
                this.txtBonus.Text = 50.ToString();
                return;
            }

            this.txtBonus.Text = "";
        }

        /// <summary>
        /// Calculates the total of the upper section of the yahtzee paper.
        /// </summary>
        private void CalculateTotalUpper()
        {
            IsBonusValid(SumAllUpper());
        }

        /// <summary>
        /// Sums all values of the upper section of the yahtzee paper.
        /// </summary>
        /// <returns></returns>
        private int SumAllUpper()
        {
            var totalUpper = 0;
            totalUpper += this.TryParse(this.txtAces.Text);
            totalUpper += this.TryParse(this.txtTwos.Text);
            totalUpper += this.TryParse(this.txtThrees.Text);
            totalUpper += this.TryParse(this.txtFours.Text);
            totalUpper += this.TryParse(this.txtFives.Text);
            totalUpper += this.TryParse(this.txtSixes.Text);
            return totalUpper;
        }

        /// <summary>
        /// Sums all values on the yahtzee paper.
        /// </summary>
        /// <returns></returns>
        private int SumAll()
        {
            var total = this.SumAllUpper();
            total += this.TryParse(this.txtBonus.Text);
            total += this.TryParse(this.txtToaK.Text);
            total += this.TryParse(this.txtFoaK.Text);
            total += this.TryParse(this.txtFH.Text);
            total += this.TryParse(this.txtSmall.Text);
            total += this.TryParse(this.txtLarge.Text);
            total += this.TryParse(this.txtYahtzee.Text);
            total += this.TryParse(this.txtChance.Text);
            return total;
        }

        /// <summary>
        /// Checks if all of the upper section is done.
        /// </summary>
        /// <param name="value"></param>
        private bool IsDoneUpper()
        {
            if (!string.IsNullOrEmpty(this.txtAces.Text) &&
                !string.IsNullOrEmpty(this.txtTwos.Text) &&
                !string.IsNullOrEmpty(this.txtThrees.Text) &&
                !string.IsNullOrEmpty(this.txtFours.Text) &&
                !string.IsNullOrEmpty(this.txtFives.Text) &&
                !string.IsNullOrEmpty(this.txtSixes.Text)
                )
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Handles processing of upper section of the yahtzee paper.
        /// </summary>
        /// <param name="value">The value.</param>
        private void ProcessUpper()
        {
            this.AddToTotalUpper();

            if (this.IsDoneUpper())
            {
                this.CalculateTotalUpper();
                this.HasFinishedUpper = true;
                return;
            }

            this.txtBonus.Text = "";
        }

        /// <summary>
        /// Process the lower section of the yahtzee paper.
        /// </summary>
        private void ProcessLower()
        {
            this.AddToTotal();
        }

        #region Textbox handling for upper region
        private void txtAces_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessUpper();

            if (this.HasFinishedUpper)
            {
                this.AddToTotal();
            }
        }

        private void txtTwos_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessUpper();

            if (this.HasFinishedUpper)
            {
                this.AddToTotal();
            }
        }

        private void txtThrees_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessUpper();

            if (this.HasFinishedUpper)
            {
                this.AddToTotal();
            }
        }

        private void txtFours_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessUpper();

            if (this.HasFinishedUpper)
            {
                this.AddToTotal();
            }
        }

        private void txtFives_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessUpper();

            if (this.HasFinishedUpper)
            {
                this.AddToTotal();
            }
        }

        private void txtSixes_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.ProcessUpper();

            if (this.HasFinishedUpper)
            {
                this.AddToTotal();
            }
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
