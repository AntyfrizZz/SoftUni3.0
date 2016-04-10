using System;
//Using loops write a program that converts an integer number to its hexadecimal representation. The input is entered as long.
//The output should be a variable of type string. Do not use the built-in .NET functionality. 

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class DecimalToHexadecimalNumber
{
    static void Main()
    {
        Console.Title = "Problem 16. Decimal to Hexadecimal Number";

        long decNumber = long.Parse(Console.ReadLine());
        string hexNumber = "";
        if (decNumber == 0)
        {
            hexNumber = "0";
        }
        else
        {
            while (decNumber > 0)
            {
                long remain = decNumber % 16;
                decNumber /= 16;
                switch (remain)
                {
                    case 10: hexNumber = "A" + hexNumber; break;
                    case 11: hexNumber = "B" + hexNumber; break;
                    case 12: hexNumber = "C" + hexNumber; break;
                    case 13: hexNumber = "D" + hexNumber; break;
                    case 14: hexNumber = "E" + hexNumber; break;
                    case 15: hexNumber = "F" + hexNumber; break;
                    default: hexNumber = remain + hexNumber; break;
                }
            }
        }
        Console.WriteLine(hexNumber);
    }
}