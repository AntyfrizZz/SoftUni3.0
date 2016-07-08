using System;
using System.Collections.Generic;
using System.Text;

class MaximumElement
{
    static void Main()
    {
        var numberOfQUeries = int.Parse(Console.ReadLine());

        var stack = new Stack<int>();
        var maxNumbers = new Stack<int>();
        var maxElement = int.MinValue;

        var result = new StringBuilder();

        for (int i = 0; i < numberOfQUeries; i++)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (input[0] == "1")
            {
                stack.Push(int.Parse(input[1]));

                if (stack.Peek() >= maxElement)
                {
                    maxElement = stack.Peek();
                    maxNumbers.Push(stack.Peek());
                }
            }
            else if (input[0] == "2")
            {
                int popElement = stack.Pop();
                if (maxElement == popElement)
                {
                    maxNumbers.Pop();
                }

                if (maxNumbers.Count > 0)
                {
                    maxElement = maxNumbers.Peek();
                }
                else
                {
                    maxElement = int.MinValue;
                }
            }
            else
            {
                Console.WriteLine(maxNumbers.Peek());
            }
        }

    }
}