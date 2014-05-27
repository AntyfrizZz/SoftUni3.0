using System;
//Declare five variables choosing for each of them the most appropriate of the types byte, sbyte, short, ushort, int, uint, long, ulong to 
//represent the following values: 52130, -115, 4825932, 97, -10000. Choose a large enough type for each number to ensure it will fit in it.
//Try to compile the code. Submit the source code of your Visual Studio project as part of your homework submission.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/2.%20Primitive-Data-Types-and-Variables-Homework.docx

class DeclareVariables
{
    static void Main()
    {
        Console.Title = "Problem 1. Declare Variables";

        ushort firstNumber = 52130;
        sbyte secondNumber = -115;
        uint thirdNumber = 4825932;
        byte fourthNumber = 97;
        short fifthNumber = -10000;

        Console.WriteLine((firstNumber) + (" is ushort "));
        Console.WriteLine((secondNumber) + (" is sbyte "));
        Console.WriteLine((thirdNumber) + (" is int "));
        Console.WriteLine((fourthNumber) + (" is byte "));
        Console.WriteLine((fifthNumber) + (" is short"));
    }
}
