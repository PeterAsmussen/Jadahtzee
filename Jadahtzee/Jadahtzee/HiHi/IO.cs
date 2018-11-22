using System;
using System.Collections.Generic;
using System.IO;

namespace Jadahtzee.HiHi
{
    public class IO
    {
        private static string directory = "C:\\ProgramData\\Jadahtzee";
        private static string historyFile = "\\History.txt";
        private static string highscoreFile = "\\Highscores.txt";

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

            var highscores = directory + highscoreFile;
            if (!File.Exists(highscores))
            {
                using (var writer = new StreamWriter(highscores, true))
                {
                }
            }
        }

        /// <summary>
        /// Gets the entries based on the parameter
        /// </summary>
        /// <param name="fileName">The filename</param>
        /// <returns>The entries</returns>
        public List<KeyValuePair<int, string>> GetEntries(int getFrom)
        {
            var fileName = "";
            switch (getFrom)
            {
                case 1:
                    fileName = historyFile;
                    break;
                case 2:
                    fileName = highscoreFile;
                    break;
                default:
                    return null;
            }

            var list = new List<string>();
            var entries = new List<KeyValuePair<int, string>>();
            using (var stream = new StreamReader(directory + fileName))
            {
                while(stream.Read() > 0)
                {
                    list.Add(stream.ReadLine());
                }

                foreach(var entry in list)
                {
                    var split = entry.Split(':');
                    entries.Add(new KeyValuePair<int, string>(Int32.Parse(split[0]), split[1]));
                }
            }
            
            return entries;
        }

        /// <summary>
        /// Writes the new entry
        /// </summary>
        /// <param name="entry">The entry</param>
        /// <param name="fileName">The file name</param>
        public void Write(List<KeyValuePair<int, string>> entry, int writeTo)
        {
            var fileName = "";
            switch (writeTo)
            {
                case 1:
                    fileName = historyFile;
                    break;
                case 2:
                    fileName = highscoreFile;
                    break;
                default:
                    return;
            }

            entry.Sort((x, y) => x.Key.CompareTo(y.Key));
            using (var writer = new StreamWriter(directory + fileName))
            {
                foreach (var line in entry)
                {
                    writer.WriteLine($" {line.Key}:{line.Value}");
                }
            }
        }
    }
}
