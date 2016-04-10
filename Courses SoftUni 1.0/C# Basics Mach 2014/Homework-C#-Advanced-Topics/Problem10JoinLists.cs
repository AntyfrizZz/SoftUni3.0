using System;
using System.Collections.Generic;
using System.Linq;
//Write a program that takes as input two lists of integers and joins them. The result should hold all numbers from the 
//first list, and all numbers from the second list, without repeating numbers, and arranged in increasing order. 
//The input and output lists are given as integers, separated by a space, each list at a separate line.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/7.%20CSharp-Advanced-Topics-Homework.docx

class JoinLists
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
                while (firstLine.Contains(secondLine[i]))
                {
                    firstLine.Remove(secondLine[i]);
                }
                firstLine.Add(secondLine[i]);
            }
        }

        firstLine.Sort();

        foreach (var item in firstLine)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        goto A;
    }
}