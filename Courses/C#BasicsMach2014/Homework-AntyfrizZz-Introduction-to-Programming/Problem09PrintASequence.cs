using System;
//Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/1.%20Introduction-to-Programming-Homework.docx

class FirstMembersOfSequence
{
    static void Main()
    {
        for (int i = 2; i <= 11; i++)
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
