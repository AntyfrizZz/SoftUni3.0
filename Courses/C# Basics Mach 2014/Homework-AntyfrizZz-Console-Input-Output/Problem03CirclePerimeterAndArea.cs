using System;
//Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/4.%20Console-Input-Output-Homework.docx

class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.Title = "Problem 3.	Circle Perimeter and Area";

        Console.Write("Enter the radius of the circle: ");
        double radius = double.Parse(Console.ReadLine());

        double perimeter = 2 * radius * Math.PI;
        double area = radius * radius * Math.PI;

        Console.WriteLine("The perimeter of the circle is {0:0.00}", perimeter);
        Console.WriteLine("The area of the circle is {0:0.00}", area);
    }
}
