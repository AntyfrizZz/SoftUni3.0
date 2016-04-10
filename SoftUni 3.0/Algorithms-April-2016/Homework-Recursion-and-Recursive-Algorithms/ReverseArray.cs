using System;

class ReverseArray
{
    static int[] array = { 1, 3, 5, 7, 9 };
    static int[] reversedArray = new int[array.Length];

    static void Main()
    {
        
        Console.WriteLine(string.Join(" ,", array));       

        ArrayReverse(0);

        Console.WriteLine(string.Join(" ,", reversedArray));
    }

    private static void ArrayReverse(int index)
    {
        if (index >= array.Length)
        {
            return;
        }
        else
        {
            reversedArray[index] = array[array.Length - 1 - index];
            ArrayReverse(index + 1);
        }
    }
}
