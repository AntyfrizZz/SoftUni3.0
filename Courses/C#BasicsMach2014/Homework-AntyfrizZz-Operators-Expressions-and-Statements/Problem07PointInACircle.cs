using System;
//Write an expression that checks if given point (x,  y) is inside a circle K({0, 0}, 2).

class PointInACircle
{
    static void Main()
    {
        Console.Title = "Problem 7.	Point in a Circle";

        Console.Write(@"Enter ""x"" coordinate of the point: ");
        double xCoord = double.Parse(Console.ReadLine());
        Console.Write(@"Enter ""y"" coordinate of the point: ");
        double yCoord = double.Parse(Console.ReadLine());

        double radius = Math.Sqrt(xCoord * xCoord + yCoord * yCoord);

        Console.WriteLine(radius <= 2? "The given point is in the circle K({0, 0}, 2" : "The given point is't in the circle K({0, 0}, 2");
    }
}
