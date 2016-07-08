using System;
using System.Linq;
using System.Numerics;
using System.Text;

class Startup
{
    static void Main()
    {
        var inputArgs = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(BigInteger.Parse)
            .ToArray();

        if (inputArgs[0] == 10)
        {
            Console.WriteLine(inputArgs[1]);
            return;
        }

        var result = string.Empty;

        while (inputArgs[1] != 0)
        {
            result += (inputArgs[1] % inputArgs[0]).ToString();
            inputArgs[1] /= inputArgs[0];
        }       

        Console.WriteLine(Reverse(result.ToString()));
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
