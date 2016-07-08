using System;
using System.Linq;

class GenerateSubsetsOfStringArray
{
    const int k = 2;
    const int n = 3;
    static string[] objects = new string[n]
    {
        "test", "rock", "fun"
    };
    static int[] arr = new int[k];

    static void Main()
    {
        GenerateCombinationsNoRepetitions(0, 0);
    }

    static void GenerateCombinationsNoRepetitions(int index, int start)
    {
        if (index >= k)
        {
            PrintCombinations();
        }
        else
        {
            for (int i = start; i < n; i++)
            {
                arr[index] = i;
                GenerateCombinationsNoRepetitions(index + 1, i + 1);
            }
        }
    }

    static void PrintCombinations()
    {
        Console.WriteLine("(" + string.Join(" ", arr.Select(i => objects[i])) + ")");
    }
}