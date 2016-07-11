using System;
using System.Linq;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine();
        StringReverse(input);
    }

    static void StringReverse(string input)
    {
        Console.WriteLine(string.Join("", input.Reverse()));
    }

    //static string StringReverse(string input)
    //{
    //    char[] arr = input.ToCharArray();
    //    Array.Reverse(arr);

    //    return new string(arr);
    //}
}
