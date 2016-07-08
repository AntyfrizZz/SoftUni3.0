using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public abstract class Shape
{
    public abstract void Draw();
}

public class Square : Shape
{
    public int side;

    public Square(int side)
    {
        this.side = side;
    }

    public override void Draw()
    {
        var result = new StringBuilder();

        result.AppendLine($"|{new string('-', side)}|");
        for (int i = 1; i < side - 1; i++)
        {
            result.AppendLine($"|{new string(' ', side)}|");
        }
        result.AppendLine($"|{new string('-', side)}|");

        Console.Write(result);
    }
}

public class Rectangle : Shape
{
    public int width;
    public int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public override void Draw()
    {
        var result = new StringBuilder();

        result.AppendLine($"|{new string('-', width)}|");
        for (int i = 1; i < height - 1; i++)
        {
            result.AppendLine($"|{new string(' ', width)}|");
        }
        result.AppendLine($"|{new string('-', width)}|");

        Console.Write(result);
    }
}

public class CorDraw
{
    public CorDraw(Shape shape)
    {
        shape.Draw();
    }
}

class Startup
{
    static void Main()
    {
        var shape = Console.ReadLine();

        if (shape.Equals("Rectangle"))
        {
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());

            var draw = new CorDraw(new Rectangle(width, height));
        }
        else
        {
            var side = int.Parse(Console.ReadLine());

            var draw = new CorDraw(new Square(side));
        }
    }
}