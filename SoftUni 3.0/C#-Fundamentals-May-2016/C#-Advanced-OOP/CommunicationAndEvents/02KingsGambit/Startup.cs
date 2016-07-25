namespace _02KingsGambit
{
    using System;
    using System.Collections.Generic;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var troops = new Dictionary<string, Troop>();
            var king = new King(Console.ReadLine());

            var guards = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var guarndName in guards)
            {
                var royalGuard = new RoyalGuard(guarndName);
                troops.Add(guarndName, royalGuard);
                king.KingAttacked += royalGuard.OnKingAttack;
            }

            var footmen = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var footmanName in footmen)
            {
                var footman = new Footman(footmanName);
                troops.Add(footmanName, footman);
                king.KingAttacked += footman.OnKingAttack;
            }
            
            var command = Console.ReadLine();

            while (!command.Equals("End"))
            {
                var parameters = command.Split();

                switch (parameters[0])
                {
                    case "Attack":
                        king.RespondToAttack();
                        break;
                    case "Kill":
                        var soldierToRemove = troops[parameters[1]];
                        king.KingAttacked -= soldierToRemove.OnKingAttack;
                        troops.Remove(parameters[1]);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
