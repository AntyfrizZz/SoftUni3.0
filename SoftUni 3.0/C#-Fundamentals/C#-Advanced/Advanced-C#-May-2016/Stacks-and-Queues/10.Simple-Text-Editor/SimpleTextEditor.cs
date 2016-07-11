using System;
using System.Collections.Generic;
using System.Linq;

class SimpleTextEditor
{
    static Stack<string> last = new Stack<string>();
    static string current = string.Empty;

    static void Main()
    {
        last.Push(current);

        int numberOfOperations = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfOperations; i++)
        {
            var operationArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (operationArgs[0])
            {
                case "1":
                    Add(operationArgs[1]);
                    break;
                case "2":
                    Remove(int.Parse(operationArgs[1]));
                    break;
                case "3":
                    Print(int.Parse(operationArgs[1]));
                    break;
                case "4":
                    Recover();
                    break;
                default:
                    break;
            }
        }
    }

    private static void Recover()
    {
        last.Pop();
        current = last.Peek();
    }

    private static void Print(int position)
    {
        Console.WriteLine(last.Peek()[position - 1]);
    }

    private static void Remove(int count)
    {
        current = current.Substring(0, current.Length - count);
        last.Push(current);
    }

    private static void Add(string stringToAdd)
    {
        current += stringToAdd;
        last.Push(current);
    }
}