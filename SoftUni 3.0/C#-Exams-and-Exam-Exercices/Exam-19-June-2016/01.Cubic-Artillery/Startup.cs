using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Startup
{
    static List<Bunker> bunkers = new List<Bunker>();

    static Bunker currentBunker;
    static Queue<Bunker> nextBunker = new Queue<Bunker>();

    static bool foundBunker;

    static StringBuilder result = new StringBuilder();

    static void Main()
    {
        var totalCapacity = int.Parse(Console.ReadLine());

        var inputLine = Console.ReadLine();

        while (!inputLine.Equals("Bunker Revision"))
        {
            var elements = inputLine.Split();

            foreach (var element in elements)
            {
                if (char.IsLetter(element[0])) //We have a bunker
                {
                    var tempBunker = new Bunker(element, 0, new List<int>());
                    bunkers.Add(tempBunker); //Add it to our list

                    if (currentBunker == null) // This is done to the first bunker. We mark it as current.
                    {
                        currentBunker = tempBunker;
                    }
                    else
                    {
                        nextBunker.Enqueue(tempBunker); //Every other bunker is added in the que
                    }
                }
                else //We have a weapon
                {
                    var currentWeapon = int.Parse(element);

                    if (currentBunker.Sum + currentWeapon <= totalCapacity) //The weapon can fit in the current bunker
                    {
                        currentBunker.Weapons.Add(currentWeapon);
                        currentBunker.Sum += currentWeapon;
                    }
                    else
                    {
                        foreach (var bunker in bunkers) //We are searching bunker, that can fit the weapon
                        {
                            if (bunker.Sum + currentWeapon <= totalCapacity)//We found that bunker
                            {
                                bunker.Weapons.Add(currentWeapon);
                                bunker.Sum += currentWeapon;
                                foundBunker = true; //If this reamins false, we need to check current bunker for fitting the weapon
                                break;
                            }
                        }

                        if (foundBunker)
                        {
                            AddToPrint();
                        }
                        else
                        {
                            if (currentWeapon > totalCapacity) //If the weapon is bigger then the capacity, we dont check for fitting
                            {
                                AddToPrint();
                            }
                            else
                            {
                                currentBunker.Weapons.Add(currentWeapon);
                                currentBunker.Sum += currentWeapon;

                                currentBunker.Weapons.Reverse();

                                for (int i = currentBunker.Weapons.Count - 1; i >= 0; i--)
                                {
                                    currentBunker.Sum -= currentBunker.Weapons[i];
                                    currentBunker.Weapons.RemoveAt(i);

                                    if (currentBunker.Sum <= totalCapacity)
                                    {
                                        break;
                                    }
                                }

                                currentBunker.Weapons.Reverse();

                            }
                        }

                        foundBunker = false;
                    }
                }
            }

            inputLine = Console.ReadLine();
        }

        Console.Write(result);
    }

    private static void AddToPrint()
    {
        var empty = "Empty";

        if (currentBunker.Weapons.Count != 0)
        {
            empty = string.Join(", ", currentBunker.Weapons);
        }

        result.AppendLine($"{currentBunker.Name} -> {empty}");
        currentBunker = nextBunker.Dequeue();
    }
}

public class Bunker
{
    public string Name { get; set; }
    public int Sum { get; set; }
    public List<int> Weapons { get; set; }

    public Bunker(string name, int sum, List<int> weapons)
    {
        this.Name = name;
        this.Sum = sum;
        this.Weapons = weapons;
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, Sum: {this.Sum}, Weapons: {string.Join(", ", this.Weapons)}";
    }
}
