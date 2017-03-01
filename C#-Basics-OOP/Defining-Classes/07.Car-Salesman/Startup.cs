using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Car
{
    public string model;
    public Engine engine;
    public string weight;
    public string color;

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        this.weight = "n/a";
        this.color = "n/a";
    }
}

public class Engine
{
    public string model;
    public int power;
    public string displacement;
    public string efficiency;

    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
        this.displacement = "n/a";
        this.efficiency = "n/a";
    }
}

public class Startup
{
    static void Main()
    {
        var numberOfEngines = int.Parse(Console.ReadLine());
        var engines = new List<Engine>();
        var cars = new List<Car>();
        var result = new StringBuilder();

        for (int i = 0; i < numberOfEngines; i++)
        {
            var engineInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var engineModel = engineInfo[0];
            var enginePower = int.Parse(engineInfo[1]);

            var currentEngine = new Engine(engineModel, enginePower);

            if (engineInfo.Length > 2)
            {
                if (char.IsDigit(engineInfo[2][0]))
                {
                    currentEngine.displacement = engineInfo[2];
                }
                else
                {
                    currentEngine.efficiency = engineInfo[2];
                }
            }
            if (engineInfo.Length > 3)
            {
                if (char.IsDigit(engineInfo[3][0]))
                {
                    currentEngine.displacement = engineInfo[3];
                }
                else
                {
                    currentEngine.efficiency = engineInfo[3];
                }
            }

            engines.Add(currentEngine);

        }

        var numberOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCars; i++)
        {
            var carInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var carModel = carInfo[0];
            var engineModel = engines
                .First(e => e.model.Equals(carInfo[1]));

            var currentCar = new Car(carModel, engineModel);

            if (carInfo.Length > 2)
            {
                if (char.IsDigit(carInfo[2][0]))
                {
                    currentCar.weight = carInfo[2];
                }
                else
                {
                    currentCar.color = carInfo[2];
                }
            }
            if (carInfo.Length > 3)
            {
                if (char.IsDigit(carInfo[3][0]))
                {
                    currentCar.weight = carInfo[3];
                }
                else
                {
                    currentCar.color = carInfo[3];
                }
            }

            cars.Add(currentCar);
        }

        foreach (var car in cars)
        {
            result.AppendLine($"{car.model}:");
            result.AppendLine($"  {car.engine.model}:");
            result.AppendLine($"    Power: {car.engine.power}");
            result.AppendLine($"    Displacement: {car.engine.displacement}");
            result.AppendLine($"    Efficiency: {car.engine.efficiency}");
            result.AppendLine($"  Weight: {car.weight}");
            result.AppendLine($"  Color: {car.color}");
        }

        Console.Write(result);
    }
}