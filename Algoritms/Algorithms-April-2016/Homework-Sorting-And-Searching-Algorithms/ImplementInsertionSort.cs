using System;
using System.Collections.Generic;

public static class TestSorter
{
    public static void Sorterer(this List<int> list)
    {
        List<int> collections = list;

        for (int i = 1; i < collections.Count; i++)
        {
            int targetIndex = i;
            int temp;

            while (targetIndex > 0 && collections[i] < collections[targetIndex - 1])
            {
                targetIndex--;
            }

            if (targetIndex < i)
            {
                temp = collections[i];
                collections.RemoveAt(i);
                collections.Insert(targetIndex, temp);
            }
        }
    }
}

class ImplementInsertionSort
{   
    static void Main()
    {
        List<int> collections = new List<int> { 3, 4, 1, 2, 3245, 5, 6, 7 };
        Console.WriteLine(string.Join(", ", collections));
        collections.Sorterer();
        Console.WriteLine(string.Join(", ", collections));
    }
}
