using System;

class Program
{
    static void Main()
    {
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Shuffle(array);

            Console.WriteLine(string.Join(", ", array));
        }
    }
    static Random _random = new Random();

    static void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            int r = i + (int)(_random.NextDouble() * (n - i));
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }    
}