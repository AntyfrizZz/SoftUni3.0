using System;
using System.Collections.Generic;
using System.Linq;

class TowerOfHanoi
{
    private static int stepsTaken;
    private static Stack<int> sourceRod;
    private static readonly Stack<int> destinationRod = new Stack<int>();
    private static readonly Stack<int> spareRod = new Stack<int>();

    public static void Main()
    {
        Console.Write("Number of disks: ");
        int numberOfDisks = int.Parse(Console.ReadLine());

        sourceRod = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
        PrintRods();
        MoveDisks(numberOfDisks, sourceRod, destinationRod, spareRod);
    }

    private static void MoveDisks(int bottomDisc, Stack<int> source, Stack<int> destination, Stack<int> spare)
    {
        if (bottomDisc == 1)
        {
            stepsTaken++;
            destination.Push(source.Pop());
            Console.WriteLine($"Step #{stepsTaken}: Moved disk {bottomDisc}");
            PrintRods();
        }
        else
        {
            MoveDisks(bottomDisc - 1, source, spare, destination);
            stepsTaken++;
            destination.Push(source.Pop());
            Console.WriteLine($"Step #{stepsTaken}: Moved disk {bottomDisc}");
            PrintRods();
            MoveDisks(bottomDisc - 1, spare, destination, source);

        }
    }

    private static void PrintRods()
    {
        Console.WriteLine("Source: {0}", string.Join(", ", sourceRod.Reverse()));
        Console.WriteLine("Destination: {0}", string.Join(", ", destinationRod.Reverse()));
        Console.WriteLine("Spare: {0}", string.Join(", ", spareRod.Reverse()));
        Console.WriteLine();
    }
}
