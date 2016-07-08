using System;
using System.Collections.Generic;
using System.Numerics;

class HandsOfCards
{
    static void Main()
    {
        string currentPerson = Console.ReadLine();

        var hands = new Dictionary<string, HashSet<string>>();

        while (currentPerson != "JOKER")
        {
            var personArgs = currentPerson
                .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            var personName = personArgs[0];
            var personCurrentHand = personArgs[1].
                Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!hands.ContainsKey(personName))
            {
                hands.Add(personName, new HashSet<string>());
            }

            foreach (var hand in personCurrentHand)
            {
                hands[personName].Add(hand);
            }

            currentPerson = Console.ReadLine();
        }

        foreach (var kvp in hands)
        {
            int handValue = 0;

            foreach (var hand in kvp.Value)
            {
                handValue += CalculateHandValue(hand);
            }
            Console.WriteLine("{0}: {1}", kvp.Key, handValue);
        }
    }

    private static int CalculateHandValue(string hand)
    {
        int power = 0;
        int type = 0;

        if (hand.Length == 3)
        {
            power = 10;
        }
        else
        {
            switch (hand[0])
            {
                case 'J':
                    power = 11;
                    break;
                case 'Q':
                    power = 12;
                    break;
                case 'K':
                    power = 13;
                    break;
                case 'A':
                    power = 14;
                    break;
                default:
                    power = int.Parse(hand[0].ToString());
                    break;
            }
        }
        


        switch (hand[hand.Length - 1])
        {
            case 'S':
                type = 4;
                break;
            case 'H':
                type = 3;
                break;
            case 'D':
                type = 2;
                break;
            case 'C':
                type = 1;
                break;
        }

        return power * type;
    }
}