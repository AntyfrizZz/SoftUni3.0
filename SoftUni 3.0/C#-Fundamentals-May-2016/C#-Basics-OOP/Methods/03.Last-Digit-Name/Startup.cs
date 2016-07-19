using System;

public class Number
{
    private int num;

    public int Num => this.num;

    public Number(int num)
    {
        this.num = num;
    }

    public string LastDigit()
    {
        switch (this.num % 10)
        {
            case 1:
                return "one";
            case 2:
                return "two";
            case 3:
                return "three";
            case 4:
                return "four";
            case 5:
                return "five";
            case 6:
                return "six";
            case 7:
                return "seven";
            case 8:
                return "eight";
            case 9:
                return "nine";
            default:
                return "zero";
        }
    }
}

class Startup
{
    static void Main()
    {
        var number = int.Parse(Console.ReadLine());

        var newNum = new Number(number);

        Console.WriteLine(newNum.LastDigit());
    }
}