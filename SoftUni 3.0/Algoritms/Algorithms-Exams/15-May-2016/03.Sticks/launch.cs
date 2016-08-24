using System;
using System.Collections.Generic;
using System.Linq;

class launch
{
    static void Main(string[] args)
    {
        int numberOfSticks = int.Parse(Console.ReadLine());
        int numberOfLines = int.Parse(Console.ReadLine());

        var graph = new Dictionary<int, List<int>>();
        for (int i = 0; i < numberOfSticks; i++)
        {
            graph.Add(i, new List<int>());
        }

        var predecessorsCount = new int[graph.Count];

        for (int i = 0; i < numberOfLines; i++)
        {
            var inputArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            graph[inputArgs[0]].Add(inputArgs[1]);
            predecessorsCount[inputArgs[1]]++;
        }

        var isRemoved = new bool[graph.Count];
        var removedNodes = new List<int>();
        var nodeRemoved = true;

        while (nodeRemoved)
        {
            nodeRemoved = false;

            for (int node = graph.Count - 1; node >= 0; node--)
            {
                if (predecessorsCount[node] == 0 && !isRemoved[node])
                {
                    foreach (var childNode in graph[node])
                    {
                        predecessorsCount[childNode]--;
                    }

                    isRemoved[node] = true;
                    removedNodes.Add(node);
                    nodeRemoved = true;
                    break;
                }
            }
        }

        if (removedNodes.Count == graph.Count)
        {
            Console.WriteLine(string.Join(" ", removedNodes));
        }
        else
        {
            Console.WriteLine("Cannot lift all sticks");
            Console.WriteLine(string.Join(" ", removedNodes));
        }
    }
}