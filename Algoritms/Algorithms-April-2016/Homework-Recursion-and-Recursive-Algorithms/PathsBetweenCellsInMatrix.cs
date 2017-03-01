using System;
using System.Collections.Generic;

class PathsBetweenCellsInMatrix
{
    //static char[,] labirynth =
    //{
    //    {' ', ' ', ' ', ' '},
    //    {' ', '*', '*', ' '},
    //    {' ', '*', '*', ' '},
    //    {' ', '*', 'e', ' '},
    //    {' ', ' ', ' ', ' '},
    //};

    static char[,] labirynth =
    {
        {' ', '*', ' ', ' ', ' ', ' '},
        {' ', '*', '*', ' ', '*', ' '},
        {' ', '*', '*', ' ', '*', ' '},
        {' ', '*', 'e', ' ', ' ', ' '},
        {' ', ' ', ' ', ' ', ' ', ' '},
    };

    static List<string> path = new List<string>();
    static int counter = 0;

    static bool InRange(int row, int col)
    {
        bool rowInRange = row >= 0 && row < labirynth.GetLength(0);
        bool colInRange = col >= 0 && col < labirynth.GetLength(1);
        return rowInRange && colInRange;
    }

    static void Main()
    {
        FindPathToExit(0, 0, "");

        Console.WriteLine("Total paths found: {0}", counter);
    }


    static void FindPathToExit(int row, int col, string direction)
    {
        if (!InRange(row, col))
        {
            return;
        }

        if (labirynth[row, col] == 'e')
        {
            counter++;
            path.Add(direction);
            Console.WriteLine(string.Join("", path));
            path.RemoveAt(path.Count - 1);
        }

        if (labirynth[row, col] != ' ')
        {
            return;
        }

        labirynth[row, col] = 'B';
        path.Add(direction);

        FindPathToExit(row, col - 1, "L"); // left
        FindPathToExit(row - 1, col, "U"); // up
        FindPathToExit(row, col + 1, "R"); // right
        FindPathToExit(row + 1, col, "D"); // down

        labirynth[row, col] = ' ';
        path.RemoveAt(path.Count - 1);
    }
}