using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Write a program to find the longest word in a text.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/7.%20CSharp-Advanced-Topics-Homework.docx

class LongestWordInAText
{
    static void Main()
    {
    A:
        Console.WriteLine("Please enter your sentence");
        string input = Console.ReadLine();
        string inputTrim = input.Trim('.');
        string[] sentence = input.Split(' ');
        string longestWord = sentence[0];

        foreach (string word in sentence)
        {
            if (word.Length > longestWord.Length)
            {
                longestWord = word;
            }

        }

        Console.WriteLine("The longest word is: {0}", longestWord);

        goto A;
    }
}