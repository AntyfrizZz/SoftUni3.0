using System;
using System.Collections.Generic;

class Startup
{
    static List<string> map = new List<string>();
    static List<int> wind = new List<int>();
    static int[] jumper = new int[2]; //0 - row, 1 - col

    static void Main()
    {
        ReadInput();

        var row = jumper[0];
        var col = jumper[1];

        FindingLandSpot(ref row, ref col);

        PrintResult(row, col);
    }

    private static void FindingLandSpot(ref int row, ref int col)
    {
        while (map[row][col] != '/' &&
                    map[row][col] != '\\' &&
                    map[row][col] != '_' &&
                    map[row][col] != '~')
        {
            row++;
            col += wind[row];
        }
    }

    private static void PrintResult(int row, int col)
    {
        switch (map[row][col])
        {
            case '/':
                Console.WriteLine("Got smacked on the rock like a dog!");
                break;
            case '\\':
                Console.WriteLine("Got smacked on the rock like a dog!");
                break;
            case '_':
                Console.WriteLine("Landed on the ground like a boss!");
                break;
            case '~':
                Console.WriteLine("Drowned in the water like a cat!");
                break;
            default:
                break;
        }

        Console.WriteLine($"{row} {col}");
    }

    private static void ReadInput()
    {
        var inputLine = Console.ReadLine();

        while (inputLine != "END")
        {
            var right = 0;
            var left = 0;

            for (int i = 0; i < inputLine.Length; i++)
            {
                if (inputLine[i] != '>' &&
                    inputLine[i] != '<' &&
                    inputLine[i] != 'o')
                {
                    continue;
                }
                else
                {
                    if (inputLine[i] == '<')
                    {
                        left++;
                    }
                    else if (inputLine[i] == '>')
                    {
                        right++;
                    }
                    else if (inputLine[i] == 'o')
                    {
                        jumper[0] = map.Count;
                        jumper[1] = i;
                    }
                }
            }

            map.Add(inputLine);
            wind.Add(right - left);

            inputLine = Console.ReadLine();
        }
    }
}