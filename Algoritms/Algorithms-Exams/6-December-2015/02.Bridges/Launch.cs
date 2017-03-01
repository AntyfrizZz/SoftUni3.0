using System;
using System.Collections.Generic;
using System.Linq;

class Launch
{
    static void Main()
    {
        var columns = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int lastBridgeIndex = 0;
        var bridges = new List<int>();
        var lastSeen = new Dictionary<int, int>();

        for (int i = 0; i < columns.Length; i++)
        {
            if (!lastSeen.ContainsKey(columns[i]))
            {
                lastSeen[columns[i]] = i;
            }
        }

        for (int i = 1; i < columns.Length; i++)
        {
            var lastIndex = lastSeen[columns[i]];

            if (lastIndex >= lastBridgeIndex && lastIndex != i)
            {
                bridges.Add(i);
                bridges.Add(lastIndex);
                lastBridgeIndex = i;
            }

            lastSeen[columns[i]] = i;
        }

        var result = Enumerable.Repeat("X", columns.Length).ToArray();

        for (int i = 0; i < bridges.Count; i++)
        {
            var currentColumnIndex = bridges[i];
            result[currentColumnIndex] = columns[currentColumnIndex].ToString();
        }

        var bridgeCount = bridges.Count / 2;

        switch (bridgeCount)
        {
            case 1:
                Console.WriteLine("1 bridge found");
                break;
            case 0:
                Console.WriteLine("No bridges found");
                break;
            default:
                Console.WriteLine("{0} bridges found", bridgeCount);
                break;
        }

        Console.WriteLine(string.Join(" ", result));
    }
}