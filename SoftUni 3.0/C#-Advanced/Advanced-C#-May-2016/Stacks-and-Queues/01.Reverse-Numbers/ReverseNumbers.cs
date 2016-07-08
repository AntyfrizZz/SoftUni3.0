using System;
using System.Collections.Generic;
using System.Linq;


class ReverseNumbers
{
    static void Main()
    {
        var input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var stack = new Stack<int>();

        foreach (var item in input)
        {
            stack.Push(item);
        }

        for (int i = 0; i < input.Length; i++)
        {
            int pop = stack.Pop();
            Console.Write(pop);
            Console.Write(" ");
        }
            
 
        




    }
}