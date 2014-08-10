using System;
//Declare two string variables and assign them with following value:
//The "use" of quotations causes difficulties.
//Do the above in two different ways: with and without using quoted strings. Print the variables to ensure that their value was correctly defined

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/2.%20Primitive-Data-Types-and-Variables-Homework.docx

class QuotesInStrings
{
    static void Main()
    {
        Console.Title = "Problem 7. Quotes in Strings";

        string WithQuotedStrings = "The \"use\" of quotations causes difficulties.";
        string WithoutQuotedStrings = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(WithQuotedStrings);
        Console.WriteLine(WithoutQuotedStrings);
    }
}
