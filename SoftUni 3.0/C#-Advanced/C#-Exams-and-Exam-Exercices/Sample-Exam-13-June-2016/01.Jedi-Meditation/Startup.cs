using System;
using System.Collections.Generic;
using System.Text;

class Startup
{
    static List<string> masters = new List<string>();
    static List<string> knights = new List<string>();
    static List<string> padawans = new List<string>();
    static List<string> toshkoSlav = new List<string>();

    static StringBuilder result = new StringBuilder();

    static bool yodaIsHere = false;

    static void Main()
    {
        FillJedies();

        PrintResult();
    }

    private static void PrintResult()
    {
        if (yodaIsHere)
        {
            result.Append($"{string.Join("", masters)}");
            result.Append($"{string.Join("", knights)}");
            result.Append($"{string.Join("", toshkoSlav)}");
            result.Append($"{string.Join("", padawans)}");
        }
        else
        {
            result.Append($"{string.Join("", toshkoSlav)}");
            result.Append($"{string.Join("", masters)}");
            result.Append($"{string.Join("", knights)}");
            result.Append($"{string.Join("", padawans)}");
        }

        Console.WriteLine(result.ToString().Trim());
    }

    private static void FillJedies()
    {
        var inputLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputLines; i++)
        {
            var jedies = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var jedi in jedies)
            {
                switch (jedi[0])
                {
                    case 'm':
                        masters.Add(jedi + " ");
                        break;
                    case 'k':
                        knights.Add(jedi + " ");
                        break;
                    case 'p':
                        padawans.Add(jedi + " ");
                        break;
                    case 'y':
                        yodaIsHere = true;
                        break;
                    default:
                        toshkoSlav.Add(jedi + " ");
                        break;
                }
            }
        }
    }
}