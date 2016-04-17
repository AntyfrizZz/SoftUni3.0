using System;
using System.Collections.Generic;

class ImplementMergeSort
{
    static void Main()
    {
        int[] array = new int[] { 10, 23, 3, 14, 5 };
        MergeSort(ref array, 0, 4);

        Console.WriteLine(string.Join(", ", array));
    }

    public static void MergeSort(ref int[] x, int start, int end)
    {
        if (start < end)
        {
            int middle = (start + end) / 2;
            MergeSort(ref x, start, middle);
            MergeSort(ref x, middle + 1, end);
            Merge(ref x, start, middle, middle + 1, end);
        }
    }

    public static void Merge(ref int[] x, int left, int middle, int middle1, int right)
    {
        int oldPosition = left;
        int size = right - left + 1;
        int[] temp = new int[size];
        int i = 0;

        while (left <= middle && middle1 <= right)
        {
            if (x[left] <= x[middle1])
                temp[i++] = x[left++];
            else
                temp[i++] = x[middle1++];
        }
        if (left > middle)
            for (int j = middle1; j <= right; j++)
                temp[i++] = x[middle1++];
        else
            for (int j = left; j <= middle; j++)
                temp[i++] = x[left++];
        Array.Copy(temp, 0, x, oldPosition, size);
    }
}