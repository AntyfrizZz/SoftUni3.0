using System;

class NestedLoopsToRecursion
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());

        int[] vector = new int[n];

        GeneratingVectors(0, vector);
    }

    private static void GeneratingVectors(int index, int[] vector)
    {
        if (index == vector.Length)
        {
            Print(vector);
        }
        else
        {
            for (int i = 1; i <= vector.Length; i++)
            {
                vector[index] = i;
                GeneratingVectors(index + 1, vector);
            }
        }
    }

    private static void Print(int[] vector)
    {
        foreach (int i in vector)
        {
            Console.Write("{0} ", i);
        }
        Console.WriteLine();
    }
}