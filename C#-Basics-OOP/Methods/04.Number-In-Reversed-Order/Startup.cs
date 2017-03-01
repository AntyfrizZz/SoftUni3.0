using System;
using System.Linq;

public class DecimalNumber
{
    public decimal number;

    public DecimalNumber(decimal number)
    {
        this.number = number;
    }

    public string Reverse()
    {
        var stringNumber = this.number.ToString();
        char[] charArray = stringNumber.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

class Startup
{
    static void Main()
    {
        var number = decimal.Parse(Console.ReadLine());

        var numberForReverse = new DecimalNumber(number);

        Console.WriteLine(numberForReverse.Reverse());
    }
}