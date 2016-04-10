using System;
//Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a matrix holding the numbers from 1 to n*n in the form of square spiral like in the examples below.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class SpiralMatrix
{
    static void Main()
    {
        Console.Title = "Problem 19.** Spiral Matrix";

        System.Console.SetWindowSize(100, 30);
        int n = int.Parse(Console.ReadLine());
        Console.Clear();
        int[,] matrix = new int[n, n];
        int row = 0;
        int col = 0;
        int value = 1;

        if (n > 0 && n < 21)
        {
            while (value <= n * n)
            {
                while (col < matrix.GetLength(0) && matrix[col, row] == 0)
                {
                    matrix[row, col++] = value;
                    value++;
                }
                col--;
                row++;
                while (row < matrix.GetLength(1) && matrix[row, col] == 0)
                {
                    matrix[row++, col] = value;
                    value++;
                }
                row--;
                col--;
                while (col >= 0 && matrix[row, col] == 0)
                {
                    matrix[row, col--] = value;
                    value++;
                }
                col++;
                row--;
                while (row >= 0 && matrix[row, col] == 0)
                {
                    matrix[row--, col] = value;
                    value++;
                }
                col++;
                row++;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j * 5, i * 2);
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("out of range");
        }
    }
}