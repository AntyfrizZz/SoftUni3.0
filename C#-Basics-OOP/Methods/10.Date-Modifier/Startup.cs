using System;
using System.Globalization;

public class DateModifier
{
    public static double CalculateDifference(string firstDate, string secondDate)
    {
        var first = DateTime.Parse(
            firstDate.Trim(),
            CultureInfo.InvariantCulture);

        var second = DateTime.Parse(
            secondDate.Trim(),
            CultureInfo.InvariantCulture);

        return Math.Abs((first - second).TotalDays);
    }
}
class Startup
{
    static void Main()
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        Console.WriteLine(DateModifier.CalculateDifference(firstDate, secondDate));
    }
}