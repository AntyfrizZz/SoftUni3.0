using System;
//Write an expression that calculates rectangle’s perimeter and area by given width and height.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/3.%20Operators-Expressions-and-Statements-Homework.docx

class RectanglesPerimeterAndArea
{
    static void Main()
    {
        Console.Title = "Problem 4.	Rectangles";

        Console.Write("Enter rectangle's width: ");
        double rectangleWidth = double.Parse(Console.ReadLine());

        while (rectangleWidth <= 0)
        {
            Console.Write("Please enter positive number: ");
            rectangleWidth = double.Parse(Console.ReadLine());
        }


        Console.Write("Enter rectangle's height: ");
        double rectangleHeight = double.Parse(Console.ReadLine());

        while (rectangleHeight <= 0)
        {
            Console.Write("Please enter positive number: ");
            rectangleHeight = double.Parse(Console.ReadLine());
        }


        double rectanglePerimeter = (rectangleHeight + rectangleWidth) * 2;
        double rectangleArea = rectangleHeight * rectangleWidth;

        Console.WriteLine("Rectangle's perimeter is " + rectanglePerimeter);
        Console.WriteLine("Rectangle's area is " + rectangleArea);
    }
}
