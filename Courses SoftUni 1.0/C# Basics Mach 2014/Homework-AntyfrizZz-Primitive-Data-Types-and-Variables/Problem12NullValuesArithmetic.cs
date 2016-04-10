using System;
//Create a program that assigns null values to an integer and to a double variable. Try to print these variables at the console. 
//Try to add some number or the null literal to these variables and print the result.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/2.%20Primitive-Data-Types-and-Variables-Homework.docx

class NullValuesArithmetic
{
    static void Main()
    {
        Console.Title = "Problem 12. Null Values Arithmetic";

        Console.WriteLine(@"Variant with ""GetValueOrDefault""");

        int? someInteger = null;
        Console.WriteLine("This is the integer with null value -> " + someInteger);

        int addToSomeInteger = someInteger.GetValueOrDefault() + 5;
        Console.WriteLine("This is the integer with added 5 -> " + addToSomeInteger);

        double? someDouble = null;
        Console.WriteLine("This is the integer with null value -> " + someDouble);

        double addToSomeDouble = someDouble.GetValueOrDefault() + 5;
        Console.WriteLine("This is the integer with added 5 -> " + addToSomeDouble);

        Console.WriteLine();
        Console.WriteLine(@"Variant withowt ""GetValueOrDefault""");

        Console.WriteLine("This is the integer with null value -> " + someInteger);
        int? addToSomeIntegerWithowt = someInteger + null;
        Console.WriteLine("This is the integer with added ull -> " + addToSomeIntegerWithowt);

        Console.WriteLine("This is the integer with null value -> " + someDouble);
        double? addToSomeDoubleWithowt = someDouble.GetValueOrDefault() + null;
        Console.WriteLine("This is the integer with added null -> " + addToSomeDoubleWithowt);
    }
}