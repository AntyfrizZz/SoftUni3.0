using System;
//Write a program that prints an isosceles triangle of 9 copyright symbols ©, something like this:
//   ©
//  © ©
// ©   ©
//© © © ©
//Note that the © symbol may be displayed incorrectly at the console so you may need to change the console character encoding to UTF-8 and assign a Unicode-friendly font in the console.
//Note also, that under old versions of Windows the © symbol may still be displayed incorrectly, regardless of how much effort you put to fix it.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/2.%20Primitive-Data-Types-and-Variables-Homework.docx

class IsoscelesTriangle
{
    static void Main()
    {
        Console.Title = "Problem 8. Isosceles Triangle";

        char copyRight = '\u00A9';
        char emptySpace = (char)0;

        int rows = 3;
        int columns = 5;
        int cSymbol = 1;

        for (int i = 0; i < rows; i++)
        {
            for (int blank = 0; blank < columns - i; blank++)
            {
                Console.Write(emptySpace);
            }
            for (int symbol = 0; symbol < cSymbol; symbol++)
            {
                Console.Write(copyRight);
            }
            cSymbol += 2;
            Console.WriteLine();
        }
    }
}
