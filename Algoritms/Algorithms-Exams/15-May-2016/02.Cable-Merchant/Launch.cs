using System;
using System.Linq;

class Launch
{
    //Mine with int[]
    static void Main()
    {
        var prices = Console.ReadLine()
          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
          .Select(int.Parse)
          .ToArray();

        var connectorPrice = int.Parse(Console.ReadLine());

        var bestPrices = new int[prices.Length];

        for (int i = 0; i < prices.Length; i++)
        {
            var max = prices[i];
            for (int j = i - 1; j >= i / 2; j--)
            {
                max = Math.Max(max, bestPrices[j] + bestPrices[i - j - 1] - 2 * connectorPrice);
            }
            bestPrices[i] = max;
        }

        Console.WriteLine(string.Join(" ", bestPrices));
    }

    //With List<>
    //public static void Main(string[] args)
    //{
    //    List<int> prices = Console.ReadLine().Split().Select(int.Parse).ToList();
    //    prices.Insert(0, 0);
    //    int connectorPrice = int.Parse(Console.ReadLine());

    //    List<int> bestPrices = new List<int>();
    //    bestPrices.Add(0);

    //    for (int i = 1; i < prices.Count; i++)
    //    {
    //        var max = prices[i];
    //        for (int j = 1; j < i; j++)
    //        {
    //            max = Math.Max(max, bestPrices[j] + bestPrices[i - j] - 2 * connectorPrice);
    //        }
    //        bestPrices.Add(max);
    //    }

    //    bestPrices.RemoveAt(0);
    //    Console.WriteLine(string.Join(" ", bestPrices));
    //}
}
