using System;

class BinomialCoefficients
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        var firstRow = new int[n + 1];
        firstRow[0] = 1;
        var secodRow = new int[n + 1];
        secodRow[0] = 1;
        secodRow[1] = 1;

        for (int row = 2; row <= n; row++)
        {
            if (row % 2 == 0)
            {
                for (int j = 1; j < row; j++)
                {
                    firstRow[j] = secodRow[j - 1] + secodRow[j];
                }
                firstRow[row] = 1;
            }
            else
            {
                for (int j = 1; j < row; j++)
                {
                    secodRow[j] = firstRow[j - 1] + firstRow[j];
                }
                secodRow[row] = 1;
            }
        }

        if (n % 2 == 0)
        {
            Console.WriteLine(firstRow[k]);
        }
        else
        {
            Console.WriteLine(secodRow[k]);
        }
    }
}