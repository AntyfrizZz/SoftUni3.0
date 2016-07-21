namespace _10InfernoInfinity
{
    using System;
    using System.Collections.Generic;
    using Gems;
    using Weapons;

    public class Startup
    {
        public static void Main()
        {
            var weapons = new Dictionary<string, Weapon>();

            var command = Console.ReadLine()
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            while (!command[0].Equals("END"))
            {
                switch (command[0])
                {
                    case "Create":
                        {
                            CreateWeaponCommand(weapons, command);
                        }

                        break;
                    case "Add":
                        {
                            AddGemCommand(weapons, command);
                        }

                        break;
                    case "Remove":
                        {
                            RemoveGemCommand(weapons, command);
                        }

                        break;
                    case "Print":
                        var weaponName = command[1];
                        Console.WriteLine(weapons[weaponName]);
                        break;
                }

                command = Console.ReadLine()
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static void RemoveGemCommand(Dictionary<string, Weapon> weapons, string[] command)
        {
            var weaponName = command[1];
            var index = int.Parse(command[2]);

            weapons[weaponName].RemoveGem(index);
        }

        private static void AddGemCommand(Dictionary<string, Weapon> weapons, string[] command)
        {
            var gemInfo = command[3]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var gemClarity = (GemClarities)Enum.Parse(typeof(GemClarities), gemInfo[0]);
            var gemType = (GemTypes)Enum.Parse(typeof(GemTypes), gemInfo[1]);
            var weaponName = command[1];
            var index = int.Parse(command[2]);
            
            switch (gemType)
            {
                case GemTypes.Amethyst:
                    {
                        Gem gem = new AmethystGem(gemType, gemClarity);
                        weapons[weaponName].AddGem(index, gem);
                    }

                    break;
                case GemTypes.Emerald:
                    {
                        Gem gem = new EmeraldGem(gemType, gemClarity);
                        weapons[weaponName].AddGem(index, gem);
                    }

                    break;
                case GemTypes.Ruby:
                    {
                        Gem gem = new RubyGem(gemType, gemClarity);
                        weapons[weaponName].AddGem(index, gem);
                    }

                    break;
            }
        }

        private static void CreateWeaponCommand(Dictionary<string, Weapon> weapons, string[] command)
        {
            var weaponInfo = command[1]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var weaponRarity = (WeaponRarity)Enum.Parse(typeof(WeaponRarity), weaponInfo[0]);
            var weaponType = (WeaponTypes)Enum.Parse(typeof(WeaponTypes), weaponInfo[1]);
            var weaponName = command[2];

            switch (weaponType)
            {
                case WeaponTypes.Axe:
                    {
                        Weapon weapon = new AxeWeapon(weaponRarity, weaponType, weaponName);
                        weapons.Add(weaponName, weapon);
                        break;
                    }

                case WeaponTypes.Knife:
                    {
                        Weapon weapon = new KnifeWeapon(weaponRarity, weaponType, weaponName);
                        weapons.Add(weaponName, weapon);
                        break;
                    }

                case WeaponTypes.Sword:
                    {
                        Weapon weapon = new SwordWeapon(weaponRarity, weaponType, weaponName);
                        weapons.Add(weaponName, weapon);
                    }

                    break;
            }
        }
    }
}
