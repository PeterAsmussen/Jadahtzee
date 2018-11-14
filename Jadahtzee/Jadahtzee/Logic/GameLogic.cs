﻿using System;

namespace Jadahtzee.Logic
{
    public class GameLogic
    {
        public GameLogic() { }
        
        /// <summary>
        /// Tries to parse an input string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The parsed value.</returns>
        private static int TryParse(string input)
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
        /// Resets the player's points on the yahtzee paper.
        /// </summary>
        /// <param name="player">The player.</param>
        public static void ResetPlayer(PlayerControl player)
        {
            player.txtAces.Text = "";
            player.txtTwos.Text = "";
            player.txtThrees.Text = "";
            player.txtFours.Text = "";
            player.txtFives.Text = "";
            player.txtSixes.Text = "";
            player.txtTotalUpper.Text = "";
            player.txtBonus.Text = "";
            player.txtToaK.Text = "";
            player.txtFoaK.Text = "";
            player.txtSmall.Text = "";
            player.txtLarge.Text = "";
            player.txtYahtzee.Text = "";
            player.txtChance.Text = "";
            player.txtTotal.Text = "";
        }
    }
}
