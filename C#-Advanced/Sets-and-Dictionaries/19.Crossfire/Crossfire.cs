using System;
using System.Collections.Generic;
using System.Linq;

class Crossfire
{
    static List<List<int>> matrix;

    static void Main()
    {
        var matrixArgs = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var matrixRow = matrixArgs[0];
        var matrixCol = matrixArgs[1];

        matrix = new List<List<int>>();

        for (int i = 0; i < matrixRow; i++)
        {
            matrix.Add(new List<int>());

            for (int j = 0; j < matrixCol; j++)
            {
                matrix[i].Add(i * matrixCol + j + 1);
            }
        }

        var nuke = Console.ReadLine();

        while (nuke != "Nuke it from orbit")
        {
            //Console.WriteLine();
            //PrintMatrix(matrix);
            //Console.WriteLine();

            var nukeArgs = nuke
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var nukeRow = nukeArgs[0];
            var nukeCol = nukeArgs[1];
            var nukePower = nukeArgs[2];

            for (int currentRow = nukeRow - nukePower; currentRow <= nukeRow + nukePower; currentRow++)
            {
                if (isInMatrix(currentRow, nukeCol))
                {
                    matrix[currentRow][nukeCol] = -1;
                }
            }

            for (int currentCol = nukeCol - nukePower; currentCol <= nukeCol + nukePower; currentCol++)
            {
                if (isInMatrix(nukeRow, currentCol))
                {
                    matrix[nukeRow][currentCol] = -1;
                }
            }

            RemoveNuked();
            nuke = Console.ReadLine();
        }        

        PrintMatrix(matrix);
    }

    private static void RemoveNuked()
    {
        for (int row = 0; row < matrix.Count; row++)
        {
            matrix[row].RemoveAll(item => item == -1);
        }

        matrix.RemoveAll(list => list.Count == 0);
    }

    private static void PrintMatrix(List<List<int>> matrix)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            Console.WriteLine(string.Join(" ", matrix[i]));
        }
    }

    private static bool isInMatrix(int currentRow, int currentCol)
    {
        return 
            currentRow >= 0 && 
            currentRow < matrix.Count && 
            currentCol >= 0 && 
            currentCol < matrix[currentRow].Count;
    }
}