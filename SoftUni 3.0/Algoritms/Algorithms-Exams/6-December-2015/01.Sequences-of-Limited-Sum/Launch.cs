using System;
using System.Collections.Generic;
using System.Text;

class Launch
{
    static StringBuilder output = new StringBuilder();
    static List<int> numbers = new List<int>();
    static void Main()
    {
        var s = int.Parse(Console.ReadLine());

        GenerateSequences(0, s);

        Console.WriteLine(output);
    }

    static void GenerateSequences(int sum, int max)
    {      
        for (int i = 1; i <= max; i++)
        {
            if (sum + i <= max)
            {
                numbers.Add(i);
                Print(numbers);

                GenerateSequences(sum + i, max);

                numbers.RemoveAt(numbers.Count - 1);
            }
            else
            {
                break;
            }         
        }
    }

    private static void Print(List<int> numbers)
    {
        output.AppendLine(string.Join(" ", numbers));
    }
}