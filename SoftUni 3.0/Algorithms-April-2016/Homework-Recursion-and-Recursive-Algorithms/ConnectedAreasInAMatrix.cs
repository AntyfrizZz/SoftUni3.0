using System;
using System.Collections.Generic;
using System.Linq;

class ConnectedAreasInAMatrix
{
    //static string[,] labirynth =
    //{
    //    {" ", " ", " ", "*", " ", " ", " ", "*", " "},
    //    {" ", " ", " ", "*", " ", " ", " ", "*", " "},
    //    {" ", " ", " ", "*", " ", " ", " ", "*", " "},
    //    {" ", " ", " ", " ", "*", " ", "*", " ", " "},
    //};

    //static string[,] labirynth =
    //{
    //    {"*", " ", " ", "*", " ", " ", " ", "*", " ", " "},
    //    {"*", " ", " ", "*", " ", " ", " ", "*", " ", " "},
    //    {"*", " ", " ", "*", "*", "*", "*", "*", " ", " "},
    //    {"*", " ", " ", "*", " ", " ", " ", "*", " ", " "},
    //    {"*", " ", " ", "*", " ", " ", " ", "*", " ", " "},
    //};

    //static string[,] labirynth =
    //{
    //    {" ", " ", "*", " ", "*", "*", "*", "*", " ", " "},
    //    {" ", " ", "*", " ", "*", " ", "*", " ", " ", " "},
    //    {" ", " ", "*", " ", " ", " ", "*", " ", " ", " "},
    //    {" ", " ", "*", " ", " ", " ", "*", " ", " ", " "},
    //    {" ", " ", "*", " ", " ", " ", "*", " ", " ", " "},
    //};

    //static string[,] labirynth =
    //{
    //    {" ", " ", "*", " ", "*", "*", "*", "*", " ", " "},
    //    {" ", " ", "*", " ", "*", " ", "*", " ", " ", " "},
    //    {" ", " ", "*", " ", " ", " ", "*", " ", " ", " "},
    //    {" ", " ", "*", " ", " ", " ", "*", " ", " ", " "},
    //    {" ", " ", "*", " ", "*", "*", "*", " ", " ", " "},
    //};

    static string[,] labirynth =
    {
        {" ", "*", "*", " ", "*", "*", "*", "*", " ", " "},
        {" ", "*", "*", " ", "*", " ", "*", " ", " ", " "},
        {" ", "*", "*", " ", "*", " ", "*", " ", " ", " "},
        {" ", "*", "*", " ", "*", " ", "*", " ", " ", " "},
        {" ", "*", "*", " ", "*", "*", "*", "*", " ", " "},
    };

    static int areaCounter = 0;
    static int areaSize = 0;
    static int areaRowIndex = 0;
    static int areaColIndex = 0;
    static Dictionary<int, int> posSizeDict = new Dictionary<int, int>();
    static Dictionary<int, string> posCoordsDict = new Dictionary<int, string>();

    static void Main()
    {
        for (int rows = 0; rows < labirynth.GetLength(0); rows++)
        {
            for (int cols = 0; cols < labirynth.GetLength(1); cols++)
            {
                if (labirynth[rows, cols] == " ")
                {
                    areaCounter++;
                    MarkArea(rows, cols, areaCounter);
                    areaRowIndex = rows;
                    areaColIndex = cols;

                    posSizeDict.Add(areaCounter, areaSize);
                    posCoordsDict.Add(areaCounter, areaRowIndex.ToString() + " " + areaColIndex.ToString());

                    areaRowIndex = -1;
                    areaColIndex = -1;
                    areaSize = 0;
                }
            }
        }

        Console.WriteLine("The numbers here doesent show the order of the result.");
        for (int rows = 0; rows < labirynth.GetLength(0); rows++)
        {
            for (int cols = 0; cols < labirynth.GetLength(1); cols++)
            {
                Console.Write(labirynth[rows, cols]);

            }
            Console.WriteLine();
        }

        var ordered = posSizeDict.OrderByDescending(key => key.Value).ThenBy(value => value.Key);



        Console.WriteLine();

        Console.WriteLine("Total areas found: {0}", areaCounter);

        int tempCounter = 1;

        foreach (var item in ordered)
        {
            Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", tempCounter, posCoordsDict[item.Key].Split()[0], posCoordsDict[item.Key].Split()[1], item.Value);
            tempCounter++;
        }

    }

    private static void MarkArea(int row, int col, int areaCounter)
    {
        if (!InRange(row, col))
        {
            // We are out of the labyrinth -> can't find a path
            return;
        }
        if (labirynth[row, col] != " ")
        {
            return;
        }

        labirynth[row, col] = areaCounter.ToString();
        areaSize++;

        MarkArea(row, col + 1, areaCounter);
        MarkArea(row + 1, col, areaCounter);
        MarkArea(row, col - 1, areaCounter);
        MarkArea(row - 1, col, areaCounter);
    }

    static bool InRange(int row, int col)
    {
        bool rowInRange = row >= 0 && row < labirynth.GetLength(0);
        bool colInRange = col >= 0 && col < labirynth.GetLength(1);
        return rowInRange && colInRange;
    }
}
