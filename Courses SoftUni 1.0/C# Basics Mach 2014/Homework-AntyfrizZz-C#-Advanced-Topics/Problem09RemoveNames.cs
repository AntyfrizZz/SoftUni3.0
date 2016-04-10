using System;
using System.Collections.Generic;
using System.Linq;
//Write a program that takes as input two lists of names and removes from the first list all names given in the second list. 
//The input and output lists are given as words, separated by a space, each list at a separate line.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/7.%20CSharp-Advanced-Topics-Homework.docx

class RemoveNames
{
    static void Main()
    {
        A:
        string firstInputLine = Console.ReadLine();
        string[] firstNames = firstInputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string secondInputLine = Console.ReadLine();
        string[] secondNames = secondInputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<string> firstLine = firstNames.ToList<string>();
        List<string> secondLine = secondNames.ToList<string>();

        for (int i = 0; i < secondLine.Count; i++)
        {
            for (int j = 0; j < firstLine.Count; j++)
            {
                if (firstLine.Contains(secondLine[i]))
                {
                    firstLine.Remove(secondLine[i]);
                }
            }
        }

        foreach (var item in firstLine)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        goto A;
    }
}