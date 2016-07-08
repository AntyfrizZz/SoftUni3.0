using System;
using System.Runtime.InteropServices;

class Startup
{
    static void Main()
    {
        var num = int.Parse(Console.ReadLine());

        var names = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Func<string, int, bool> isGreater = 
            (s, i) =>
        {
            foreach (var character in s)
            {
                i += (int)character;
            }

            return i >= num;
        };

        Func<string[], Func<string, int, bool>, string> result =
        (strArr, func) =>
        {
            foreach (var name in strArr)
            {
                if (func(name, 0))
                {
                    return name;
                }
            }

            return string.Empty;
        };

        Console.WriteLine(result(names, isGreater));
    }
}