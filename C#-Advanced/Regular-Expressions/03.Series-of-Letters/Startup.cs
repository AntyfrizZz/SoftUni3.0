using System;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            string pattern = string.Format(@"{0}+", input[i]);
            string replace = string.Format(@"{0}", input[i]);
            Regex regRepl = new Regex(pattern);

            input = regRepl.Replace(input, replace);
        }

        Console.WriteLine(input);

        input = Console.ReadLine();
    }
}
