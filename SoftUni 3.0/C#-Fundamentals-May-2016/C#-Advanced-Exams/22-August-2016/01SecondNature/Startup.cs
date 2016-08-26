using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Startup
{
    public static void Main()
    {
        var flowers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        var buckets = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        var secondNature = new Queue<int>();

        var bucket = buckets.Length - 1;
        var flower = 0;

        while (bucket >= 0 && flower < flowers.Length)
        {
            if (buckets[bucket] == flowers[flower])
            {
                secondNature.Enqueue(flowers[flower]);

                buckets[bucket] = 0;
                bucket--;
                flower++;
            }
            else if (buckets[bucket] < flowers[flower])
            {
                flowers[flower] -= buckets[bucket];
                buckets[bucket] = 0;
                bucket--;
            }
            else
            {
                buckets[bucket] -= flowers[flower];
                flowers[flower] = 0;

                if (bucket != 0)
                {
                    buckets[bucket - 1] += buckets[bucket];
                    buckets[bucket] = 0;
                    bucket--;
                }
                
                flower++;
            }
        }

        var result = new StringBuilder();

        if (buckets[0] != 0)
        {
            for (int i = bucket; i >= 0; i--)
            {
                result.Append(buckets[i] + " ");
            }
        }
        else
        {
            for (int i = flower; i < flowers.Length; i++)
            {
                result.Append(flowers[i] + " ");
            }
        }

        result.AppendLine();

        if (secondNature.Any())
        {
            while (secondNature.Any())
            {
                result.Append(secondNature.Dequeue() + " ");
            }
        }
        else
        {
            result.Append("None");
        }


        Console.WriteLine(result);
    }
}