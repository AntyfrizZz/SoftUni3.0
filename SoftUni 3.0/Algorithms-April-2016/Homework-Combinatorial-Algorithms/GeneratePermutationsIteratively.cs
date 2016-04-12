using System;
using System.Linq;

class GeneratePermutationsIteratively
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine();
        //An arbitrary list of objects to permute.
        var array = Enumerable.Range(1, n).ToArray();
        //Array for control the iteration initialize.
        var controlArray = new int[n];

        int i = 1;
        int j;

        while (i < n)
        {
            if (controlArray[i] < i)
            {
                Console.WriteLine(string.Join(", ", array));

                //If i is odd, then let j = controlArray[i] otherwise let j = 0
                j = i % 2 * controlArray[i];

                Swap(ref array[j], ref array[i]);

                controlArray[i]++;
                i = 1;
            }
            else
            {
                controlArray[i] = 0;
                i++;
            }

        }

        Console.WriteLine(string.Join(", ", array));
    }

    private static void Swap(ref int i, ref int j)
    {
        if (i == j)
        {
            return;
        }
        else
        {
            i ^= j;
            j ^= i;
            i ^= j;
        }
    }
}