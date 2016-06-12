using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Startup
{
    static double sum = double.MinValue;    
    static void Main()
    {
        string result = string.Empty;
        Console.ReadLine();
        Console.ReadLine();

        var inputLine = Console.ReadLine();

        while (inputLine != "</table>")
        {
            var pattern = @"-?[0-9\.]+";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(inputLine);

            double tempResult = 0;
            var nums = new List<string>();
            foreach (Match number in matches)
            {
                var num = double.Parse(number.ToString());
                nums.Add(number.ToString());
                tempResult += num;
            }

            if (tempResult > sum && matches.Count > 0)
            {
                sum = tempResult;
                result = $"{sum} = {string.Join(" + ", nums)}";
            }

            inputLine = Console.ReadLine();
        }

        if (result != string.Empty)
        {
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("no data");
        }
    }
}