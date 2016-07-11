using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

public class Fibonacci
{
    private List<BigInteger> fibNumbers;

    public List<BigInteger> FibNumbers => this.fibNumbers;

    public Fibonacci(List<BigInteger> fibNumbers, int end)
    {
        this.fibNumbers = fibNumbers;

        this.fibNumbers.Add(0);
        this.fibNumbers.Add(1);
        this.fibNumbers.Add(1);

        for (int i = 3; i < end; i++)
        {
            this.fibNumbers.Add(this.fibNumbers[i - 1] + this.fibNumbers[i - 2]);
        }
    }

    public List<BigInteger> GetNumbersInRange(int startPosition, int endPosition)
    {
        var result = new List<BigInteger>();

        for (int i = startPosition; i < endPosition; i++)
        {
            result.Add(this.fibNumbers[i]);
        }

        return result;
    }

}

class Startup
{
    static void Main()
    {
        var fibNumbers = new List<BigInteger>();
        var start = int.Parse(Console.ReadLine());
        var end = int.Parse(Console.ReadLine());

        var fibonacci = new Fibonacci(fibNumbers, end);

        var result = fibonacci.GetNumbersInRange(start, end);

        Console.WriteLine(string.Join(", ", result));
    }
}