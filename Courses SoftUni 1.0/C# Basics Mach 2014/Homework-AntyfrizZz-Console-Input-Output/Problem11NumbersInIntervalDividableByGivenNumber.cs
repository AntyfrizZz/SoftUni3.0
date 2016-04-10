using System;
using System.Collections.Generic;

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/4.%20Console-Input-Output-Homework.docx

class DividableNumsInInterval
{
    static void Main()
    {
        Console.Title = "Problem 11.* Numbers in Interval Dividable by Given Number";

        Console.Write("Start: ");
        uint start = uint.Parse(Console.ReadLine());

        Console.Write("End: ");
        uint end = uint.Parse(Console.ReadLine());

        List<uint> comments = new List<uint>();
        int counter = 0;

        for (uint i = start; i <= end; i++)
        {
            if (i % 5 == 0)
            {
                comments.Add(i);
                counter++;
            }
        }

        Console.WriteLine("p = {0}", counter);

        foreach (int number in comments)
        {
            Console.Write(number + ", ");
        }
    }
}
