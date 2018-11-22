using System;
using System.Collections.Generic;

namespace Jadahtzee.HiHi
{
    public class Highscores
    {
        private List<KeyValuePair<int, string>> currenthighScores;
        private IO io;

        public Highscores(IO io)
        {
            this.io = io;
            this.currenthighScores = this.GetHighscores();
        }

        /// <summary>
        /// Writes new history and highscores.
        /// </summary>
        /// <param name="input">The history and or new highscores.</param>
        internal void WriteToFile(KeyValuePair<int, string> newWinner)
        {
            this.NewHighscore(newWinner);
            this.io.Write(this.currenthighScores, 2);
        }


        /// <summary>
        /// Gets the highscores file contents.
        /// </summary>
        /// <returns>The highscores</returns>
        private List<KeyValuePair<int, string>> GetHighscores()
        {
            this.currenthighScores = new List<KeyValuePair<int, string>>();
            List<KeyValuePair<int, string>> currentContents;
            try
            {
                currentContents = this.io.GetEntries(2);
            }
            catch(System.IO.FileNotFoundException e)
            {
                // If this returns null, we know that the file does not exists on the current platform
                return null;
            }

            foreach(var line in currentContents)
            {
                currenthighScores.Add(new KeyValuePair<int, string>(line.Key, line.Value));
            }

            return currenthighScores;
        }

        /// <summary>
        /// Handle the potential new highscore
        /// </summary>
        /// <param name="highScore">The highscore</param>
        private void NewHighscore(KeyValuePair<int, string> highScore)
        {
            if (this.currenthighScores == null)
            {
                this.currenthighScores = new List<KeyValuePair<int, string>>();
                this.currenthighScores.Add(highScore);
                return;
            }

            if (this.currenthighScores.Count > 4)
            {
                var temp = new KeyValuePair<int, string>();
                var index = 0;
                foreach (var high in this.currenthighScores)
                {
                    if (highScore.Key > high.Key)
                    {
                        temp = highScore;
                        index = this.currenthighScores.IndexOf(high);
                    }
                }

                if (index > 0)
                {
                    this.currenthighScores.RemoveAt(index);
                    this.currenthighScores.Insert(index, highScore);
                }
            }
            else
            {
                this.currenthighScores.Add(highScore);
                this.currenthighScores.Sort((x, y) => x.Key.CompareTo(y.Key));
            }
        }
    }
}
