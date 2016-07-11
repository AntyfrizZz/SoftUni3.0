using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Rectangle
{
    public string iD;
    public int width;
    public int height;
    public int topLeftX;
    public int topLeftY;

    public Rectangle(string iD, int width, int height, int topLeftX, int topLeftY)
    {
        this.iD = iD;
        this.width = width;
        this.height = height;
        this.topLeftX = topLeftX;
        this.topLeftY = topLeftY;
    }

    public bool Intersect(Rectangle rectangle)
    {
        if (rectangle.topLeftX + rectangle.width >= this.topLeftX && rectangle.topLeftX <= this.topLeftX + this.width &&
            rectangle.topLeftY + rectangle.width >= this.topLeftY && rectangle.topLeftY <= this.topLeftY + this.width
            )
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

        var inputLines = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        for (int i = 0; i < inputLines[0]; i++)
        {
            var currentRectangle = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            rectangles.Add(new Rectangle(currentRectangle[0],
                int.Parse(currentRectangle[1]),
                int.Parse(currentRectangle[2]),
                int.Parse(currentRectangle[3]),
                int.Parse(currentRectangle[4])));
        }

        var result = new StringBuilder();

        for (int i = 0; i < inputLines[1]; i++)
        {
            var check = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var firstRect = rectangles.First(r => r.iD.Equals(check[0]));
            var secondRect = rectangles.First(r => r.iD.Equals(check[1]));

            if (firstRect.Intersect(secondRect))
            {
                result.AppendLine("true");
            }
            else
            {
                result.AppendLine("false");
            }
        }

        Console.Write(result);
    }
}