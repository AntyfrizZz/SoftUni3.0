using System;
using System.Collections.Generic;
using System.Globalization;

public class Launch
{
    static Dictionary<string, List<Tuple<string, double>>> cities = new Dictionary<string, List<Tuple<string, double>>>();
    static Dictionary<string, int> townsIndex = new Dictionary<string, int>();

    static Dictionary<string, List<Tuple<string, DateTime>>> cars = new Dictionary<string, List<Tuple<string, DateTime>>>();
    static SortedSet<string> speededCars = new SortedSet<string>();

    public static void Main(string[] args)
    {      
        ReadDistancec();

        double[,] minDistances = BuildGraph();        

        ReadCars(minDistances);

        foreach (var speededCar in speededCars)
        {
            Console.WriteLine(speededCar);
        }
    }

    private static void ReadCars(double[,] minDistances)
    {
        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] inputArgs = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string town = inputArgs[0];
            string licenseNumber = inputArgs[1];
            DateTime time = DateTime.Parse(inputArgs[2]);

            if (!cars.ContainsKey(licenseNumber))
            {
                cars.Add(licenseNumber, new List<Tuple<string, DateTime>>());
                cars[licenseNumber].Add(new Tuple<string, DateTime>(town, time));
                continue;
            }

            foreach (var record in cars[licenseNumber])
            {
                string recordTown = record.Item1;
                double duration = Math.Abs((time - record.Item2).TotalHours);

                if (!double.IsPositiveInfinity(minDistances[townsIndex[town], townsIndex[recordTown]]) &&
                    minDistances[townsIndex[town], townsIndex[recordTown]] > duration)
                {
                    speededCars.Add(licenseNumber);
                }
            }

            cars[licenseNumber].Add(new Tuple<string, DateTime>(town, time));

            input = Console.ReadLine();
        }
    }

    public static void floydWarshall(double[,] d)
    {
        for (int k = 0; k < d.GetLength(0); k++)
        {
            for (int i = 0; i < d.GetLength(0); i++)
            {
                for (int j = 0; j < d.GetLength(0); j++)
                {
                    if (d[i, j] > d[i, k] + d[k, j])
                    {
                        d[i, j] = d[i, k] + d[k, j];
                    }

                }
            }
        }
    }

    private static double[,] BuildGraph()
    {
        double[,] minDistances = new double[cities.Count, cities.Count];

        for (int row = 0; row < minDistances.GetLength(0); row++)
        {
            for (int col = 0; col < minDistances.GetLength(1); col++)
            {
                if (row == col)
                {
                    continue;
                }

                minDistances[row, col] = double.PositiveInfinity;
            }
        }

        foreach (var city in cities)
        {
            int startIndex = townsIndex[city.Key];
            foreach (var connection in city.Value)
            {
                int endIndex = townsIndex[connection.Item1];
                minDistances[startIndex, endIndex] = connection.Item2;
            }
        }

        floydWarshall(minDistances);

        return minDistances;
    }

    private static void ReadDistancec()
    {
        int index = 0;
        Console.ReadLine();

        string input = Console.ReadLine();

        while (input != "Records:")
        {
            string[] inputArgs = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string startCity = inputArgs[0];
            string endCity = inputArgs[1];

            double distanceBetweenCities = double.Parse(inputArgs[2]);
            double speed = double.Parse(inputArgs[3]);
            double timeNeeded = distanceBetweenCities / speed;

            if (!cities.ContainsKey(startCity))
            {
                cities.Add(startCity, new List<Tuple<string, double>>());
                townsIndex.Add(startCity, index);
                index++;
            }
            if (!cities.ContainsKey(endCity))
            {
                cities.Add(endCity, new List<Tuple<string, double>>());
                townsIndex.Add(endCity, index);
                index++;
            }
            cities[startCity].Add(new Tuple<string, double>(endCity, timeNeeded));
            cities[endCity].Add(new Tuple<string, double>(startCity, timeNeeded));


            input = Console.ReadLine();
        }
    }      
}