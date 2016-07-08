using System;
using System.Text;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine();

        Console.WriteLine(GetUnicodeString(input));
    }

    static string GetUnicodeString(string s)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in s)
        {
            sb.Append("\\u");
            sb.Append(String.Format("{0:x4}", (int)c));
        }

        return sb.ToString();
    }
}