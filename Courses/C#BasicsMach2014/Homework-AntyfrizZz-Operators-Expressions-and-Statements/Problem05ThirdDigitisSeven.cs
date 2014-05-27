using System;
//Write an expression that checks for given integer if its third digit from right-to-left is 7.

class ThirdDigitisSeven
{
    static void Main()
    {
        Console.Title = "Problem 5.	Third Digit is 7?";

        Console.Write("Enter a number: ");
        int inputNumber = int.Parse(Console.ReadLine());
        int dividedNumber = inputNumber % 100;

        Console.WriteLine(dividedNumber % 7 == 0 ? "The third digit of the given number is 7." : "The third digit of the given number is 7.");
    }
}
