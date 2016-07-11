using System;
using System.Collections.Generic;
using System.Linq;

class RubiksMatrix
{
    static int[,] rubik;
    static int rows;
    static int cols;
    static Dictionary<int, Tuple<int, int>> indexesOfNumbers = new Dictionary<int, Tuple<int, int>>();

    static void Main()
    {
        var dimentionArgs = Console.ReadLine()
              .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

        rows = dimentionArgs[0];
        cols = dimentionArgs[1];

        rubik = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                rubik[row, col] = row * cols + col + 1;
            }
        }

        var numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            var command = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rowOrColToMove = int.Parse(command[0]);
            var direction = command[1];
            var timesToMove = int.Parse(command[2]);

            switch (direction)
            {
                case "left":
                    if (timesToMove % cols != 0) //No rotation required
                    {
                        MoveRow(timesToMove % cols, rowOrColToMove);
                    }                    
                    break;
                case "right":
                    if (timesToMove % cols != 0) //No rotation required
                    {
                        MoveRow(cols - timesToMove % cols, rowOrColToMove);
                    }                    
                    break;
                case "up":
                    if (timesToMove % rows != 0) //No rotation required
                    {
                        MoveCols(timesToMove % rows, rowOrColToMove);
                    }                    
                    break;
                case "down":
                    if (timesToMove % rows != 0) //No rotation required
                    {
                        MoveCols(rows - timesToMove % rows, rowOrColToMove);
                    }                    
                    break;
                default:
                    break;
            }
        }

        //Memoization positions of the values
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                indexesOfNumbers.Add(rubik[row, col], new Tuple<int, int>(row, col));
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (rubik[row, col] == row * cols + col + 1)
                {
                    Console.WriteLine("No swap required");
                }
                else
                {
                    int rowForSwap = indexesOfNumbers[row * cols + col + 1].Item1;
                    int colForSwap = indexesOfNumbers[row * cols + col + 1].Item2;

                    rubik[row, col] ^= rubik[rowForSwap, colForSwap];
                    rubik[rowForSwap, colForSwap] ^= rubik[row, col];
                    rubik[row, col] ^= rubik[rowForSwap, colForSwap];

                    indexesOfNumbers[rubik[rowForSwap, colForSwap]] = new Tuple<int, int>(rowForSwap, colForSwap);
                    indexesOfNumbers[rubik[row, col]] = new Tuple<int, int>(row, col);

                    Console.WriteLine("Swap ({0}, {1}) with ({2}, {3})", row, col, rowForSwap, colForSwap);
                }
            }
        }
    }

    private static void MoveRow(int moves, int row)
    {
        var temp = new int[cols];

        for (int index = 0; index < cols; index++)
        {
            temp[index] = rubik[row, (index + moves) % cols];
        }

        for (int index = 0; index < cols; index++)
        {
            rubik[row, index] = temp[index];
        }
    }

    private static void MoveCols(int moves, int col)
    {
        var temp = new int[rows];

        for (int index = 0; index < rows; index++)
        {
            temp[index] = rubik[(index + moves) % rows, col];
        }

        for (int index = 0; index < rows; index++)
        {
            rubik[index, col] = temp[index];
        }
    }
}