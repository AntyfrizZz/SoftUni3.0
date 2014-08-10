using System;

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/7.%20CSharp-Advanced-Topics-Homework.docx

class MatrixOfPalindromes
{
    static void Main()
    {
        A:
        int height = int.Parse(Console.ReadLine());
        int width = int.Parse(Console.ReadLine());

        string[,] matrix = new string[height, width];

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                matrix[row, col] = "" + (char)('a' + row) + (char)('a' + col + row) + (char)('a' + row);
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }

        goto A;
    }
}