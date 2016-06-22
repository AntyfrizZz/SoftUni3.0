using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static StringBuilder text = new StringBuilder();
    static List<string> jedies = new List<string>();
    static List<string> messages = new List<string>();

    static void Main()
    {
        var numberOfLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfLines; i++)
        {
            text.Append(Console.ReadLine());
        }
        var namePat = Console.ReadLine();
        var messagePat = Console.ReadLine();

        var namePattern = string.Format(Regex.Escape(namePat) + "([a-zA-Z]{{" + namePat.Length + "}})(?![a-zA-Z])");
        var messagePattern = string.Format(Regex.Escape(messagePat) + "([a-zA-Z0-9]{{" + messagePat.Length + "}})(?![a-zA-Z0-9])");

        Regex rgxName = new Regex(namePattern);
        Regex rgxMessage = new Regex(messagePattern);

        MatchCollection matchedNames = rgxName.Matches(text.ToString());
        MatchCollection matchedMessages = rgxMessage.Matches(text.ToString());

        foreach (Match matchedName in matchedNames)
        {
            jedies.Add(matchedName.Groups[1].ToString());
        }

        foreach (Match matchedMessage in matchedMessages)
        {
            messages.Add(matchedMessage.Groups[1].ToString());
        }

        var indexes = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var currentIndex = 0;

        var result = new StringBuilder();

        foreach (var jedy in jedies)
        {
            if (currentIndex >= indexes.Length)
            {
                break;
            }

            while (indexes[currentIndex] - 1 >= messages.Count)
            {
                currentIndex++;

                if (currentIndex >= indexes.Length)
                {
                    break;
                }
            }

            if (currentIndex >= indexes.Length)
            {
                break;
            }

            result.AppendLine($"{jedy} - {messages[indexes[currentIndex] - 1]}");
            currentIndex++;
        }

        Console.Write(result);
    }
}