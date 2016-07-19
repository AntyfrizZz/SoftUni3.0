using System;
using System.Text;

class Startup
{
    static StringBuilder result = new StringBuilder();

    static void Main()
    {
        var input = Console.ReadLine();

        while (!input.Equals("End"))
        {
            var inputArgs = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (inputArgs[1].Equals("Celsius"))
            {
                ToFahrenheit(double.Parse(inputArgs[0]));
            }
            else
            {
                ToCelsius(double.Parse(inputArgs[0]));
            }

            input = Console.ReadLine();
        }

        Console.Write(result);
    }

    public static void ToCelsius(double temperature)
    {
        var converted = (temperature - 32) /1.8;
        result.AppendLine($"{converted:F2} Celsius");
    }

    public static void ToFahrenheit(double temperature)
    {
        var converted = (temperature * 1.8) + 32;
        result.AppendLine($"{converted:F2} Fahrenheit");
    }
}