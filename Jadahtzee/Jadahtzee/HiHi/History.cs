using System.Collections.Generic;

namespace Jadahtzee.HiHi
{
    public class History
    {
        public List<KeyValuePair<int, string>> currenthistory;
        private IO io;

        public History(IO io)
        {
            this.io = io;
            this.currenthistory = this.GetHistory();
        }

        /// <summary>
        /// Writes new history and highscores.
        /// </summary>
        /// <param name="input">The history and or new highscores.</param>
        internal void WriteToFile(KeyValuePair<int, string> newWinner)
        {
            this.NewHistory(newWinner);
            io.Write(this.currenthistory, 1);
        }

        /// <summary>
        /// Gets the history file contents.
        /// </summary>
        /// <returns>The history.</returns>
        private List<KeyValuePair<int, string>> GetHistory()
        {
            this.currenthistory = new List<KeyValuePair<int, string>>();
            List<KeyValuePair<int, string>> currentContents;
            try
            {
                currentContents = this.io.GetEntries(1);
            }
            catch (System.IO.FileNotFoundException e)
            {
                return null;
            }

            foreach (var line in currentContents)
            {
                this.currenthistory.Add(new KeyValuePair<int, string>(line.Key, line.Value));
            }

            return this.currenthistory;
        }

        /// <summary>
        /// Handle the new winner.
        /// </summary>
        /// <param name="newWinner">The winner</param>
        private void NewHistory(KeyValuePair<int, string> newWinner)
        {
            if (this.currenthistory == null)
            {
                this.currenthistory = new List<KeyValuePair<int, string>>();
                this.currenthistory.Add(newWinner);
                return;
            }

            if (this.currenthistory.Count > 9)
            {
                this.currenthistory.Reverse();
                this.currenthistory.Add(newWinner);
                this.currenthistory.Reverse();
                this.currenthistory.RemoveAt(10);
            }
            else
            {
                this.currenthistory.Add(newWinner);
            }
        }
    }
}
