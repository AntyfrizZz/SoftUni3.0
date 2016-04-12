using System;
using System.Collections.Generic;

class CombinationsIteratively
{
    static void Main()
    {
        foreach (int[] c in Combinations(3, 5))
        {
            for (int i = 0; i < c.Length; i++)
            {
                Console.Write(c[i] + " ");
            }
            Console.WriteLine();
        }
    }

    public static IEnumerable<int[]> Combinations(int m, int n)
    {
        int[] result = new int[m];
        Stack<int> stack = new Stack<int>();
        stack.Push(1);

        while (stack.Count > 0)
        {
            int index = stack.Count - 1;
            int value = stack.Pop();

            while (value < n + 1)
            {
                result[index++] = value++;
                stack.Push(value);
                if (index == m)
                {
                    yield return result;
                    break;
                }
            }
        }
    }
}