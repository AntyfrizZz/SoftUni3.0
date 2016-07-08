using System;
using System.Collections.Generic;
using System.Numerics;

class StackFibonacci
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        if (n == 0)
        {
            Console.WriteLine("0");
            return;
        }
        else if (n == 1)
        {
            Console.WriteLine("1");
            return;
        }
        else if (n == 2)
        {
            Console.WriteLine("1");
            return;
        }

        var fibonacci = new Stack<BigInteger>();

        fibonacci.Push(0);
        fibonacci.Push(1);
        fibonacci.Push(1);

        int counter = 2;
        BigInteger result;

        while (true)
        {        
            BigInteger lastFib = fibonacci.Pop();            
            BigInteger beforeLast = fibonacci.Peek();
            
            counter++;

            if (counter == n)
            {
                result = lastFib + beforeLast;
                Console.WriteLine(result);
                return;
            }

            fibonacci.Push(lastFib);
            fibonacci.Push(lastFib + beforeLast);
        }        
    }
}