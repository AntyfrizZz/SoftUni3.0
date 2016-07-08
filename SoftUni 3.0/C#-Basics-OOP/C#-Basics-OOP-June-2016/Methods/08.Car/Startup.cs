using System;
using System.Linq;
using System.Text;

public class Car
{
    private decimal speed;
    private decimal fuel;
    private decimal fuelEconomy;
    private decimal distance;
    private decimal time;

    public decimal Speed => this.speed;
    public decimal Fuel => this.fuel;
    public decimal FuelEconomy => this.fuelEconomy;
    public decimal Distance => this.distance;
    public decimal Time => this.time;

    public Car(decimal speed, decimal fuel, decimal fuelEconomy)
    {
        this.speed = speed;
        this.fuel = fuel;
        this.fuelEconomy = fuelEconomy;
        this.distance = 0;
        this.time = 0;
    }

    public void Travel(decimal distance)
    {
        if ((distance / 100) * this.fuelEconomy <= this.fuel)
        {
            this.distance += distance;
            this.fuel -= (distance / 100.0m) * fuelEconomy;
            this.time += distance / this.speed;
        }
        else
        {
            this.distance += (this.fuel / this.fuelEconomy) * 100;
            this.fuel = 0;
            this.time += this.distance / this.speed;
        }
    }

    public void Refuel(decimal amount)
    {
        this.fuel += amount;
    }
}

class Startup
{
    static void Main()
    {
        var carInfo = Console.ReadLine()
          .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
          .Select(decimal.Parse)
          .ToArray();

        var carSpeed = carInfo[0];
        var carFuel = carInfo[1];
        var carFuelEconomy = carInfo[2];

        var car = new Car(carSpeed, carFuel, carFuelEconomy);

        var command = Console.ReadLine();
        var result = new StringBuilder();

        while (!command.Equals("END"))
        {
            switch (command.Split()[0])
            {
                case "Travel":
                    car.Travel(decimal.Parse(command.Split()[1]));
                    break;
                case "Refuel":
                    car.Refuel(decimal.Parse(command.Split()[1]));
                    break;
                case "Distance":
                    result.AppendLine($"Total distance: {car.Distance:F1} kilometers");
                    break;
                case "Time":
                    var hours = (int)car.Time;
                    var minutes = (3 * (car.Time - hours) / 5) * 100;
                    result.AppendLine($"Total time: {hours} hours and {(int) minutes} minutes");
                    break;
                case "Fuel":
                    result.AppendLine($"Fuel left: {car.Fuel:F1} liters");
                    break;
            }


            command = Console.ReadLine();
        }

        Console.Write(result);

    }
}