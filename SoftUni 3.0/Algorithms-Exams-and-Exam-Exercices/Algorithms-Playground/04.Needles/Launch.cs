using System;
using System.Linq;

class Launch
{
    static string input = Console.ReadLine();
    static string cInput = Console.ReadLine();
    static string nInput = Console.ReadLine();

    static int[] c = cInput
        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    static int[] needles = nInput
        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();

    static int[] result = new int[needles.Length];

    static void Main()
    {
        int needleIndex = -1;

        foreach (var needle in needles)
        {
            needleIndex++;
            bool match = false;

            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] >= needle)
                {
                    match = true;
                    ReturnIndex(c, i - 1, needleIndex);
                    break;
                }
            }

            if (!match)
            {
                ReturnIndex(c, c.Length - 1, needleIndex);
            }
        }



        Console.WriteLine(string.Join(" ", result));
    }

    private static void ReturnIndex(int[] nums, int i, int needleIndex)
    {
        while (i >= 0)
        {
            if (nums[i] != 0)
            {
                result[needleIndex] = (i + 1);
                return;
            }
            i--;
        }

        result[needleIndex] = 0;
    }
}
