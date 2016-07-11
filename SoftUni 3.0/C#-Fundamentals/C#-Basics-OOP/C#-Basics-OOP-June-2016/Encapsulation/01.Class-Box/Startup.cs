using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Box
{
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double CalculateSurface()
    {
        return 2*(this.Length*this.Width + this.Length*this.Height + this.Width*this.Height);
    }

    public double CalculateLateralSurface()
    {
        return 2 * (this.Length * this.Height + this.Width * this.Height);
    }

    public double CalculateVolume()
    {
        return this.Length * this.Width  * this.Height;
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

        var box = new Box(length, width, height);

        var result = new StringBuilder();
        result.AppendLine($"Surface Area - {box.CalculateSurface():F2}");
        result.AppendLine($"Lateral Surface Area - {box.CalculateLateralSurface():F2}");
        result.AppendLine($"Volume - {box.CalculateVolume():F2}");

        Console.Write(result);
    }
}