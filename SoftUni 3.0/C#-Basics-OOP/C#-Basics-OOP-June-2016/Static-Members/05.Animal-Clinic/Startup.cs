using System;
using System.Collections.Generic;
using System.Text;

public class Animal
{
    public string name;
    public string breed;

    public Animal(string name, string breed)
    {
        this.name = name;
        this.breed = breed;
    }
}

public class AnimalClinic
{
    public static int patientId;
    public static List<Animal> healedAnimals;
    public static List<Animal> rehabilitedAnimals;

    static AnimalClinic()
    {
        healedAnimals = new List<Animal>();
        rehabilitedAnimals = new List<Animal>();
    }
}

class Startup
{
    static StringBuilder result = new StringBuilder();
    static void Main()
    {
        var input = Console.ReadLine();

        while (!input.Equals("End"))
        {
            var animalInfo = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var animalName = animalInfo[0];
            var animalBreed = animalInfo[1];
            var procedure = animalInfo[2];

            var animal = new Animal(animalName, animalBreed);

            if (procedure.Equals("heal"))
            {
                AnimalClinic.healedAnimals.Add(animal);
                result.AppendLine($"Patient {++AnimalClinic.patientId}: [{animal.name} ({animal.breed})] has been healed!");

            }
            else
            {
                AnimalClinic.rehabilitedAnimals.Add(animal);
                result.AppendLine($"Patient {++AnimalClinic.patientId}: [{animal.name} ({animal.breed})] has been rehabilitated!");
            }

            input = Console.ReadLine();
        }

        result.AppendLine($"Total healed animals: {AnimalClinic.healedAnimals.Count}");
        result.AppendLine($"Total rehabilitated animals: {AnimalClinic.rehabilitedAnimals.Count}");

        var command = Console.ReadLine();

        if (command.Equals("heal"))
        {
            foreach (var animal in AnimalClinic.healedAnimals)
            {
                result.AppendLine($"{animal.name} {animal.breed}");
            }
        }
        else
        {
            foreach (var animal in AnimalClinic.rehabilitedAnimals)
            {
                result.AppendLine($"{animal.name} {animal.breed}");
            }
        }

        Console.Write(result);
    }
}