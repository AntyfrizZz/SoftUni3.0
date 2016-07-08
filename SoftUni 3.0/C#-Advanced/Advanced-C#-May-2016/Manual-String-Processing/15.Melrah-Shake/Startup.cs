using System;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine();
        var pattern = Console.ReadLine();

        var result = new StringBuilder();

        while (true)
        {
            var firstMathcStartIndex = input.IndexOf(pattern);
            var firstMatchEndIndex = firstMathcStartIndex + pattern.Length - 1;

            var secondMatchStartIndex = input.LastIndexOf(pattern);
            var secondMatchEndIndex = secondMatchStartIndex + pattern.Length - 1;

            if (firstMatchEndIndex >= secondMatchStartIndex ||
                firstMathcStartIndex < 0 ||
                secondMatchStartIndex < 0 ||
                pattern == "")
            {
                result.AppendLine("No shake.");
                result.AppendLine(input);
                break;
            }

            result.AppendLine("Shaked it.");

            input = input.Substring(0, firstMathcStartIndex) + input.Substring(firstMatchEndIndex + 1, secondMatchStartIndex - firstMatchEndIndex - 1) + input.Substring(secondMatchEndIndex + 1, input.Length - secondMatchEndIndex - 1);

            pattern = pattern.Remove(pattern.Length / 2, 1);
        }

        Console.Write(result);
    }
}