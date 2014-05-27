using System;
//Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, … You might need to learn how to use loops (search in Internet).

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/1.%20Introduction-to-Programming-Homework.docx

class First1000MembersOfSequence
{
    static void Main()
    {
        for (int i = 2; i < 1002; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
            else
            {
                Console.WriteLine(-i);
            }
        }
    }
}
