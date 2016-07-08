using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pokemon
{
    public string name;
    public string element;
    public int health;

    public Pokemon(string name, string element, int health)
    {
        this.name = name;
        this.element = element;
        this.health = health;
    }
}

public class Trainer
{
    public string name;
    public int numberOfBadges;
    public List<Pokemon> pokemons;

    public Trainer(string name, List<Pokemon> pokemons)
    {
        this.name = name;
        this.numberOfBadges = 0;
        this.pokemons = pokemons;
    }
}

public class Startup
{
    static void Main()
    {
        var trainers = new List<Trainer>();

        var command = Console.ReadLine();

        while (!command.Equals("Tournament"))
        {
            var ingo = command.Split();

            var trainerName = ingo[0];
            var pokemonName = ingo[1];
            var pokemonElement = ingo[2];
            var pokemonHealth = int.Parse(ingo[3]);

            var currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (!trainers.Any(t => t.name.Equals(trainerName)))
            {
                trainers.Add(new Trainer(trainerName, new List<Pokemon>()));
            }

            var currentTrainer = trainers
                .First(t => t.name.Equals(trainerName));

            currentTrainer.pokemons.Add(currentPokemon);

            command = Console.ReadLine();
        }

        var elements = Console.ReadLine();

        while (!elements.Equals("End"))
        {
            foreach (var trainer in trainers)
            {
                if (trainer.pokemons.Any(p => p.element.Equals(elements)))
                {
                    trainer.numberOfBadges++;
                }
                else
                {
                    for (int i = trainer.pokemons.Count - 1; i >= 0; i--)
                    {
                        trainer.pokemons[i].health -= 10;

                        if (trainer.pokemons[i].health <= 0)
                        {
                            trainer.pokemons.RemoveAt(i);
                        }
                    }
                }
            }

            elements = Console.ReadLine();
        }

        var sortedTrainers = trainers
            .OrderByDescending(t => t.numberOfBadges);

        var resultForPrint = new StringBuilder();

        foreach (var trainer in sortedTrainers)
        {
            resultForPrint.AppendLine($"{trainer.name} {trainer.numberOfBadges} {trainer.pokemons.Count}");
        }

        Console.Write(resultForPrint);
    }
}