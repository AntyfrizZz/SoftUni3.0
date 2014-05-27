using System;
//Write an expression that checks if given positive integer number n (n ≤ 100) is prime (i.e. it is divisible without remainder only to itself and 1).

class PrimeNumberCheck
{
    static void Main()
    {
        Console.Title = "Problem 8.	Prime Number Check";

        Console.Write("Enter a positive number n (n < 100): ");
        int inputNumber = int.Parse(Console.ReadLine());

        while (inputNumber <= 0 || inputNumber > 99)
        {
            Console.Write("Please enter a positive number n (n < 100): ");
            inputNumber = int.Parse(Console.ReadLine());
        }

        bool prime = IsPrime(inputNumber);
        Console.WriteLine(prime ? "The number is prime." : "The number isn't prime.");
    }

    public static bool IsPrime(int candidate)
    {
        if ((candidate & 1) == 0)
        {
            if (candidate == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        for (int i = 3; (i * i) <= candidate; i += 2)
        {
            if ((candidate % i) == 0)
            {
                return false;
            }
        }
        return candidate != 1;
    }
}