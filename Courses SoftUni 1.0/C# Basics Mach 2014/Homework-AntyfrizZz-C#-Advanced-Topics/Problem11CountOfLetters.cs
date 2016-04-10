using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a program that reads a list of letters and prints for each letter how many times it appears in the list. 
//The letters should be listed in alphabetical order. Use the input and output format from the examples below. 

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/7.%20CSharp-Advanced-Topics-Homework.docx

class CountOfLetters
{
    static void Main()
    {
        A:
        string lettersString = Console.ReadLine();
        string[] allLetters = lettersString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<char> letters = new List<char>();

        for (int i = 0; i < allLetters.Length; i++)
        {
            letters.Add(Convert.ToChar(allLetters[i]));
        }

        letters.Sort();

        int counter = 1;
        for (int i = 1; i < letters.Count; i++)
        {
            if (letters[i] == letters[i - 1])
            {
                counter++;
            }
            else
            {
                Console.WriteLine("{0} --> {1}", letters[i - 1], counter);
                counter = 1;
            }

            if (i == letters.Count - 1)
            {
                Console.WriteLine("{0} --> {1}", letters[i], counter);
            }
        }

        goto A;
    }
}