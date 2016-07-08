using System;
using System.Collections.Generic;
using System.Linq;

class LongestZigzagSubsequence
{
    const int NO_PREVIOUS = -1;

    static void Main()
    {
        string input = Console.ReadLine();
        int[] array = input.Split(',').Select(s => int.Parse(s)).ToArray();

        Console.WriteLine(string.Join(" ", CalculateLongestZigZagSeq(array)));
    }

    private static int[] CalculateLongestZigZagSeq(int[] sequence)
    {
        int n = sequence.Length;

        int[] prev = new int[n];
        int bestLength = 1;
        int bestIndex = 0;

        int[,] helpArray = new int[n, 2];
        helpArray[0, 0] = 1;
        helpArray[0, 1] = 1;

        for (int currentIndex = 1; currentIndex < n; currentIndex++)
        {
            int value = 0;

            for (int prevIndex = 0; prevIndex < currentIndex; prevIndex++)
            {
                if (sequence[prevIndex] < sequence[currentIndex] &&
                        helpArray[prevIndex, 1] + 1 > helpArray[currentIndex, 0])
                {
                    helpArray[currentIndex, 0] = helpArray[prevIndex, 1] + 1;
                    value = prevIndex;
                }
                if (sequence[prevIndex] > sequence[currentIndex] &&
                  helpArray[prevIndex, 0] + 1 > helpArray[currentIndex, 1])
                {
                    helpArray[currentIndex, 1] = helpArray[prevIndex, 0] + 1;
                    value = prevIndex;
                }

                int posibleBest = Math.Max(bestLength, Math.Max(helpArray[currentIndex, 0], helpArray[currentIndex, 1]));

                if (posibleBest >= bestLength)
                {
                    prev[currentIndex] = value;
                    if (posibleBest > bestLength)
                    {
                        bestIndex = currentIndex;
                    }
                }
                bestLength = posibleBest;


            }
        }

        return RestorePath(prev, sequence, bestIndex);
    }

    private static int[] RestorePath(int[] prevPath, int[] sequence, int endIndex)
    {
        var result = new Stack<int>();
        while (endIndex > 0)
        {
            result.Push(sequence[endIndex]);
            endIndex = prevPath[endIndex];
        }
        result.Push(sequence[0]);
        return result.ToArray();
    }
}