using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var max = int.Parse(Console.ReadLine());
        var nums = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Distinct()
            .ToArray();

        var maxDel = nums.Max();

        var result = new List<int>();

        for (int i = 1; i <= max; i++)
        {
            var counter = 0;

            for (int j = 0; j < nums.Length; j++)
            {
                Predicate<int> divisible = n => n % nums[j] == 0;

                if (!divisible(i))
                {
                    break;
                }

                counter++;
            }

            if (counter == nums.Length)
            {
                //LCM Found and we begin to add all numbers that can be devided by it.
                for (int j = i; j <= max; j += i)
                {
                    result.Add(j);
                }

                Console.WriteLine(string.Join(" ", result));
                return;
            }
        }
    }
}