using System;
//Declare a character variable and assign it with the symbol that has Unicode code 42 (decimal) using the '\u00XX' syntax, and then print it.
//Hint: first, use the Windows Calculator to find the hexadecimal representation of 42. The output should be “*”.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/2.%20Primitive-Data-Types-and-Variables-Homework.docx

class UnicodeCharacter
{
    static void Main()
    {
        Console.Title = "Problem 4. Unicode Value";

        char UnicodeSymbol = '\u002A';
        Console.WriteLine("The symbol with Unicode code 42 (decimal) is " + UnicodeSymbol);
    }
}
