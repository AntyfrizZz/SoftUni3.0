using System;
using System.Linq;

class LegoBlocks
{
    static int[,] countContainer; //Store the count of each row for both arrays                                  
    static int sumOfArray = 0; //The sum of array cells, stored in the last row of countContainer

    static void Main()
    {
        var numberOfRows = int.Parse(Console.ReadLine());

        var firstArray = new int[numberOfRows][];
        var secondArray = new int[numberOfRows][];    
            
        countContainer = new int[numberOfRows + 1, 2];

        for (int row = 0; row < numberOfRows; row++)
        {
            var line = Console.ReadLine()
              .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            countContainer[row, 0] = line.Length;
            sumOfArray += line.Length;

            firstArray[row] = line;
        }

        //Setting the count of cells of the first array
        countContainer[numberOfRows, 0] = sumOfArray;

        sumOfArray = 0;

        for (int row = 0; row < numberOfRows; row++)
        {
            var line = Console.ReadLine()
              .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .Reverse()
              .ToArray();

            countContainer[row, 1] = line.Length;
            sumOfArray += line.Length;

            secondArray[row] = line;
        }

        //Setting the count of cells of the second array
        countContainer[numberOfRows, 1] = sumOfArray;

        var numberOfCols = firstArray[0].Length + secondArray[0].Length;

        for (int i = 0; i < numberOfRows; i++)
        {
            if (countContainer[i, 0] + countContainer[i, 1] != numberOfCols)
            {
                Console.WriteLine("The total number of cells is: {0}", countContainer[numberOfRows, 0] + countContainer[numberOfRows, 1]);
                return;
            }
        }

        for (int i = 0; i < numberOfRows; i++)
        {
            Console.WriteLine("[{0}, {1}]", string.Join(", ", firstArray[i]), string.Join(", ", secondArray[i]));
        }        
    }
}
