using System;
using System.Collections.Generic;
using System.Linq;

class RadioactiveMutantVampireBunnies
{
    static char[,] lair;
    static Queue<Tuple<int, int>> marginBunnies = new Queue<Tuple<int, int>>();
    static HashSet<Tuple<int, int>> allBunnies = new HashSet<Tuple<int, int>>();
    static Tuple<int, int> player;

    static void Main()
    {
        var arrayArgs = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        lair = new char[arrayArgs[0], arrayArgs[1]];

        

        for (int i = 0; i < arrayArgs[0]; i++)
        {
            var line = Console.ReadLine();

            for (int j = 0; j < line.Length; j++)
            {
                lair[i, j] = line[j];

                if (line[j] == 'B')
                {
                    marginBunnies.Enqueue(new Tuple<int, int>(i, j));
                    allBunnies.Add(new Tuple<int, int>(i, j));
                }

                if (line[j] == 'P')
                {
                    player = new Tuple<int, int>(i, j);
                }
            }
        }

        var playerMovement = Console.ReadLine();
        int playerMoveCounter = 0;

        while (true)
        {
            int bunniesCount = marginBunnies.Count;

            MuchoBunnies(bunniesCount);

            var playerMove = playerMovement[playerMoveCounter];
            Tuple<int, int> nextPlayerCoords = new Tuple<int, int>(-1, -1);

            switch (playerMove)
            {
                case 'U':
                    nextPlayerCoords = new Tuple<int, int>(player.Item1 - 1, player.Item2);
                    break;
                case 'D':
                    nextPlayerCoords = new Tuple<int, int>(player.Item1 + 1, player.Item2);
                    break;
                case 'L':
                    nextPlayerCoords = new Tuple<int, int>(player.Item1, player.Item2 - 1);
                    break;
                case 'R':
                    nextPlayerCoords = new Tuple<int, int>(player.Item1, player.Item2 + 1);
                    break;
                default:
                    break;
            }

            if (lair[player.Item1, player.Item2] != 'B')
            {
                lair[player.Item1, player.Item2] = '.';
            }

            if (InBoundries(nextPlayerCoords))
            {
                PrintArray(lair);
                Console.WriteLine("won: {0} {1}", player.Item1, player.Item2);
                return;
            }
            if (EncounterBunnie(nextPlayerCoords))
            {
                PrintArray(lair);
                Console.WriteLine("dead: {0} {1}", nextPlayerCoords.Item1, nextPlayerCoords.Item2);
                return;
            }

            lair[nextPlayerCoords.Item1, nextPlayerCoords.Item2] = 'P';
            
            
            player = nextPlayerCoords;
            playerMoveCounter++;

            //Console.WriteLine();
            //Console.WriteLine(playerMoveCounter);
            //PrintArray(lair);
            //Console.WriteLine();
        }
    }

    private static bool EncounterBunnie(Tuple<int, int> player)
    {
        if (allBunnies.Contains(player))
        {
            return true;
        }

        return false;
    }

    private static void PrintArray(char[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j]);
            }
            Console.WriteLine();
        }
    }

    private static bool InBoundries(Tuple<int, int> nextPlayerCoords)
    {
        if (nextPlayerCoords.Item1 < 0 || //Out of boundries
            nextPlayerCoords.Item2 < 0 || //Out of boundries
            nextPlayerCoords.Item1 >= lair.GetLength(0) || //Out of boundries
            nextPlayerCoords.Item2 >= lair.GetLength(1)) //Out of boundries

        {
            return true;
        }

        return false;
    }

    private static void MuchoBunnies(int bunniesCount)
    {
        for (int i = 0; i < bunniesCount; i++)
        {
            var mutantingBunnie = marginBunnies.Dequeue();
            var mutantingBunnieRow = mutantingBunnie.Item1;
            var mutantingBunnieCol = mutantingBunnie.Item2;

            var upperBunnie = new Tuple<int, int>(mutantingBunnieRow - 1, mutantingBunnieCol);
            var lowerBunnie = new Tuple<int, int>(mutantingBunnieRow + 1, mutantingBunnieCol);
            var lefterBunnie = new Tuple<int, int>(mutantingBunnieRow, mutantingBunnieCol - 1);
            var righterBunnie = new Tuple<int, int>(mutantingBunnieRow, mutantingBunnieCol + 1);

            AddBunnie(upperBunnie);
            AddBunnie(lowerBunnie);
            AddBunnie(lefterBunnie);
            AddBunnie(righterBunnie);
        }
    }

    private static void AddBunnie(Tuple<int, int> bunnie)
    {
        if (bunnie.Item1 < 0 || //Out of boundries
            bunnie.Item2 < 0 || //Out of boundries
            bunnie.Item1 >= lair.GetLength(0) || //Out of boundries
            bunnie.Item2 >= lair.GetLength(1) || //Out of boundries
            allBunnies.Contains(bunnie)) //Already in
        {
            return;
        }

        marginBunnies.Enqueue(bunnie);
        allBunnies.Add(bunnie);
        lair[bunnie.Item1, bunnie.Item2] = 'B';
    }
}