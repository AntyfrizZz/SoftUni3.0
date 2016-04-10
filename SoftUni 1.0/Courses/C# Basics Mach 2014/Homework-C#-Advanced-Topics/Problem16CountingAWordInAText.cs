using System;
//Write a program that counts how many times a given word occurs in given text. The first line in the input holds the word. 
//The second line of the input holds the text. The output should be a single integer number – the number of word occurrences. 
//Matching should be case-insensitive. Note that not all matching substrings are words and should be counted. A word is a 
//sequence of letters separated by punctuation or start / end of text.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/7.%20CSharp-Advanced-Topics-Homework.docx

class CountingAWordInAText
{
    static void Main()
    {
        string givenWord = Console.ReadLine();
        string text = Console.ReadLine();
        foreach (char c in text)
        {
            if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')))
            {
                text = text.Replace(c, ' ');
            }
        }
        string[] list = text.Split(' ');
        int counter = 0;
        foreach (string word in list)
        {
            if (word.ToLower() == givenWord.ToLower())
            {
                counter++;
            }
        }
        Console.WriteLine("The given word {0} occurs {1} times in the given text.", givenWord, counter);
    }
}