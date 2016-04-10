using System;
//Declare an integer variable and assign it with the value 254 in hexadecimal format (0x##). Use Windows Calculator to find its hexadecimal representation.
//Print the variable and ensure that the result is “254”.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/2.%20Primitive-Data-Types-and-Variables-Homework.docx

class VariableInHexadecimalFormat
{
    static void Main()
    {
        Console.Title = "Problem 3. Variable in Hexadecimal Format";

        int HexadecimalNumber = 0XFE;
        Console.WriteLine("0xFE is the Hexadecimal format of " + HexadecimalNumber);
    }
}
