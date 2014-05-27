using System;
//Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

class DivideBy7And5
{
    static void Main()
    {
        Console.Title = "Problem 3.	Divide by 7 and 5";

        Console.Write("Enter a number: ");
        int inputNumber = int.Parse(Console.ReadLine());

        bool dividable = (inputNumber % 7 == 0) && (inputNumber % 5 == 0) && (inputNumber != 0);

        Console.WriteLine(dividable ? "The number can be dividet by 7 and 5 in the same time" : "The number can't be dividet by 7 and 5 in the same time");
    }
}
