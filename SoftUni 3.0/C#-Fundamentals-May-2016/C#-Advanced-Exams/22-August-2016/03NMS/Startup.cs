using System;
using System.Text;

public class Startup
{
    public static void Main()
    {
        var input = Console.ReadLine();
        var text = string.Empty;

        while (!input.Equals("---NMS SEND---"))
        {
            text += input;

            input = Console.ReadLine();
        }

        var delimiter = Console.ReadLine();

        var result = new StringBuilder();
        result.Append(" ");

        foreach (var character in text)
        {
            if (char.ToLower(character) < char.ToLower(result[result.Length - 1]))
            {
                result.Append(delimiter + character);
            }
            else
            {
                result.Append(character);
            }
        }

        Console.WriteLine(result.ToString().Trim());
    }
}