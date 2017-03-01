using System;
using System.Collections.Generic;
using System.Linq;

namespace P03DividingPresents
{
    class DividingPresents
    {
        static void Main()
        {
            int[] presents = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int valuesSum = presents.Sum();
            int?[] posibleSums = new int?[valuesSum + 1];
            posibleSums[0] = 0;

            for (int i = 0; i < presents.Length; i++)
            {
                for (int j = valuesSum; j >= 0; j--)
                {
                    if (posibleSums[j] != null && posibleSums[j + presents[i]] == null)
                    {
                        posibleSums[j + presents[i]] = i;
                    }
                }
            }

            var presentsResult = new List<int>();

            for (int i = valuesSum / 2; i >= 0; i--)
            {
                if (posibleSums[i] != null)
                {
                    while (i > 0)
                    {
                        presentsResult.Add(presents[posibleSums[i].Value]);
                        i -= presents[posibleSums[i].Value];
                    }
                    break;
                }
            }
            Console.WriteLine("Difference: {0}", Math.Abs(valuesSum - 2 * presentsResult.Sum()));
            Console.WriteLine("Alan:{0} Bob:{1}", presentsResult.Sum(), valuesSum - presentsResult.Sum());
            Console.WriteLine("Alan takes: {0}", string.Join(" ", presentsResult));
            Console.WriteLine("Bob takes the rest.");
        }
    }    
}
