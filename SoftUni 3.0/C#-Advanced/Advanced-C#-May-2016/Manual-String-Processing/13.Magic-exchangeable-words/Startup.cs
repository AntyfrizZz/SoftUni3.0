using System;
using System.Collections.Generic;

class Startup
{
    static Dictionary<char, char> exchangable = new Dictionary<char, char>();
    static bool result = true;

    static void Main()
    {
        var inputArgs = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var firstWord = inputArgs[0].ToCharArray();
        var secondWord = inputArgs[1].ToCharArray();
        
        

        if (firstWord.Length == secondWord.Length)
        {
            result = FillResultDictionary(firstWord, secondWord);
            if (result)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
        else
        {
            if (firstWord.Length < secondWord.Length)
            {
                result = FillResultDictionary(secondWord, firstWord);

                if (!result)
                {
                    Console.WriteLine("false");
                    return;
                }

                result = SecondaryCheck(firstWord, secondWord);

                Console.WriteLine(result.ToString().ToLower());
            }
            else
            {
                result = FillResultDictionary(firstWord, secondWord);

                if (!result)
                {
                    Console.WriteLine("false");
                    return;
                }

                result = SecondaryCheck(secondWord, firstWord);

                Console.WriteLine(result.ToString().ToLower());
            }
        }
    }

    private static bool SecondaryCheck(char[] firstWord, char[] secondWord)
    {
        for (int i = firstWord.Length; i < secondWord.Length; i++)
        {
            if (!exchangable.ContainsKey(secondWord[i]))
            {
                return false;
            }
        }

        return true;
    }

    private static bool FillResultDictionary(char[] firstWord, char[] secondWord)
    {
        for (int i = 0; i < secondWord.Length; i++)
        {
            if (exchangable.ContainsKey(firstWord[i]))
            {
                if (exchangable[firstWord[i]] != secondWord[i])
                {
                    return false;
                }
            }
            else
            {
                exchangable.Add(firstWord[i], secondWord[i]);
            }
        }

        return true;
    }
}