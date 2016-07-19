using System;
using System.Collections.Generic;
using System.Text;

class Startup
{
    static void Main()
    {
        var elements = Console.ReadLine()
            .Split(new[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

        var resultsContainer = new SortedSet<string>();

        foreach (var word in elements)
        {
            if (StringReverse(word))
            {
                resultsContainer.Add(word);
            }
        }

        var result = new StringBuilder();
        result.Append("[");

        foreach (var element in resultsContainer)
        {
            result.Append(element);
            result.Append(", ");
        }

        if (result.Length > 1)
        {
            result.Remove(result.Length - 2, 2);            
        }

        result.Append("]");

        Console.WriteLine(result);

    }

    static bool StringReverse(string word)
    {
        bool isPali = false;

        char[] arr = word.ToCharArray();
        Array.Reverse(arr);

        string reverse = new string(arr);

        if (reverse == word)
        {
            isPali = true;
        }

        return isPali;
    }
}