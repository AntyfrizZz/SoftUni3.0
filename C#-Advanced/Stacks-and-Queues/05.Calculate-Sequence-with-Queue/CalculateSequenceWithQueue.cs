using System;
using System.Collections.Generic;

class CalculateSequenceWithQueue
{
    static void Main()
    {
        var startNum = long.Parse(Console.ReadLine());

        var myQueue = new Queue<long>();
        var resultQueue = new Queue<long>();

        myQueue.Enqueue(startNum);
        resultQueue.Enqueue(startNum);

        while (resultQueue.Count < 50)
        {
            var tempNum = myQueue.Dequeue();

            myQueue.Enqueue(tempNum + 1);
            myQueue.Enqueue(2 * tempNum + 1);
            myQueue.Enqueue(tempNum + 2);

            resultQueue.Enqueue(tempNum + 1);
            resultQueue.Enqueue(2 * tempNum + 1);
            resultQueue.Enqueue(tempNum + 2);
        }

        for (int i = 0; i < 50; i++)
        {
            Console.Write(resultQueue.Dequeue() + " ");
        }
    }
}