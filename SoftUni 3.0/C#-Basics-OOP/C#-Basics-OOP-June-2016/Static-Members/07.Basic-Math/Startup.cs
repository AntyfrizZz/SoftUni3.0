using System;
using System.Text;

public class MathUtil
{
    public static double Sum(double a, double b)
    {
        return a + b;
    }

    public static double Substract(double a, double b)
    {
        return a - b;
    }

    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    public static double Divide(double a, double b)
    {
        return a / b;
    }

    public static double Percentage(double a, double b)
    {
        return a * (b / 100);
    }
}

class Startup
{
    static StringBuilder result = new StringBuilder();

    static void Main()
    {
        var input = Console.ReadLine();


        while (!input.Equals("End"))
        {
            var inputArgs = input.Split();

            var operation = inputArgs[0];
            var firstNum = double.Parse(inputArgs[1]);
            var secondNum = double.Parse(inputArgs[2]);

            switch (operation)
            {
                case "Sum":
                    result.AppendLine(string.Format("{0:F2}", MathUtil.Sum(firstNum, secondNum)));
                    break;
                case "Subtract":
                    result.AppendLine(string.Format("{0:F2}", MathUtil.Substract(firstNum, secondNum)));
                    break;
                case "Multiply":
                    result.AppendLine(string.Format("{0:F2}", MathUtil.Multiply(firstNum, secondNum)));
                    break;
                case "Divide":
                    result.AppendLine(string.Format("{0:F2}", MathUtil.Divide(firstNum, secondNum)));
                    break;
                case "Percentage":
                    result.AppendLine(string.Format("{0:F2}", MathUtil.Percentage(firstNum, secondNum)));
                    break;
            }

            input = Console.ReadLine();
        }

        Console.Write(result);
    }
}