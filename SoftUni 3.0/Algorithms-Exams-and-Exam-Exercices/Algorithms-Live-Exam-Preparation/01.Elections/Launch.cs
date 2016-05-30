using System;
using System.Linq;
using System.Numerics;

class Launch
{
    static void Main()
    {
        int seats = int.Parse(Console.ReadLine());
        int numberOfParties = int.Parse(Console.ReadLine());       

        int[] parties = new int[numberOfParties];

        for (int i = 0; i < numberOfParties; i++)
        {
            parties[i] = int.Parse(Console.ReadLine());
        }

        var possibleSeats = new BigInteger[parties.Sum() + 1];

        possibleSeats[0] = 1;

        for (int i = 0; i < numberOfParties; i++)
        {
            for (int j = possibleSeats.Length - 1; j >= parties[i]; j--)
            {
                possibleSeats[j] += possibleSeats[j - parties[i]];
            }
        }

        BigInteger result = 0;

        for (int i = seats; i < possibleSeats.Length; i++)
        {
            if (possibleSeats[i] != 0)
            {
                result += possibleSeats[i];
            }
        }

        Console.WriteLine(result);
    }
}