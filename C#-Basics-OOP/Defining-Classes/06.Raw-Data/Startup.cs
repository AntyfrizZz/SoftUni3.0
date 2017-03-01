using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Car
{
    public string model;
    public Engine engine;
    public Cargo cargo;
    public Tire[] tires;

    public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = tires;
    }
}

public class Engine
{
    public int speed;
    public int power;

    public Engine(int speed, int power)
    {
        this.speed = speed;
        this.power = power;
    }
}

public class Cargo
{
    public int weight;
    public string type;

    public Cargo(int weight, string type)
    {
        this.weight = weight;
        this.type = type;
    }
}

public class Tire
{
    public double pressure;
    public int age;

    public Tire(double pressure, int age)
    {
        this.pressure = pressure;
        this.age = age;
    }
}

public class Startup
{
    static void Main()
    {
        var cars = new List<Car>();
        var result = new StringBuilder();

        var numberOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCars; i++)
        {
            var carArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var carModel = carArgs[0];

            var engineSpeed = int.Parse(carArgs[1]);
            var enginePower = int.Parse(carArgs[2]);

            var cargoWeight = int.Parse(carArgs[3]);
            var cargoTipe = carArgs[4];

            var firstTirePressure = double.Parse(carArgs[5]);
            var firstTireAge = int.Parse(carArgs[6]);
            var secondTirePressure = double.Parse(carArgs[7]);
            var secondTireAge = int.Parse(carArgs[8]);
            var thirdTirePressure = double.Parse(carArgs[9]);
            var thirdTireAge = int.Parse(carArgs[10]);
            var fourthTirePressure = double.Parse(carArgs[11]);
            var fourthTireAge = int.Parse(carArgs[12]);

            var engine = new Engine(engineSpeed, enginePower);
            var cargo = new Cargo(cargoWeight, cargoTipe);
            var firstTire = new Tire(firstTirePressure, firstTireAge);
            var secondTire = new Tire(secondTirePressure, secondTireAge);
            var thirdTire = new Tire(thirdTirePressure, thirdTireAge);
            var fourthTire = new Tire(fourthTirePressure, fourthTireAge);
            var tires = new Tire[]
            {
                firstTire,
                secondTire,
                thirdTire,
                fourthTire
            };

            var currentCar = new Car(
                carModel,
                engine,
                cargo,
                tires);

            cars.Add(currentCar);
        }

        var command = Console.ReadLine();

        if (command.Equals("fragile"))
        {
            var fragileCars = cars
                .Where(c => c.cargo.type.Equals("fragile") &&
                c.tires.Any(t => t.pressure < 1));

            foreach (var fragileCar in fragileCars)
            {
                result.AppendLine($"{fragileCar.model}");
            }
        }
        else
        {
            var flamable = cars
                .Where(c => c.cargo.type.Equals("flamable"))
                .Where(c => c.engine.power > 250);

            foreach (var fragileCar in flamable)
            {
                result.AppendLine($"{fragileCar.model}");
            }
        }

        Console.Write(result);
    }
}