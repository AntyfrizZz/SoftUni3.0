using System;

class Startup
{
    static void Main()
    {
        var test = Console.ReadLine().ToLower();
        var text = Console.ReadLine().ToLower();

        Console.WriteLine(TextCounter(test, text));
    }

    static int TextCounter(string inputText, string pattern)
    {
        var result = 0;

        for (int i = 0; i < inputText.Length - pattern.Length + 1; i++)
        {
            if (inputText[i] == pattern[0])
            {
                var counter = 0;

                for (int j = 0; j < pattern.Length; j++)
                {
                    if (inputText[i + j] == pattern[j])
                    {
                        counter++;
                    }
                }
                if (counter == pattern.Length)
                {
                    result++;
                }
            }
        }

        return result;
    }
}
