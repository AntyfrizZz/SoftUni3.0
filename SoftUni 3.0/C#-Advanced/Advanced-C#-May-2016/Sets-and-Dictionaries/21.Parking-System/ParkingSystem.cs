using System;
using System.Collections.Generic;
using System.Linq;

public class ParkingSystem
{
    private static Dictionary<int, HashSet<int>> spotsTaken;
    private static int rows;
    private static int cols;

    public static void Main()
    {
        spotsTaken = new Dictionary<int, HashSet<int>>();
        var parkingLotArgs = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        rows = parkingLotArgs[0];
        cols = parkingLotArgs[1];

        var command = Console.ReadLine();

        while (command != "stop")
        {
            var commandArgs = command
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var entryRow = commandArgs[0];
            var parkingRow = commandArgs[1];
            var parkingCol = commandArgs[2];

            if (IsSpotTaken(parkingRow, parkingCol))
            {
                parkingCol = TryFindFreeSpot(parkingRow, parkingCol);
            }

            // targetCol value of 0 means a row is full
            if (parkingCol > 0)
            {
                MarkSpotAsTaken(parkingRow, parkingCol);

                int distance = Math.Abs(parkingRow - entryRow) + parkingCol + 1;
                Console.WriteLine(distance);
            }
            else
            {
                Console.WriteLine($"Row {parkingRow} full");
            }

            command = Console.ReadLine();
        }
    }

    private static int TryFindFreeSpot(int row, int col)
    {
        int newCol = 0;
        int bestLength = int.MaxValue;
        for (int columnIndex = 1; columnIndex < cols; columnIndex++)
        {
            if (!IsSpotTaken(row, columnIndex))
            {
                int newLength = Math.Abs(col - columnIndex);
                if (newLength < bestLength)
                {
                    bestLength = newLength;
                    newCol = columnIndex;
                }
            }
        }

        return newCol;
    }

    private static bool IsSpotTaken(int row, int col)
    {
        return spotsTaken.ContainsKey(row) && spotsTaken[row].Contains(col);
    }

    private static void MarkSpotAsTaken(int row, int col)
    {
        if (!spotsTaken.ContainsKey(row))
        {
            spotsTaken[row] = new HashSet<int>();
        }
        spotsTaken[row].Add(col);
    }
}