using System;
using System.Collections.Generic;

class CombinationsWithRepetition
{
    static List<string> result = new List<string>();

    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("k = ");
        int k = int.Parse(Console.ReadLine());

        int[] vector = new int[k];

        GeneratingCombinations(0, vector, n);

        foreach (var item in result)
        {
            foreach (var character in item)
            {
                Console.Write("{0} ", character);
            }
            Console.WriteLine(); 
        }
    }

    private static void GeneratingCombinations(int index, int[] vector, int nubmerOfElements)
    {
        if (index == vector.Length)
        {
            string resultVector = string.Join("", vector);
            string reversedVector = ReverseString(resultVector);

            if (result.Contains(resultVector) || result.Contains(reversedVector))
            {
                return;
            }

            result.Add(resultVector);            
        }
        else
        {
            for (int i = 1; i <= nubmerOfElements; i++)
            {
                vector[index] = i;
                GeneratingCombinations(index + 1, vector, nubmerOfElements);
            }
        }
    }

    public static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}
