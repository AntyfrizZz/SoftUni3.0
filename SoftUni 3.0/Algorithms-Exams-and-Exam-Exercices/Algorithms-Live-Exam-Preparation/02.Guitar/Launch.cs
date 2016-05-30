using System;
using System.Linq;

class Launch
{
    static bool foundVolume = false;
    static bool[,] volumeSteps;
    static int rowToChange = 0;

    static void Main()
    {
        var volumes = Console.ReadLine()
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int initialVolume = int.Parse(Console.ReadLine());

        int maxVolume = int.Parse(Console.ReadLine());

        volumeSteps = new bool[2, maxVolume + 1];

        FirstVolume(volumes, initialVolume, maxVolume); //Setting first volume

        if (!foundVolume) //Terminate program if there is no volume after the first song
        {
            Console.WriteLine("-1");
            return;
        }

        int volumeLevel = 1; //Volume before every song

        while (volumeLevel != volumes.Length)
        {
            foundVolume = false;

            if (rowToChange == 0)
            {
                SettingVolume(volumes, maxVolume, volumeLevel, 0, 1);

                if (!foundVolume) //Return if there is no volume
                {
                    Console.WriteLine("-1");
                    return;
                }

                rowToChange = 1; //Switch the rows of volumeSteps
            }
            else
            {
                SettingVolume(volumes, maxVolume, volumeLevel, 1, 0);

                if (!foundVolume) //Return if there is no volume
                {
                    Console.WriteLine("-1");
                    return;
                }

                rowToChange = 0; //Switch the rows of volumeSteps
            }

            volumeLevel++; //Next song
        }

        PrintResult(volumes, maxVolume);
    }

    private static void PrintResult(int[] volumes, int maxVolume)
    {
        if (volumes.Length % 2 == 0)
        {
            PrintMaxPossibleVolume(maxVolume, 1);
        }
        else
        {
            PrintMaxPossibleVolume(maxVolume, 0);
        }
    }

    private static void PrintMaxPossibleVolume(int maxVolume, int rowIndex)
    {
        for (int i = maxVolume; i >= 0; i--)
        {
            if (volumeSteps[rowIndex, i] == true)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }

    private static void SettingVolume(int[] volumes, int maxVolume, int volumeLevel, int prevRow, int currRow)
    {
        for (int i = 0; i <= maxVolume; i++)
        {
            if (volumeSteps[prevRow, i] == true)
            {
                if (i + volumes[volumeLevel] <= maxVolume)
                {
                    volumeSteps[currRow, i + volumes[volumeLevel]] = true;
                    foundVolume = true;
                }
                if (i - volumes[volumeLevel] >= 0)
                {
                    volumeSteps[currRow, i - volumes[volumeLevel]] = true;
                    foundVolume = true;
                }

                volumeSteps[prevRow, i] = false;
            }
        }
    }

    private static void FirstVolume(int[] volumes, int initialVolume, int maxVolume)
    {
        int volumeUp = initialVolume + volumes[0];
        int volumeDown = initialVolume - volumes[0];

        if (volumeUp <= maxVolume)
        {
            volumeSteps[0, volumeUp] = true;
            foundVolume = true;
        }
        if (volumeDown >= 0)
        {
            volumeSteps[0, volumeDown] = true;
            foundVolume = true;
        }
    }
}