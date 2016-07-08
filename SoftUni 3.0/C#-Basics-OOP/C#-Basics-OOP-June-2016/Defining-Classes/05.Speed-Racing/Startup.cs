using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Startup
{
    static void Main()
    {
        var cars = new List<Car>();
        var resultForPrint = new StringBuilder();

        var numberOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCars; i++)
        {
            var carArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var car = new Car(
                carArgs[0],
                double.Parse(carArgs[1]),
                double.Parse(carArgs[2]));

            cars.Add(car);
        }

        var driveCommand = Console.ReadLine();

        while (!driveCommand.Equals("End"))
        {
            var driveArgs = driveCommand
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Car currentCar = cars
                .First(c => c.Model.Equals(driveArgs[1]));

            currentCar.Drive(
                double.Parse(driveArgs[2]),
                resultForPrint);

            driveCommand = Console.ReadLine();
        }

        foreach (var car in cars)
        {
            resultForPrint.AppendLine($"{car.Model} {car.FuelAmount:F2} {car.Distance}");
        }

        Console.Write(resultForPrint);
    }
}