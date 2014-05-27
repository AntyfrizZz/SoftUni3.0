using System;
using System.Text;
////Find online more information about ASCII (American Standard Code for Information Interchange) 
//and write a program to prints the entire ASCII table of characters at the console (characters from 0 to 255). 
//Note that some characters have a special purpose and will not be displayed as expected. 
//You may skip them or display them differently. You may need to use for-loops (learn in Internet how).

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/2.%20Primitive-Data-Types-and-Variables-Homework.docx

class PrintTheASCIITable
{
    static void Main()
    {
        Console.Title = "Problem 14.* Print the ASCII Table";

        for (byte i = 0; i <= 127; i++)
        {
            char c = (char)i;
            Console.WriteLine("Code: " + i.ToString() + " Character: " + c);
        }
    }
}
