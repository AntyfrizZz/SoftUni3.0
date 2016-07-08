using System;
using System.Collections.Generic;

class Startup
{
    static List<string> board = new List<string>();
    static List<string> result = new List<string>();

    static void Main()
    {
        var rotate = int.Parse(Console.ReadLine().
            Split('(')[1]
            .Split(')')[0]) % 360;

        int longestRow = 0;

        string input = Console.ReadLine();

        ReadInput(ref longestRow, ref input);

        FillRowsToLongest(longestRow);        

        if (rotate == 0 || rotate == 360)
        {
            Console.WriteLine(string.Join(("\n"), board));
        }
        else
        {
            if (rotate >= 90)
            {
                result = NintyDegree(longestRow, board.Count, board);
            }
            if (rotate >= 180)
            {
                result = NintyDegree(board.Count, longestRow, result);
            }
            if (rotate >= 270)
            {
                result = NintyDegree(longestRow, board.Count, result);
            }

            Console.WriteLine(string.Join(("\n"), result));
        }

    }

    private static void FillRowsToLongest(int longestRow)
    {
        for (int i = 0; i < board.Count; i++)
        {
            while (board[i].Length < longestRow)
            {
                board[i] += " ";
            }
        }
    }

    private static void ReadInput(ref int longestRow, ref string input)
    {
        for (int row = 0; input != "END"; row++)
        {
            board.Add(input);

            if (longestRow < input.Length)
            {
                longestRow = input.Length;
            }

            input = Console.ReadLine();
        }
    }

    static List<string> NintyDegree(int outerLoopEnd, int innerLoopStart, List<string> board)
    {
        List<string> result = new List<string>();

        for (int i = 0; i < outerLoopEnd; i++)
        {
            string temp = "";
            for (int j = innerLoopStart - 1; j >= 0; j--)
            {
                string temp2 = board[j];
                temp += temp2[i];
            }

            result.Add(temp);
        }

        return result;
    }
}
