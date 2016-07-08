using System;
using System.Linq;


namespace P04SumWithUnlimitedAmountOfCoins
{
    class SumWithUnlimitedAmountOfCoins
    {
        static void Main()
        {
            Console.Write("S = ");
            int sum = int.Parse(Console.ReadLine());
            Console.Write("Coins = ");
            string input = Console.ReadLine();
            int[] coins = input.Split(new char[] { '{', '}', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => int.Parse(c)).ToArray();

            Console.WriteLine(GetCount(sum, coins));
        }

        public static int GetCount(int targetSum, int[] coins)
        {
            int[,] memo = new int[coins.Length, targetSum + 1];

            for (int row = 1; row < memo.GetLength(0); row++)
            {
                memo[row, 0] = 1;
                for (int col = 1; col < memo.GetLength(1); col++)
                {
                    if (coins[0] <= col && col % coins[0] == 0)
                    {
                        memo[0, col] = 1;
                    }
                    if (coins[row] > col)
                    {
                        memo[row, col] = memo[row - 1, col];
                    }
                    else
                    {
                        memo[row, col] = memo[row - 1, col] + memo[row, col - coins[row]];
                    }
                }
            }

            return memo[coins.Length - 1, targetSum];
        }
    }
}
