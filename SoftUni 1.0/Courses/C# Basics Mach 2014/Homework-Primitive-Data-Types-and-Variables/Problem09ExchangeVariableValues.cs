using System;
//Declare two integer variables a and b and assign them with 5 and 10 and after that exchange their values. Print the variable values before and after the exchange.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/2.%20Primitive-Data-Types-and-Variables-Homework.docx

class ExchangeVariableValues
{
    static void Main()
    {
        Console.Title = "Problem 9. Exchange Variable Values";

        int a = 5;
        int b = 10;
        int c = a;
        Console.WriteLine("Results before exchange.");
        Console.WriteLine("a = {0}", a);
        Console.WriteLine("b = {0}", b);
        a = b;
        b = c;
        Console.WriteLine("Results after exchange.");
        Console.WriteLine("a = {0}", a);
        Console.WriteLine("b = {0}", b);
    }
}
