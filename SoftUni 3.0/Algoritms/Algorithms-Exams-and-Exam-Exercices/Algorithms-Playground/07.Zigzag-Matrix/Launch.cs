﻿namespace Zigzag_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Launch
    {
        public static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int numberOfColumns = int.Parse(Console.ReadLine());

            int[][] matrix = new int[numberOfRows][];
            ReadMatrix(numberOfRows, matrix);

            int[,] maxPaths = new int[numberOfRows, numberOfColumns];
            int[,] previousRowIndex = new int[numberOfRows, numberOfColumns];

            for (int row = 1; row < numberOfRows; row++)
            {
                maxPaths[row, 0] = matrix[row][0];
            }

            for (int col = 1; col < numberOfColumns; col++)
            {
                for (int row = 0; row < numberOfRows; row++)
                {
                    int previousMax = 0;

                    if (col % 2 != 0)
                    {
                        for (int i = row + 1; i < numberOfRows; i++)
                        {
                            if (maxPaths[i, col - 1] > previousMax)
                            {
                                previousMax = maxPaths[i, col - 1];
                                previousRowIndex[row, col] = i;
                            }

                            maxPaths[row, col] = previousMax + matrix[row][col];
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= row - 1; i++)
                        {
                            if (maxPaths[i, col - 1] > previousMax)
                            {
                                previousMax = maxPaths[i, col - 1];
                                previousRowIndex[row, col] = i;
                            }

                            maxPaths[row, col] = previousMax + matrix[row][col];
                        }
                    }
                }
            }

            var currentRowIndex = GetLastRowIndexOfPath(maxPaths);

            var path = RecoverMaxPath(numberOfColumns, matrix, currentRowIndex, previousRowIndex);

            Console.WriteLine("{0} = {1}", path.Sum(), string.Join(" + ", path));
        }

        private static void ReadMatrix(int numberOfRows, int[][] matrix)
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
            }
        }

        private static int GetLastRowIndexOfPath(int[,] maxPaths)
        {
            int currentRowIndex = -1;
            int globalMax = 0;

            for (int row = 0; row < maxPaths.GetLength(0); row++)
            {
                if (maxPaths[row, maxPaths.GetLength(1) - 1] > globalMax)
                {
                    globalMax = maxPaths[row, maxPaths.GetLength(1) - 1];
                    currentRowIndex = row;
                }
            }

            return currentRowIndex;
        }

        private static List<int> RecoverMaxPath(
            int numberOfColumns,
            int[][] matrix,
            int rowIndex,
            int[,] previousRowIndex)
        {
            List<int> path = new List<int>();
            int columnIndex = numberOfColumns - 1;

            while (columnIndex >= 0)
            {
                path.Add(matrix[rowIndex][columnIndex]);
                rowIndex = previousRowIndex[rowIndex, columnIndex];

                columnIndex--;
            }

            path.Reverse();
            return path;
        }
    }
}