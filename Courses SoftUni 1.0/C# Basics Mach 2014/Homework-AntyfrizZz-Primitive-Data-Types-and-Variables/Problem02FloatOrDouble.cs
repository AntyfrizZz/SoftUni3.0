using System;
//Which of the following values can be assigned to a variable of type float and which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?
//Write a program to assign the numbers in variables and print them to ensure no precision is lost.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/2.%20Primitive-Data-Types-and-Variables-Homework.docx

class FloatOrDouble
{
    static void Main()
    {
        Console.Title = "Problem 2. Float or Double?";

        double firstNumber = 34.567839023d;
        float secondNumber = 12.345f;
        double thirdNumber = 8923.1234857d;
        float fourthNumber = 3456.091f;

        Console.WriteLine("The number " + firstNumber + " is double.");
        Console.WriteLine("The number " + secondNumber + " is float, but it can be double too.");
        Console.WriteLine("The number " + thirdNumber + " is double.");
        Console.WriteLine("The number " + fourthNumber + " is float, but it can be double too.");
    }
}
