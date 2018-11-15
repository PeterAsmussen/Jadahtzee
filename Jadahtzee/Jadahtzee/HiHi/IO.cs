using System;
using System.Collections.Generic;
using System.IO;

namespace Jadahtzee.HiHi
{
    public class IO
    {
        private static string directory = "C:\\ProgramData\\Jadahtzee";
        private static string historyFile = "\\History.txt";
        private static string highscoresFile = "\\Highscores.txt";

        public IO()
        {
        }

        /// <summary>
        /// Creates the history- and highscores file.
        /// </summary>
        public void CreateFiles()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var history = directory + historyFile;
            if (!File.Exists(history))
            {
                using(var writer = new StreamWriter(history, true))
                {
                }
            }

            var highscores = directory + highscoresFile;
            if (!File.Exists(highscores))
            {
                using (var writer = new StreamWriter(highscores, true))
                {
                }
            }
        }

        /// <summary>
        /// Gets the history
        /// </summary>
        /// <returns>The history</returns>
        public List<KeyValuePair<int, string>> GetHistory()
        {
            var historyList = new List<string>();
            var history = new List<KeyValuePair<int, string>>();
            using (var stream = new StreamReader(directory + historyFile))
            {
                while (stream.Read() > 0)
                {
                    historyList.Add(stream.ReadLine());
                }
            }
            foreach (var hist in historyList)
            {
                var s = hist.Split(':');
                history.Add(new KeyValuePair<int, string>(Int32.Parse(s[0]), s[1]));
            }

            return history;
        }

        /// <summary>
        /// Gets the highscores
        /// </summary>
        /// <returns>The highscores</returns>
        public List<KeyValuePair<int, string>> GetHighscores()
        {
            var scoresList = new List<string>();
            var scores = new List<KeyValuePair<int, string>>();
            using (var stream = new StreamReader(directory + highscoresFile))
            {
                while(stream.Read() > 0)
                {
                    scoresList.Add(stream.ReadLine());
                }
            }

            foreach(var score in scoresList)
            {
                var s = score.Split(':');
                scores.Add(new KeyValuePair<int, string>(Int32.Parse(s[0]), s[1]));
            }

            return scores;
        }

        /// <summary>
        /// Writes the history
        /// </summary>
        /// <param name="history">The history</param>
        public void WriteHistory(List<KeyValuePair<int, string>> history)
        {
            history.Sort((x, y) => x.Key.CompareTo(y.Key));
            using (var writer = new StreamWriter(directory + historyFile))
            {
                foreach (var line in history)
                {
                    writer.WriteLine($"{line.Key}:{line.Value}");
                }
            }
        }

        /// <summary>
        /// Writes the highscore
        /// </summary>
        /// <param name="highscore">The highscore</param>
        public void WriteHighscore(List<KeyValuePair<int, string>> highscore)
        {
            highscore.Sort((x, y) => x.Key.CompareTo(y.Key));
            using(var writer = new StreamWriter(directory + highscoresFile))
            {
                foreach (var line in highscore)
                {
                    writer.WriteLine($"{line.Key}:{line.Value}");
                }
            }
        }
    }
}
