namespace OnlineRadioDatabase
{
    using System;
    using System.Text;
    using OnlineRadioDatabase.Exceptions;

    class Startup
    {
        private static int songsAdded = 0;
        private static int totalSecunds = 0;

        private static StringBuilder result = new StringBuilder();

        static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                var songInfo = Console.ReadLine()
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    var time = songInfo[2].Split(':');

                    var artistName = songInfo[0];
                    var songName = songInfo[1];
                    var minutes = int.Parse(time[0]);
                    var secunds = int.Parse(time[1]);

                    var song = new Song(artistName, songName, minutes, secunds);

                    songsAdded++;
                    totalSecunds += minutes * 60 + secunds;

                    result.AppendLine("Song added.");
                }
                catch (InvalidSongException ise)
                {
                    result.AppendLine(ise.Message);
                }
                catch (FormatException)
                {
                    result.AppendLine(InvalidSongLengthException.Message);
                }
            }

            var finalSecunds = totalSecunds % 60;
            var finalMinutes = totalSecunds / 60;
            var finalHours = finalMinutes / 60;
            finalMinutes %= 60;

            result.AppendLine($"Songs added: {songsAdded}");
            result.AppendLine($"Playlist length: {finalHours}h {finalMinutes}m {finalSecunds}s");

            Console.Write(result);
        }
    }
}
