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
        private Logic.Player player;
        
        /// <summary>
        /// Constructor for initializing the size of the user control.
        /// </summary>
        public PlayerControl() { this.Height = 300; this.Width = 240; }

        /// <summary>
        /// Constructor for initializing the user control objects that will be used in the game.
        /// </summary>
        /// <param name="x">The x position</param>
        /// <param name="y">The y position</param>
        /// <param name="player">The name</param>
        public PlayerControl(double x, double y, Logic.Player player)
        {
            InitializeComponent();
            this.RenderTransform = this.Transform(x, y);
            this.grpbPlayer.Header = player.Name;
            this.player = player;
        }

        public bool IsDoneUpper { get; set; }
        
        public double PlayerWidth { get { return this.Width; } }

        public double PlayerHeight { get { return this.Height; } }

        /// <summary>
        /// Resets the player on the current game.
        /// </summary>
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
                this.IsDoneUpper = true;
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

        private void WasCut(TextBox textbox)
        {
            textbox.Text = "0";
            textbox.IsEnabled = false;
        }

        #region Textbox handling for upper region
        private void txtAces_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ProcessUpper();
        }

        private void txtTwos_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ProcessUpper();
        }

        private void txtThrees_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ProcessUpper();
        }

        private void txtFours_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ProcessUpper();
        }

        private void txtFives_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ProcessUpper();
        }

        private void txtSixes_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ProcessUpper();
        }

        #endregion

        #region Textbox handling for total score
        private void txtToaK_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ProcessLower();

            if (Logic.GameLogic.IsPlayerFinished(this))
            {
                this.player.ScoreTotal = Logic.GameLogic.TryParse(this.txtTotal.Text);
                this.IsEnabled = false;
            }
        }

        private void txtFoaK_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ProcessLower();

            if (Logic.GameLogic.IsPlayerFinished(this))
            {
                this.player.ScoreTotal = Logic.GameLogic.TryParse(this.txtTotal.Text);
                this.IsEnabled = false;
            }
        }

        private void txtFH_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ProcessLower();

            if (Logic.GameLogic.IsPlayerFinished(this))
            {
                this.player.ScoreTotal = Logic.GameLogic.TryParse(this.txtTotal.Text);
                this.IsEnabled = false;
            }
        }

        private void txtSmall_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ProcessLower();

            if (Logic.GameLogic.IsPlayerFinished(this))
            {
                this.player.ScoreTotal = Logic.GameLogic.TryParse(this.txtTotal.Text);
                this.IsEnabled = false;
            }
        }

        private void txtLarge_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ProcessLower();

            if (Logic.GameLogic.IsPlayerFinished(this))
            {
                this.player.ScoreTotal = Logic.GameLogic.TryParse(this.txtTotal.Text);
                this.IsEnabled = false;
            }
        }

        private void txtYahtzee_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ProcessLower();

            if (Logic.GameLogic.IsPlayerFinished(this))
            {
                this.player.ScoreTotal = Logic.GameLogic.TryParse(this.txtTotal.Text);
                this.IsEnabled = false;
            }
        }

        private void txtChance_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.ProcessLower();

            if (Logic.GameLogic.IsPlayerFinished(this))
            {
                this.player.ScoreTotal = Logic.GameLogic.TryParse(this.txtTotal.Text);
                this.IsEnabled = false;
            }
        }
        #endregion

        #region Checkbox handling
        private void chkAces_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WasCut(this.txtAces);
        }

        private void chkTwos_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WasCut(this.txtTwos);
        }

        private void chkThrees_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WasCut(this.txtThrees);
        }

        private void chkFours_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WasCut(this.txtFours);
        }

        private void chkFives_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WasCut(this.txtFives);
        }

        private void chkSixes_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WasCut(this.txtSixes);
        }

        private void chkToaK_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WasCut(this.txtToaK);
        }

        private void chkFoaK_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WasCut(this.txtFoaK);
        }

        private void chkFH_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WasCut(this.txtFH);
        }

        private void chkSmall_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WasCut(this.txtSmall);
        }

        private void chkLarge_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WasCut(this.txtLarge);
        }

        private void chkYahtzee_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WasCut(this.txtYahtzee);
        }

        private void chkChance_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WasCut(this.txtChance);
        }
        #endregion 

        private void ucPlayer_IsEnabledChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (Logic.GameLogic.IsGameOver(YahtzeeWindow.GetPlayers))
            {
                new GameOver(Logic.GameLogic.GetWinner()).Show();
            }
        }
    }
}
