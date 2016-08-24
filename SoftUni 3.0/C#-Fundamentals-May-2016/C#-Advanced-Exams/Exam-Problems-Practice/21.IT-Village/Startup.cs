using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Startup
{
    static string[] field = new string[12];
    static List<List<string>> arrField = new List<List<string>>();
    static int coins = 50;
    static int numberOfInns = 0;
    static int numberOfOwnedInns = 0;
    static bool storm = false;
    static int priceRentOfInn = 20;
    static int fieldPossition = 0;



    static void Main()
    {
#if DEBUG
        Console.SetIn(new StreamReader("../../../input.txt"));
#endif
        BuildingTemporaryField();

        var startingCoords = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var row = startingCoords[0] - 1;
        var col = startingCoords[1] - 1;

        SettingField(row, col); //String, and if we roll 3, we will add this 3 to the current index of the string.
        //We always starts at index 0. 
        //If we roll 11, and we add 11 to 5 (for example), we will take the module of 11+5 % 12 == 4, so we will be
        //on the 4th index of that string and so on.

        var moves = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        for (int i = 0; i < moves.Length; i++)
        {
            //Skip 2 if we dont have Wifi
            if (storm)
            {
                i++;
                storm = false;
                continue;
            }

            coins += numberOfOwnedInns * priceRentOfInn;

            fieldPossition = (fieldPossition + moves[i]) % (field.Length);

            switch (field[fieldPossition])
            {
                case "P":
                    coins -= 5;
                    if (coins < 0) //End if we are out of coins
                    {
                        Console.WriteLine("<p>You lost! You ran out of money!<p>");
                        return;
                    }
                    break;
                case "I":
                    if (coins >= 100) //Buy if we can
                    {
                        coins -= 100;
                        numberOfOwnedInns++;

                        if (numberOfOwnedInns == numberOfInns) //If we ount all Inns, end
                        {
                            Console.WriteLine($"<p>You won! You own the village now! You have {coins} coins!<p>");
                            return;
                        }
                    }
                    else
                    {
                        coins -= 10; //Pay for sleep
                        if (coins < 0) //End if we are broke
                        {
                            Console.WriteLine("<p>You lost! You ran out of money!<p>");
                            return;
                        }
                    }
                    break;
                case "F":
                    coins += 20;
                    break;
                case "S":
                    storm = true;
                    break;
                case "V":
                    coins *= 10;
                    break;
                case "N":
                    Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
                    return;
                default:
                    break;

            }
        }

        Console.WriteLine($"<p>You lost! No more moves! You have {coins} coins!<p>");
    }

    private static void SettingField(int row, int col)
    {
        var index = 0;

        while (index < 12)
        {
            field[index] = arrField[row][col];

            if (arrField[row][col] == "I")
            {
                numberOfInns++;
            }

            if (row == 0 && col != 3)
            {
                col++;
            }
            else if (col == 3 && row != 3)
            {
                row++;
            }
            else if (row == 3 && col != 0)
            {
                col--;
            }
            else
            {
                row--;
            }

            index++;
        }
    }

    private static void BuildingTemporaryField()
    {
        var input = Console.ReadLine()
            .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < 4; i++)
        {
            var rowOfField = input[i]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.ToString())
                .ToList();

            arrField.Add(rowOfField);
        }
    }
}