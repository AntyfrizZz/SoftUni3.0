using System;

class ImplementHeapSort
{
    static void Main()
    {
        int[] array = new int[] { 10, 23, 3, 14, 5 };
        Heapsort(ref array);

        Console.WriteLine(string.Join(", ", array));
    }

    public static void Heapsort(ref int[] array)
    {
        int i;
        int temp;
        int n = array.Length;

        for (i = (n / 2) - 1; i >= 0; i--)
        {
            siftDown(ref array, i, n);
        }

        for (i = n - 1; i >= 1; i--)
        {
            temp = array[0];
            array[0] = array[i];
            array[i] = temp;
            siftDown(ref array, 0, i - 1);
        }
    }

    public static void siftDown(ref int[] x, int root, int bottom)
    {
        bool done = false;
        int maxChild;
        int temp;

        while ((root * 2 <= bottom) && (!done))
        {
            if (root * 2 == bottom)
                maxChild = root * 2;
            else if (x[root * 2] > x[root * 2 + 1])
                maxChild = root * 2;
            else
                maxChild = root * 2 + 1;

            if (x[root] < x[maxChild])
            {
                temp = x[root];
                x[root] = x[maxChild];
                x[maxChild] = temp;
                root = maxChild;
            }
            else
            {
                done = true;
            }
        }
    }
}