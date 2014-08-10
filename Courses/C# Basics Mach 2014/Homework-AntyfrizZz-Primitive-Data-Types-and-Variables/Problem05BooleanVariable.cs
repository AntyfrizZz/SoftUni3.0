using System;
//Declare a Boolean variable called isFemale and assign an appropriate value corresponding to your gender. Print it on the console.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/2.%20Primitive-Data-Types-and-Variables-Homework.docx

class BooleanVariable
{
    static void Main()
    {
        Console.Title = "Problem 5. Boolean Variable";

        bool isFemale = false;
        Console.WriteLine("My gender is {0}.", isFemale ? "female" : "male");
    }
}
