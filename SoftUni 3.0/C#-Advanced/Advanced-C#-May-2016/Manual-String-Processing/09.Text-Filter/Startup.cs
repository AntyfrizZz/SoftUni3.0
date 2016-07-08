using System;
using System.Text;

class Startup
{
    static void Main()
    {

        var pattern = Console.ReadLine();
        var inputText = Console.ReadLine();

        var listPattern = pattern
            .Split(new string[] { ", " }, StringSplitOptions.None);

        Console.WriteLine(TextCounter(inputText, listPattern));

    }

    static StringBuilder TextCounter(string inputText, string[] pattern)
    {
        var aStringBuilder = new StringBuilder(inputText);

        for (int k = 0; k < pattern.Length; k++)
        {
            var temp = pattern[k];

            for (int i = 0; i < inputText.Length - temp.Length + 1; i++)
            {
                if (inputText[i] == temp[0])
                {
                    var innerCounter = 0;
                    for (int j = 0; j < temp.Length; j++)
                    {
                        if (inputText[i + j] == temp[j])
                        {
                            innerCounter++;
                        }
                    }
                    if (innerCounter == temp.Length)
                    {
                        for (int j = 0; j < temp.Length; j++)
                        {
                            aStringBuilder[i + j] = '*';

                        }
                    }
                }
            }
        }

        return aStringBuilder;
    }
}