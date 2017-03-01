using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get { return this.length; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }

            this.length = value;
        }
    }
    public double Width
    {
        get { return this.width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }

            this.width = value;
        }
    }
    public double Height
    {
        get { return this.height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }

            this.height = value;
        }
    }

    public double CalculateSurface()
    {
        return 2 * (
            this.length * this.width + 
            this.length * this.height + 
            this.width * this.height);
    }

    public double CalculateLateralSurface()
    {
        return 2 * (
            this.length * this.height + 
            this.width * this.height);
    }

    public double CalculateVolume()
    {
        return this.length * this.width * this.height;
    }
}

class Startup
{
    static void Main()
    {

        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        var length = double.Parse(Console.ReadLine());
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());

        try
        {
            var box = new Box(length, width, height);
        
            var result = new StringBuilder();
            result.AppendLine($"Surface Area - {box.CalculateSurface():F2}");
            result.AppendLine($"Lateral Surface Area - {box.CalculateLateralSurface():F2}");
            result.AppendLine($"Volume - {box.CalculateVolume():F2}");

            Console.Write(result);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}