using System;
using System.Collections.Generic;

class ImplementInterpolationSearch
{
    static void Main()
    {
        int[] array = new int[] { 1, 2, 3, 4, 5};

        Console.WriteLine(InterpolationSearch(ref array, 1));
        Console.WriteLine(InterpolationSearch(ref array, 2));
        Console.WriteLine(InterpolationSearch(ref array, 5));
        Console.WriteLine(InterpolationSearch(ref array, 7));
    }

    public static int InterpolationSearch(ref int[] array, int searchValue)
    {
        int low = 0;
        int high = array.Length - 1;
        int middle;

        while (array[low] < searchValue && array[high] >= searchValue)
        {
            middle = low + ((searchValue - array[low]) * (high - low)) / (array[high] - array[low]);

            if (array[middle] < searchValue)
                low = middle + 1;
            else if (array[middle] > searchValue)
                high = middle - 1;
            else
                return middle;
        }

        if (array[low] == searchValue)
            return low;
        else
            return -1; // Not found
    }
}