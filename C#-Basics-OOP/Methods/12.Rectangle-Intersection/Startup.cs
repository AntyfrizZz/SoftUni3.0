using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Rectangle
{
    public string iD;
    public decimal width;
    public decimal height;
    public decimal topLeftX;
    public decimal topLeftY;

    public Rectangle(string iD, decimal width, decimal height, decimal topLeftX, decimal topLeftY)
    {
        this.iD = iD;
        this.width = width;
        this.height = height;
        this.topLeftX = topLeftX;
        this.topLeftY = topLeftY;
    }

    public bool Intersect(Rectangle rectangle)
    {
        if (rectangle.topLeftX + rectangle.width >= this.topLeftX && 
            rectangle.topLeftX <= this.topLeftX + this.width &&
            rectangle.topLeftY >= this.topLeftY - this.height && 
            rectangle.topLeftY - rectangle.height <= this.topLeftY)
        {
            return true;
        }

        return false;
    }
}

class Startup
{
    static void Main()
    {
        var rectangles = new List<Rectangle>();

        var input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var numberOfRectangles = input[0];
        var numberOfChecks = input[1];

        for (int i = 0; i < numberOfRectangles; i++)
        {
            var currentRectangle = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rectangleId = currentRectangle[0];
            var rectangleWidth = decimal.Parse(currentRectangle[1]);
            var rectangleHeight = decimal.Parse(currentRectangle[2]);
            var rectanglTopLeftX = decimal.Parse(currentRectangle[3]);
            var rectanglTopLeftY= decimal.Parse(currentRectangle[4]);

            rectangles.Add(new Rectangle(rectangleId,
                rectangleWidth,
                rectangleHeight,
                rectanglTopLeftX,
                rectanglTopLeftY));
        }

        var result = new StringBuilder();

        for (int i = 0; i < numberOfChecks; i++)
        {
            var check = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var firstRect = rectangles.First(r => r.iD.Equals(check[0]));
            var secondRect = rectangles.First(r => r.iD.Equals(check[1]));

            result.AppendLine(firstRect.Intersect(secondRect) ? "true" : "false");
        }

        Console.Write(result);
    }
}