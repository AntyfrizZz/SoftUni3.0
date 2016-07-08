using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

class Startup
{
    static List<char[]> room = new List<char[]>();
    static HashSet<char> commands = new HashSet<char>() { '<', '>', '^', 'v' };

    static void Main()
    {
        ReadInput();

        SearchingForCommand();

        Print();
    }

    private static void Print()
    {
        var result = new StringBuilder();
        for (int row = 0; row < room.Count; row++)
        {
            result.Append("<p>");
            for (int col = 0; col < room[row].Length; col++)
            {
                result.Append(SecurityElement.Escape(room[row][col].ToString()));
            }
            result.AppendLine("</p>");
        }

        Console.Write(result);
    }

    private static void SearchingForCommand()
    {
        for (int row = 0; row < room.Count; row++)
        {
            for (int col = 0; col < room[row].Length; col++)
            {
                if (commands.Contains(room[row][col]))
                {
                    switch (room[row][col])
                    {
                        case '>':
                            MoveRight(row, col);
                            break;
                        case 'v':
                            MoveDown(row, col);
                            break;
                        case '<':
                            MoveLeft(row, col);
                            break;
                        case '^':
                            MoveUp(row, col);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    private static void ReadInput()
    {
        var inputLine = Console.ReadLine();

        while (inputLine != "END")
        {
            room.Add(inputLine.ToCharArray());

            inputLine = Console.ReadLine();
        }
    }

    private static void MoveUp(int row, int col)
    {
        for (int i = row - 1; i >= 0; i--)
        {
            if (!commands.Contains(room[i][col]))
            {
                room[i][col] = ' ';
            }
            else
            {
                return;
            }
        }
    }

    private static void MoveLeft(int row, int col)
    {
        for (int i = col - 1; i >= 0; i--)
        {
            if (!commands.Contains(room[row][i]))
            {
                room[row][i] = ' ';
            }
            else
            {
                return;
            }
        }
    }

    private static void MoveDown(int row, int col)
    {
        for (int i = row + 1; i < room.Count; i++)
        {
            if (!commands.Contains(room[i][col]))
            {
                room[i][col] = ' ';
            }
            else
            {
                return;
            }
        }
    }

    private static void MoveRight(int row, int col)
    {
        for (int i = col + 1; i < room[row].Length; i++)
        {
            if (!commands.Contains(room[row][i]))
            {
                room[row][i] = ' ';
            }
            else
            {
                return;
            }
        }
    }
}