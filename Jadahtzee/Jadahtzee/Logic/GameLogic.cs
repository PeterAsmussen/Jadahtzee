using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Jadahtzee.Logic
{
    public class GameLogic
    {
        private static Player _player;

        public GameLogic() { }
        
        /// <summary>
        /// Tries to parse an input string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The parsed value.</returns>
        public static int TryParse(string input)
        {
            if (Int32.TryParse(input, out int result))
            {
                return result;
            }

            return 0;
        }

        /// <summary>
        /// Sums all values of the upper section of the yahtzee paper.
        /// </summary>
        /// <param name="player">The player to calculate</param>
        /// <returns>The sum</returns>
        public static int SumAllUpper(PlayerControl player)
        {
            return
                TryParse(player.txtAces.Text) +
                TryParse(player.txtTwos.Text) +
                TryParse(player.txtThrees.Text) +
                TryParse(player.txtFours.Text) +
                TryParse(player.txtFives.Text) +
                TryParse(player.txtSixes.Text);
        }

        /// <summary>
        /// Sums all values on the yahtzee paper.
        /// </summary>
        /// <returns>The sum of all.</returns>
        public static int SumAll(PlayerControl player)
        {
            return
                SumAllUpper(player) +
                TryParse(player.txtBonus.Text) +
                TryParse(player.txtToaK.Text) +
                TryParse(player.txtFoaK.Text) +
                TryParse(player.txtFH.Text) +
                TryParse(player.txtSmall.Text) +
                TryParse(player.txtLarge.Text) +
                TryParse(player.txtYahtzee.Text) +
                TryParse(player.txtChance.Text);
        }

        /// <summary>
        /// Checks if all of the upper section is done.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True if player is done with upper section.</returns>
        public static bool IsDoneUpper(PlayerControl player)
        {
            if (!string.IsNullOrEmpty(player.txtAces.Text) &&
                !string.IsNullOrEmpty(player.txtTwos.Text) &&
                !string.IsNullOrEmpty(player.txtThrees.Text) &&
                !string.IsNullOrEmpty(player.txtFours.Text) &&
                !string.IsNullOrEmpty(player.txtFives.Text) &&
                !string.IsNullOrEmpty(player.txtSixes.Text)
                )
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds an amount of points to the total score.
        /// </summary>
        /// <param name="player">The player to calculate</param>
        public static void AddToTotal(PlayerControl player)
        {
            player.txtTotal.Text = SumAll(player).ToString();
        }

        /// <summary>
        /// Adds an amount of points to the upper total score.
        /// </summary>
        /// <param name="player">The player.</param>
        public static void AddToTotalUpper(PlayerControl player)
        {
            player.txtTotalUpper.Text = SumAllUpper(player).ToString();
        }

        /// <summary>
        /// Handles the bonus of the upper section of the yahtzee paper.
        /// </summary>
        /// <param name="player">The player to calculate</param>
        public static void ApplyBonus(PlayerControl player)
        {
            if (SumAllUpper(player) > 62)
            {
                player.txtBonus.Text = "50";
                return;
            }

            player.txtBonus.Text = "";
        }

        /// <summary>
        /// Determines whether the player is done or not
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool IsPlayerFinished(PlayerControl player)
        {
            return (player.IsDoneUpper &&
                !string.IsNullOrEmpty(player.txtToaK.Text) &&
                !string.IsNullOrEmpty(player.txtFoaK.Text) &&
                !string.IsNullOrEmpty(player.txtSmall.Text) &&
                !string.IsNullOrEmpty(player.txtLarge.Text) &&
                !string.IsNullOrEmpty(player.txtYahtzee.Text) &&
                !string.IsNullOrEmpty(player.txtFH.Text) &&
                !string.IsNullOrEmpty(player.txtChance.Text));
        }

        /// <summary>
        /// Resets the player's points on the yahtzee paper.
        /// </summary>
        /// <param name="player">The player.</param>
        public static void ResetPlayer(PlayerControl player)
        {
            foreach(TextBox textbox in FindVisualChildren<TextBox>(player))
            {
                textbox.Text = "";
            }

            foreach(CheckBox checkbox in FindVisualChildren<CheckBox>(player))
            {
                checkbox.IsEnabled = true;
                checkbox.IsChecked = false;
            }
        }

        /// <summary>
        /// Determines if the game is over or not.
        /// </summary>
        public static bool IsGameOver(List<Player> players)
        {
            var index = 0;
            var highestScore = 0;
            var winner = string.Empty;
            foreach (var player in players)
            {
                if (player.ScoreTotal == 0)
                {
                    return false;
                }

                var score = player.ScoreTotal;
                if (score > 0)
                {
                    index++;

                    if (score > highestScore)
                    {
                        highestScore = score;
                        winner = player.Name;
                        _player = player;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Gets the winner
        /// </summary>
        /// <returns>The winning <see cref="Player"/></returns>
        public static Player GetWinner() { return _player; }

        /// <summary>
        /// Gets all certain controls of a usercontrol.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)

                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
