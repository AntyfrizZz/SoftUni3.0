using System;

class Startup
{
    static int row = 0;
    static int col = 0;
    static string direction = "right";
    static char[,] matrix;

    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var text = Console.ReadLine();
        matrix = new char[n, n];
        var maxRotations = n * n;

        FillingMatrix(text, maxRotations);

        var result = ResultString();

        bool isPalindrome = Palindrome(result);

        if (isPalindrome)
        {
            Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>", result);
        }
        else
        {
            Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>", result);
        }


    }

    private static void FillingMatrix(string text, int maxRotations)
    {
        for (int i = 0; i < maxRotations; i++)
        {
            ChangingDirection();

            //Setting the char
            if (i < text.Length)
            {
                matrix[row, col] = text[i];
            }
            else
            {
                matrix[row, col] = ' ';
            }

            ChangingRowCol();
        }
    }

    private static bool Palindrome(string result)
    {
        var tempString = string.Empty;

        for (int i = 0; i < result.Length; i++)
        {
            if (char.IsLetter(result[i]))
            {
                tempString += result[i];
            }
        }

        int min = 0;
        int max = tempString.Length - 1;
        while (true)
        {
            if (min > max)
            {
                return true;
            }
            char a = tempString[min];
            char b = tempString[max];
            if (char.ToLower(a) != char.ToLower(b))
            {
                return false;
            }
            min++;
            max--;
        }
    }

    private static string ResultString()
    {
        var whiteString = string.Empty;
        var blackString = string.Empty;

        for (int r = 0; r < matrix.GetLength(0); r++)
        {
            bool white;
            if (r % 2 == 0)
            {
                white = true;
            }
            else
            {
                white = false;
            }
            for (int c = 0; c < matrix.GetLength(0); c++)
            {
                switch (white)
                {
                    case true:
                        whiteString += matrix[r, c];
                        white = !white;
                        break;
                    case false:
                        blackString += matrix[r, c];
                        white = !white;
                        break;
                }
            }
        }

        return whiteString + blackString;
    }

    private static void ChangingRowCol()
    {
        switch (direction)
        {
            case "right":
                col++;
                break;
            case "down":
                row++;
                break;
            case "left":
                col--;
                break;
            case "up":
                row--;
                break;
        }
    }

    private static void ChangingDirection()
    {
        switch (direction)
        {
            case "right":
                if (col > matrix.GetLength(1) - 1 || matrix[row, col] != '\0')
                {
                    direction = "down";
                    col--;
                    row++;
                }
                break;
            case "down":
                if (row > matrix.GetLength(0) - 1 || matrix[row, col] != '\0')
                {
                    direction = "left";
                    row--;
                    col--;
                }
                break;
            case "left":
                if (col < 0 || matrix[row, col] != '\0')
                {
                    direction = "up";
                    col++;
                    row--;
                }
                break;
            case "up":
                if (row < 0 || matrix[row, col] != '\0')
                {
                    direction = "right";
                    row++;
                    col++;
                }
                break;
        }
    }
}