using System;
using System.Collections.Generic;
using System.Security.Claims;

class Startup
{
    static void Main()
    {
        var names = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var commandArgs = Console.ReadLine()
            .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        Predicate<string> add = s => s.Equals("Add filter");
        Predicate<string> remove = s => s.Equals("Remove filter");

        Predicate<string> startsWith = n => n.Equals("Starts with");
        Predicate<string> endsWith = n => n.Equals("Ends with");
        Predicate<string> length = n => n.Equals("Length");
        Predicate<string> contains = n => n.Equals("Contains");

        var removeStarts = new HashSet<string>();
        var removeEnds = new HashSet<string>();
        var removeLength = new HashSet<string>();
        var removeContains = new HashSet<string>();

        var commands = new HashSet<string>();

        while (commandArgs[0] != "Print")
        {
            if (add(commandArgs[0]))
            {
                if (startsWith(commandArgs[1]))
                {
                    removeStarts.Add(commandArgs[2]);
                }
                else if (endsWith(commandArgs[1]))
                {
                    removeEnds.Add(commandArgs[2]);
                }
                else if (length(commandArgs[1]))
                {
                    removeLength.Add(commandArgs[2]);
                }
                else if (contains(commandArgs[1]))
                {
                    removeContains.Add(commandArgs[2]);
                }
            }
            else if (remove(commandArgs[0]))
            {
                if (startsWith(commandArgs[1]))
                {
                    removeStarts.Remove(commandArgs[2]);
                }
                else if (endsWith(commandArgs[1]))
                {
                    removeEnds.Remove(commandArgs[2]);
                }
                else if (length(commandArgs[1]))
                {
                    removeLength.Remove(commandArgs[2]);
                }
                else if (contains(commandArgs[1]))
                {
                    removeContains.Remove(commandArgs[2]);
                }
            }

            commandArgs = Console.ReadLine()
            .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        var result = new List<string>();
        Predicate<string> ifStartsRemove = s => removeStarts.Contains(s[0].ToString());
        Predicate<string> ifEndsRemove = s => removeEnds.Contains(s[s.Length - 1].ToString());
        Predicate<string> ifLendthRemove = s => removeLength.Contains(s.Length.ToString());

        for (int i = 0; i < names.Length; i++)
        {
            var ifContainsRemove = false;

            foreach (var caracter in removeContains)
            {
                if (names[i].IndexOf(caracter) != - 1)
                {
                    ifContainsRemove = true;
                    break;
                }
            }

            if (!ifStartsRemove(names[i]) &&
                !ifEndsRemove(names[i]) &&
                !ifLendthRemove(names[i]) &&
                !ifContainsRemove)
            {
                result.Add(names[i]);
            }
        }


        Console.WriteLine(string.Join(" ", result));
    }
}