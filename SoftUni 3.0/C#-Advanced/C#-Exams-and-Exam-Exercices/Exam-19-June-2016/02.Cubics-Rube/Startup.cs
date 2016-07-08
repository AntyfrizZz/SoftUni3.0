using System;
using System.Linq;
using System.Numerics;

class Startup
{
    static int CellsCount;
    static BigInteger result = 0;

    static void Main()
    {
        var cubeDimensions = int.Parse(Console.ReadLine());
        CellsCount = cubeDimensions * cubeDimensions * cubeDimensions;

        var bombard = Console.ReadLine();

        while (!bombard.Equals("Analyze"))
        {
            var bombardArgs = bombard.Split()
                .Select(int.Parse)
                .ToArray();

            var x = bombardArgs[0];
            var y = bombardArgs[1];
            var z = bombardArgs[2];
            var value = bombardArgs[3];

            if (x < cubeDimensions && 
                x >= 0 &&
                y < cubeDimensions &&
                y >= 0 &&
                z < cubeDimensions &&
                z >= 0 &&
                value != 0)
            {
                result += value;
                CellsCount--;
            }

            bombard = Console.ReadLine();
        }

        Console.WriteLine(result);
        Console.WriteLine(CellsCount);
    }
}