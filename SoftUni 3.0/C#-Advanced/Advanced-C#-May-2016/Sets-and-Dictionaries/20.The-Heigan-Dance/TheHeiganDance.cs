using System;
using System.Collections.Generic;

class TheHeiganDance
{
    static int[,] chamber = new int[15, 15];
    static bool[,] cloudArea = new bool[15, 15];
    static Tuple<int, int> player = new Tuple<int, int>(7, 7);
    static double playerHealth = 18500;
    static double heiganHealth = 3000000;
    static bool isHeiganDead = false;
    static bool isPlayerDead = false;
    static string spellName;


    static void Main()
    {
        var playerDamage = double.Parse(Console.ReadLine());

        var isOnCloud = false;

        while (true)
        {
            //Apply damage to Heigan
            heiganHealth -= playerDamage;

            //Check if Heigan is dead
            if (heiganHealth <= 0)
            {
                isHeiganDead = true;
            }

            //Apply damage if player is on cloud
            if (isOnCloud)
            {
                playerHealth -= 3500;

                if (playerHealth <= 0)
                {
                    isPlayerDead = true;
                }

                isOnCloud = false;
            }

            //If Heigan or player are dead, break;
            if (isHeiganDead || isPlayerDead)
            {
                break;
            }            

            //Heigan cast his next spell
            var spellArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);           

            //Check which of the hit cells are in the matrix
            var spellRow = int.Parse(spellArgs[1]);
            var spellMinRow = Math.Max(spellRow - 1, 0);
            var spellMaxRow = Math.Min(spellRow + 1, 14);

            //Check which of the hit cells are in the matrix
            var spellCol = int.Parse(spellArgs[2]);
            var spellMinCol = Math.Max(spellCol - 1, 0);
            var spellMaxCol = Math.Min(spellCol + 1, 14);

            //Aplly the nuke area
            for (int row = spellMinRow; row <= spellMaxRow; row++)
            {
                for (int col = spellMinCol; col <= spellMaxCol; col++)
                {
                    cloudArea[row, col] = true;
                }
            }

            //If player is in nuked area
            if (cloudArea[player.Item1, player.Item2])
            {
                if (spellArgs[0] == "Eruption")
                {
                    spellName = "Eruption";
                }
                else
                {
                    spellName = "Plague Cloud";
                }

                if (spellName == "Eruption")
                {
                    if (!Moved()) //If player cant move, apply dmg from spell
                    {
                        playerHealth -= 6000;

                        if (playerHealth <= 0)
                        {
                            isPlayerDead = true;
                            break;
                        }
                    }

                }
                else
                {
                    if (!Moved()) //If player cant move, apply dmg from spell
                    {
                        playerHealth -= 3500;

                        if (playerHealth <= 0)
                        {
                            isPlayerDead = true;
                            break;
                        }

                        //if we cant move, stay for the next 3500dmg
                        isOnCloud = true;
                    }
                }
            }

            //DeApply the nuke area
            for (int row = spellMinRow; row <= spellMaxRow; row++)
            {
                for (int col = spellMinCol; col <= spellMaxCol; col++)
                {
                    cloudArea[row, col] = false;
                }
            }
        }

        if (isHeiganDead)
        {
            Console.WriteLine("Heigan: Defeated!");
        }
        else
        {
            Console.WriteLine("Heigan: {0:0.00}", heiganHealth);
        }
        if (isPlayerDead)
        {
            Console.WriteLine("Player: Killed by {0}", spellName);
        }
        else
        {
            Console.WriteLine("Player: {0}", playerHealth);
        }

        Console.WriteLine("Final position: {0}, {1}", player.Item1, player.Item2);
    }

    private static bool Moved()
    {
        if (player.Item1 - 1 >= 0 &&
                         !cloudArea[player.Item1 - 1, player.Item2]) //Try to move up
        {
            player = new Tuple<int, int>(player.Item1 - 1, player.Item2);
            return true;
        }
        else if (player.Item2 + 1 <= 14 &&
            !cloudArea[player.Item1, player.Item2 + 1]) //Try to move right
        {
            player = new Tuple<int, int>(player.Item1, player.Item2 + 1);
            return true;
        }
        else if (player.Item1 + 1 <= 14 &&
            !cloudArea[player.Item1 + 1, player.Item2]) //Try to move down
        {
            player = new Tuple<int, int>(player.Item1 + 1, player.Item2);
            return true;
        }
        else if (player.Item2 - 1 >= 0 &&
            !cloudArea[player.Item1, player.Item2 - 1]) //Try to move left
        {
            player = new Tuple<int, int>(player.Item1, player.Item2 - 1);
            return true;
        }

        return false; //If player cant move, return false
    }
}
