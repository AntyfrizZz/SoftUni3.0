using System;
//Write an expression that checks for given point (x, y) if it is within the circle 
//K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/3.%20Operators-Expressions-and-Statements-Homework.docx

class PointInsideACircleAndOutsideofARectangle
{
    static void Main()
    {
        Console.Title = "Problem 10. Point Inside a Circle & Outside of a Rectangle";

        Console.Write(@"Enter ""x"" coordinate of the point: ");
        double xCoord = double.Parse(Console.ReadLine());
        Console.Write(@"Enter ""y"" coordinate of the point: ");
        double yCoord = double.Parse(Console.ReadLine());

        double xCoordForCircle = xCoord - 1;
        double yCoordForCircle = yCoord - 1;
        double coordLength = Math.Sqrt(xCoordForCircle * xCoordForCircle + yCoordForCircle * yCoordForCircle);

        if (yCoord <= 1 || coordLength > (1.5 * 1.5) || xCoord <= -0.5 || xCoord >= 2.5)
        {
            Console.WriteLine("The point doesn't meet the conditions");
        }
        else
        {
            Console.WriteLine("The point meet the conditions");
        }       
    }
}
