using System;
using System.Collections.Generic;
using System.Linq;

class TruckTour
{
    static void Main()
    {
        var numberOfStantions = int.Parse(Console.ReadLine());

        var stations = new Queue<Tuple<int, int, int>>();
        
        for (int i = 0; i < numberOfStantions; i++)
        {
            var stationParams = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stationFuelCapacity = stationParams[0];
            var distanceToNextStation = stationParams[1];

            stations.Enqueue(new Tuple<int, int, int>(
                i, stationFuelCapacity, distanceToNextStation));
        }

        var visitedStations = 0;
        var fuel = 0;

        while (true)
        {
            var currentStation = stations.Dequeue();
            stations.Enqueue(currentStation);

            int currentStationFuel = currentStation.Item2;
            int distanceToNext = currentStation.Item3;

            fuel += currentStationFuel;
            fuel -= distanceToNext;

            if (fuel < 0)
            {
                fuel = 0;
                visitedStations = 0;
                continue;
            }
                        
            visitedStations++;

            if (visitedStations == numberOfStantions)
            {
                Console.WriteLine(stations.Dequeue().Item1);
                break;
            }
        }
    }
}