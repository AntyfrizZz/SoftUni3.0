using System;
//Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
//•	Calculates the sum of the digits (in our example 2+0+1+1 = 4).
//•	Prints on the console the number in reversed order: dcba (in our example 1102).
//•	Puts the last digit in the first position: dabc (in our example 1201).
//•	Exchanges the second and the third digits: acbd (in our example 2101).
//The number has always exactly 4 digits and cannot start with 0. 

class FourDigitNumber
{
    static void Main()
    {
        Console.Title = "Problem 6.	Four-Digit Number";

        Console.Write("Enter a four digit number: ");
        int inputNumber = int.Parse(Console.ReadLine());

        if (inputNumber <= 999 || inputNumber > 9999)
        {
            Console.Write("Please enter four digit number: ");
            inputNumber = int.Parse(Console.ReadLine());
        }

        int units = inputNumber % 10;
        int tens = (inputNumber % 100) / 10;
        int hundreds = (inputNumber % 1000) / 100;
        int thousands = (inputNumber % 10000) / 1000;

        int digitsSum = units + tens + hundreds + thousands;

        Console.WriteLine("The sum of the digits: " + digitsSum);
        Console.WriteLine("The number in reversed order: " + units + tens + hundreds + thousands);
        Console.WriteLine("Last digit placed in the first place: " + units + thousands + hundreds + tens);
        Console.WriteLine("Second and the third digits exchanged: " + thousands + tens + hundreds + units);
    }
}
