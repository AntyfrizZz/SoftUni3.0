using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Startup
{
    static int ivosRow;
    static int ivosCol;
    static int evilRow;
    static int evilCol;

    static HashSet<string> corrupted = new HashSet<string>();
    static BigInteger result = 0;

    static void Main()
    {
        var arrayArgs = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var ivosPoss = Console.ReadLine();
        var evilsPoss = Console.ReadLine();

        while (true)
        {
            ReadPos(ivosPoss, evilsPoss);

            //Skipping empty while loop iterations
            FixingIvosPosition(arrayArgs);
            FixingEvilsPosition(arrayArgs);

            while (evilRow >= 0 && evilCol >= 0)
            {
                corrupted.Add($"{evilRow}, {evilCol}");
                evilRow--;
                evilCol--;
            }

            var starValue = ivosRow * arrayArgs[1] + ivosCol;

            while (ivosRow >= 0 && ivosCol < arrayArgs[1])
            {
                if (!corrupted.Contains($"{ivosRow}, {ivosCol}"))
                {
                    result += starValue;
                }

                starValue = starValue - arrayArgs[1] + 1;
                ivosRow--;
                ivosCol++;
            }

            ivosPoss = Console.ReadLine();

            if (ivosPoss == "Let the Force be with you")
            {
                break;
            }
            evilsPoss = Console.ReadLine();
        }

        Console.WriteLine(result);
    }

    private static void ReadPos(string ivosPoss, string evilsPoss)
    {
        var ivosPosArgs = ivosPoss
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

        var evilForseArgs = evilsPoss
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        ivosRow = ivosPosArgs[0];
        ivosCol = ivosPosArgs[1];
        evilRow = evilForseArgs[0];
        evilCol = evilForseArgs[1];
    }

    private static void FixingEvilsPosition(int[] arrayArgs)
    {
        if (evilRow > arrayArgs[0] - 1 && evilCol > arrayArgs[1] - 1)
        {
            var max = Math.Max(evilRow - arrayArgs[0] + 1, evilCol - arrayArgs[1] + 1);
            evilRow -= max;
            evilCol -= max;
        }
        else if (evilRow > arrayArgs[0] - 1)
        {
            evilCol -= evilRow - arrayArgs[0] + 1;
            evilRow -= evilRow - arrayArgs[0] + 1;
        }
        else if (evilCol > arrayArgs[1] - 1)
        {
            evilRow -= evilCol - arrayArgs[1] + 1;
            evilCol -= evilCol - arrayArgs[1] + 1;
        }
    }

    private static void FixingIvosPosition(int[] arrayArgs)
    {
        if (ivosRow > arrayArgs[0] - 1 && ivosCol < 0)
        {
            var max = Math.Max(ivosRow - arrayArgs[0] + 1, ivosCol * -1);
            ivosRow -= max;
            ivosCol += max;
        }
        else if (ivosRow > arrayArgs[0] - 1)
        {
            ivosCol += ivosRow - arrayArgs[0] + 1;
            ivosRow -= ivosRow - arrayArgs[0] + 1;
        }
        else if (ivosCol < 0)
        {
            ivosRow -= ivosCol * -1;
            ivosCol += ivosCol * -1;
        }
    }
}