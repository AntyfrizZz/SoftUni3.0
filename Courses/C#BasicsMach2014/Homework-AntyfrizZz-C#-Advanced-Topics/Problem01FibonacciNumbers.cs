using System;
using System.Numerics;
//Define a method Fib(n) that calculates the nth Fibonacci number.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/7.%20CSharp-Advanced-Topics-Homework.docx

class FibonacciNumbers
{
    static void Main()
    {
        A:
        int inputNum = int.Parse(Console.ReadLine());
        BigInteger result = Fib(inputNum);

        Console.WriteLine(result);
        Console.WriteLine();

        goto A;
    }

    private static BigInteger Fib(int n)
    {
        BigInteger firstNum = 0;
        BigInteger secondNum = 1;
        BigInteger nextNum;

        if (n == 0) return firstNum = 1;
        if (n == 1) return secondNum;
        else
        {
            for (int i = 1; i <= n; i++)
            {
                nextNum = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = nextNum;

                if (i == n)
                {
                    return nextNum;
                }
            }
        }

        return 0;
    }
}