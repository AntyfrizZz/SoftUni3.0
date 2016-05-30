using System;
using System.Text;

class Launch
{

    static StringBuilder result = new StringBuilder();
    static int opening = 1;
    static int closing = 0;

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        char[] results = new char[n * 2];

        results[0] = '(';
        results[results.Length - 1] = ')';

        GenerateParent(1, results);

        Console.Write(result);
    }

    static void GenerateParent(int index, char[] results)
    {
        if (index == results.Length - 1)
        {
            result.AppendLine(string.Join("", results));
            return;
        }

        if (opening < results.Length / 2)
        {
            results[index] = '(';
            opening++;
            GenerateParent(index + 1, results);
            opening--;
        }

        if (closing < opening)
        {
            results[index] = ')';
            closing++;
            GenerateParent(index + 1, results);
            closing--;
        }
    }
}