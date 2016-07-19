using System;
using System.Collections.Generic;
using _06.Football_Team_Generator;

class Startup
{
    static Dictionary<string, FootballTeam> footballTeams = new Dictionary<string, FootballTeam>();

    static void Main()
    {
        var input = Console.ReadLine().Split(';');


        while (!input[0].Equals("END"))
        {
            try
            {
                switch (input[0])
                {
                    case "Team":
                        AddTeam(input[1]);
                        break;
                    case "Add":
                        AddPlayer(
                            input[1],
                            input[2],
                            int.Parse(input[3]),
                            int.Parse(input[4]),
                            int.Parse(input[5]),
                            int.Parse(input[6]),
                            int.Parse(input[7])
                            );
                        break;
                    case "Remove":
                        RemovePlayer(input[1], input[2]);
                        break;
                    case "Rating":
                        PrintRating(input[1]);
                        break;
                }
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }

            input = Console.ReadLine().Split(';');

        }
    }

    private static void PrintRating(string teamName)
    {
        if (!footballTeams.ContainsKey(teamName))
        {
            throw new InvalidOperationException($"Team {teamName} does not exist.");
            
        }

        Console.WriteLine(footballTeams[teamName]);
    }

    private static void RemovePlayer(string teamName, string playerName)
    {
        if (!footballTeams.ContainsKey(teamName))
        {
            throw new InvalidOperationException($"Team {teamName} does not exist.");
        }

        footballTeams[teamName].RemovePlayer(playerName);
    }

    private static void AddPlayer(string teamName, string playerName, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        if (!footballTeams.ContainsKey(teamName))
        {
            throw new InvalidOperationException($"Team {teamName} does not exist.");
        }

        var player = new Player(
            playerName,
            new Stat("Endurance", endurance),
            new Stat("Sprint", sprint),
            new Stat("Dribble", dribble),
            new Stat("Passing", passing),
            new Stat("Shooting", shooting)
            );

        footballTeams[teamName].AddPlayer(player);
    }

    private static void AddTeam(string teamName)
    {
        var team = new FootballTeam(teamName);

        footballTeams.Add(teamName, team);
    }
}