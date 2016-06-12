using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static SortedDictionary<DateTime, string> messages = new SortedDictionary<DateTime, string>();

    static void Main()
    {
        var format = "dd-MM-yyyy HH:mm:ss";

        var currentDate = DateTime.ParseExact(
            Console.ReadLine().Trim(),
            format, 
            CultureInfo.InvariantCulture);

        var input = Console.ReadLine();

        while (input != "END")
        {
            var messageArgs = Regex.Split(input, " / ");

            var time = DateTime.ParseExact(
                messageArgs[1], 
                format, 
                CultureInfo.InvariantCulture);
            var message = messageArgs[0];

            if (!messages.ContainsKey(time))
            {
                messages.Add(time, message);
            }

            input = Console.ReadLine();
        }

        var result = new StringBuilder();

        foreach (var kvp in messages)
        {
            result.AppendLine($"<div>{SecurityElement.Escape(kvp.Value)}</div>");
        }

        result.Append("<p>Last active: <time>");

        var lastActive = messages.Keys.Last();
        var timeDifference = currentDate - lastActive;

        if (lastActive.Date.AddDays(1) == currentDate.Date)
            result.Append("yesterday");
        else if (timeDifference < new TimeSpan(0, 1, 0))
            result.Append("a few moments ago");
        else if (timeDifference < new TimeSpan(1, 0, 0))
            result.Append($"{timeDifference.Minutes} minute(s) ago");
        else if (timeDifference < new TimeSpan(1, 0, 0, 0))
            result.Append($"{timeDifference.Hours} hour(s) ago");
        else
            result.Append(lastActive.ToString("dd-MM-yyyy"));
        result.AppendLine("</time></p>");
        Console.Write(result);
    }
}