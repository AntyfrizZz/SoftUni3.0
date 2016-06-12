using System;
using System.Security;

class Startup
{
    static void Main()
    {
        var lineLenght = int.Parse(Console.ReadLine());
        var text = Console.ReadLine();
        var linesCount = (text.Length - 1) / lineLenght + 1;

        var board = new char[linesCount, lineLenght];

        FillBoard(lineLenght, text, linesCount, board);

        Falling(lineLenght, linesCount, board);

        Print(lineLenght, linesCount, board);

    }

    private static void Print(int lineLenght, int linesCount, char[,] board)
    {
        Console.Write("<table>");
        for (int row = 0; row < linesCount; row++)
        {
            Console.Write("<tr>");
            for (int col = 0; col < lineLenght; col++)
            {
                Console.Write("<td>{0}</td>", SecurityElement.Escape(board[row, col].ToString()));
            }
            Console.Write("</tr>");
        }
        Console.Write("</table>");
    }

    private static void Falling(int lineLenght, int linesCount, char[,] board)
    {
        for (int col = lineLenght - 1; col >= 0; col--)
        {
            for (int row = linesCount - 2; row >= 0; row--)
            {
                if (row != linesCount - 1)
                {
                    if (board[row, col] != ' ' && board[row + 1, col] == ' ')
                    {
                        for (int i = row; i >= 0; i--)
                        {
                            board[i + 1, col] = board[i, col];
                        }
                        board[0, col] = ' ';
                        row += 2;
                    }
                }
            }
        }
    }

    private static void FillBoard(int lineLenght, string text, int linesCount, char[,] board)
    {
        for (int row = 0; row < linesCount; row++)
        {
            for (int col = 0; col < lineLenght; col++)
            {
                if ((row * lineLenght) + col < text.Length)
                {
                    board[row, col] = text[(row * lineLenght) + col];
                }
                else
                {
                    board[row, col] = ' ';
                }
            }
        }
    }
}