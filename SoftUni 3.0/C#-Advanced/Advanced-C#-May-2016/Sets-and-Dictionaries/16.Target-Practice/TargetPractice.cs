using System;
using System.Linq;

class TargetPractice
{
    static void Main()
    {
        var dimension = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        var snake = Console.ReadLine();
        var shot = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var numberOfRows = dimension[0];
        var numberOfCols = dimension[1];
        var stairs = new char[numberOfRows, numberOfCols];

        var impactRow = shot[0];
        var impactCol = shot[1];
        var impactRadius = shot[2];

        FillMatrix(snake, stairs);

        FireAShot(stairs, impactRow, impactCol, impactRadius);

        DropCharacters(stairs);

        PrintMatrix(stairs, numberOfRows, numberOfCols);
    }

    private static void FillMatrix(string fillText, char[,] arrayForFill)
    {
        int fillMatrixCounter = 0;
        int snakeIndexCounter = 0;

        for (int i = arrayForFill.GetLength(0) - 1; i >= 0; i--)
        {
            fillMatrixCounter++;

            if (fillMatrixCounter % 2 == 1)
            {
                for (int j = arrayForFill.GetLength(1) - 1; j >= 0; j--)
                {
                    arrayForFill[i, j] = fillText[snakeIndexCounter % fillText.Length];
                    snakeIndexCounter++;
                }
            }
            else
            {
                for (int j = 0; j < arrayForFill.GetLength(1); j++)
                {
                    arrayForFill[i, j] = fillText[snakeIndexCounter % fillText.Length];
                    snakeIndexCounter++;
                }
            }
        }
    }

    private static void FireAShot(char[,] arrayForChange, int shotRow, int shotCol, int shotRadius)
    {
        for (int i = 0; i < arrayForChange.GetLength(0); i++)
        {
            for (int j = 0; j < arrayForChange.GetLength(1); j++)
            {
                if (IsInsideCircle(i, j, shotRow, shotCol, shotRadius))
                {
                    arrayForChange[i, j] = ' ';
                }
            }
        }
    }

    private static bool IsInsideCircle(int rowForCheck, int colForCheck, int shotRow, int shotCol, int shotRadius)
    {
        int deltaRow = rowForCheck - shotRow;
        int deltaCol = colForCheck - shotCol;

        bool isInCircle = deltaRow * deltaRow + deltaCol * deltaCol <= shotRadius * shotRadius;

        return isInCircle;
    }

    private static void DropCharacters(char[,] arrayForChange)
    {
        for (int col = arrayForChange.GetLength(1) - 1; col >= 0; col--)
        {
            for (int row = arrayForChange.GetLength(0) - 2; row >= 0; row--)
            {
                if (row != arrayForChange.GetLength(0) - 1)
                {
                    if (arrayForChange[row, col] != ' ' && arrayForChange[row + 1, col] == ' ')
                    {
                        for (int i = row; i >= 0; i--)
                        {
                            arrayForChange[i + 1, col] = arrayForChange[i, col];
                        }
                        arrayForChange[0, col] = ' ';
                        row += 2;
                    }
                }
            }
        }
    }

    private static void PrintMatrix(char[,] arrayForPrint, int arrayRows, int arrayCols)
    {
        for (int i = 0; i < arrayRows; i++)
        {
            for (int j = 0; j < arrayCols; j++)
            {
                Console.Write(arrayForPrint[i, j]);
            }
            Console.WriteLine();
        }
    }
}
