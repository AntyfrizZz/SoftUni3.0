namespace _05KingsGambitExtended
{
    using System;
    using System.Collections.Generic;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var troops = new TroopsRepository();
            var king = new King(Console.ReadLine());

            var guards = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var guarndName in guards)
            {
                var royalGuard = new RoyalGuard(guarndName);
                troops.AddTroop(royalGuard);
                royalGuard.TroopDeath += king.OnTroopDeath;
                royalGuard.TroopDeath += troops.OnTroopDeath;
                king.KingAttacked += royalGuard.OnKingAttack;
            }

            var footmen = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var footmanName in footmen)
            {
                var footman = new Footman(footmanName);
                troops.AddTroop(footman);
                footman.TroopDeath += king.OnTroopDeath;
                footman.TroopDeath += troops.OnTroopDeath;
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
                        var soldierToRemove = troops.GetTroop(parameters[1]);
                        soldierToRemove.RespondToAttack();
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
