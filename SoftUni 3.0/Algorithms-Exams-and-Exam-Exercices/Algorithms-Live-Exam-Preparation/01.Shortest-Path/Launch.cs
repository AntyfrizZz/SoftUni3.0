using System;
using System.Collections.Generic;
using System.Text;

public class Launch
{
    public static SortedSet<string> results = new SortedSet<string>();

    public static char[] map;

    public static void Main()
    {
        string mapString = Console.ReadLine();
        map = mapString.ToCharArray();

        Solve(0);

        var output = new StringBuilder();
        output.AppendLine(results.Count.ToString());
        foreach (var result in results)
        {
            output.AppendLine(result);
        }

        Console.WriteLine(output.ToString().Trim());
    }

    public static void Solve(int index)
    {
        if (index == map.Length)
        {
            results.Add(new string(map));
            return;
        }
        else if (map[index] != '*')
        {
            Solve(index + 1);
        }
        else
        {
            map[index] = 'L';
            Solve(index + 1);
            map[index] = 'R';
            Solve(index + 1);
            map[index] = 'S';
            Solve(index + 1);
            map[index] = '*';
        }
    }
}