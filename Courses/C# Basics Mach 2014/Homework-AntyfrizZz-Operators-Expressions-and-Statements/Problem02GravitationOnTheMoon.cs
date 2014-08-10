using System;
//The gravitational field of the Moon is approximately 17% of that on the Earth.
//Write a program that calculates the weight of a man on the moon by a given weight on the Earth.
 
//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/3.%20Operators-Expressions-and-Statements-Homework.docx
 
class GravitationOnTheMoon
{
    static void Main()
    {
        Console.Title = "Problem 2.	Gravitation on the Moon";

        Console.Write("Please enter your weight: ");
        double earthWeight = double.Parse(Console.ReadLine());

        double moonWeight = earthWeight * 0.17;
        Console.WriteLine("Your weight on the moon (17% from your weght on earth) will be " + moonWeight);
    }
}
