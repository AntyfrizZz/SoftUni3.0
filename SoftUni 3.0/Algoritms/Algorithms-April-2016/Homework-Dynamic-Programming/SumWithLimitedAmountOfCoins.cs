using System;
using System.Collections.Generic;
using System.Linq;

namespace P05SumWithLimitedAmountOfCoins
{
    class SumWithLimitedAmountOfCoins
    {
        static void Main()
        {
            Console.Write("S = ");
            int sum = int.Parse(Console.ReadLine());

            Console.Write("Coins = ");
            string input = Console.ReadLine();
            List<int> coins = input.Split(new char[] { '{', '}', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int[,] memo = new int[coins.Count - 1, sum + 1];
            coins.Sort();
            Console.WriteLine(GetCount(coins, sum, coins.Count - 1, memo));
        }

        public static int GetCount(List<int> coins, int sum, int currCount, int[,] memo)
        {
            if (sum <= 0 || currCount < 0)
            {
                return 0;
            }

            if (memo[sum, currCount] > 0)
            {
                return memo[sum, currCount];
            }

            if (coins[currCount] == sum)
            {
                memo[sum, currCount] = 1;
            }

            var prevNonEqualCoin = currCount;
            while (prevNonEqualCoin >= 0 && coins[prevNonEqualCoin] == coins[currCount])
            {
                prevNonEqualCoin--;
            }
            memo[sum, currCount] += GetCount(coins, sum - coins[currCount], currCount - 1, memo) +
                GetCount(coins, sum, prevNonEqualCoin, memo);

            return memo[sum, currCount];
        }
    }
}
