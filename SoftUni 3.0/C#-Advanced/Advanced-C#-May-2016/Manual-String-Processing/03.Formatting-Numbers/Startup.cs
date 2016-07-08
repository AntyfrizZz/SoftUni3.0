using System;
using System.Text;

class Startup
{
    static void Main()
    {
        var inputArgs = Console.ReadLine()
            .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        int a = int.Parse(inputArgs[0]);
        double b = double.Parse(inputArgs[1]);
        double c = double.Parse(inputArgs[2]);

        var result = new StringBuilder();
        
        string hexadecimalNumber = a.ToString("X");
        result.Append("|");
        result.Append((hexadecimalNumber.PadRight(10)).ToString());

        string binaryNum = Convert.ToString(a, 2);
        result.Append("|");
        result.Append(binaryNum.PadLeft(10, '0').Substring(0, 10));

        result.Append("|");
        result.Append(b.ToString("0.00").PadLeft(10));

        result.Append("|");
        result.Append(c.ToString("0.000").PadRight(10));

        result.Append("|");

        Console.WriteLine(result);
    }
}