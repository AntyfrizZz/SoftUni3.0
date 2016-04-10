using System;
//Declare two string variables and assign them with “Hello” and “World”. Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval between).
//Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/2.%20Primitive-Data-Types-and-Variables-Homework.docx

class StringsAndObjects
{
    static void Main()
    {
        Console.Title = "Problem 6. Strings and Objects";

        string hello = "Hello";
        string world = "World";
        object Concatenation = hello + " " + world;
        string helloWorldString = Concatenation.ToString();
        Console.WriteLine(helloWorldString);
    }
}
