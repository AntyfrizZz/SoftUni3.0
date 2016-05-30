using System;

class Launch
{
    static void Main()
    {
        int numberOfTowns = int.Parse(Console.ReadLine());

        //On first line we have the population of the towns.
        //On second - best increasing seq in which the town is involved.
        //On third - best decr seq in which the town is involved.
        int[,] help = new int[3, numberOfTowns];

        //Use this to check if the current town is with higher pop from the best till now. If it is, there is no need for cycle.
        int bestIncrSeqIndex = 0;
        int bestDecrSeqIndex = numberOfTowns - 1;

        //This is our result. Add 1 in the end, cause the town on the top of the seq is not included here.
        int bestSum = 0;
        

        for (int i = 0; i < numberOfTowns; i++)
        {
            //Filling first line. 
            //Parallel we can fill and the secend.
            help[0, i] = int.Parse(Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                        
            //Skipping cyclen if possible
            if (help[0, i] > help[0, bestIncrSeqIndex])
            {
                help[1, i] = help[1, bestIncrSeqIndex] + 1;

                bestIncrSeqIndex = i;
            }
            else
            {
                for (int j = 0; j < i; j++)
                {
                    //Searching for the best seq
                    if (help[0, i] > help[0, j] &&
                        help[1, i] <= help[1, j])
                    {
                        help[1, i] = help[1, j] + 1;
                    }

                    //Updating best index if needed.
                    if (help[1, i] > help[1, bestIncrSeqIndex])
                    {
                        bestIncrSeqIndex = i;
                    }
                }
            }            
        }

        //Filling and second row
        for (int i = numberOfTowns - 1; i >= 0; i--)
        {
            //Skipping cyclen if possible
            if (help[0, i] > help[0, bestDecrSeqIndex])
            {
                help[2, i] = help[2, bestDecrSeqIndex] + 1;

                bestDecrSeqIndex = i;
            }
            else
            {
                for (int j = numberOfTowns - 1; j > i; j--)
                {
                    //Searching for the best seq
                    if (help[0, i] > help[0, j] &&
                        help[2, i] <= help[2, j])
                    {
                        help[2, i] = help[2, j] + 1;
                    }

                    //Updating best index if needed.
                    if (help[2, i] > help[2, bestDecrSeqIndex])
                    {
                        bestDecrSeqIndex = i;
                    }
                }
            }

            //Searching for the best sum of decr and incr seq
            if (bestSum < help[1, i] + help[2, i])
            {
                bestSum = help[1, i] + help[2, i];
            }
        }


        Console.WriteLine(bestSum + 1);


        //for (int i = 0; i < help.GetLength(0); i++)
        //{
        //    for (int j = 0; j < help.GetLength(1); j++)
        //    {
        //        Console.Write(help[i, j] + " ");
        //    }
        //    Console.WriteLine();
        //}    
    }
}