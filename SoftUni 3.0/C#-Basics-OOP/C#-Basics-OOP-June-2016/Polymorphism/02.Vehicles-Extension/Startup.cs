namespace VehiclesExtension
{
    using System;

    class Startup
    {
        static void Main()
        {
            var carInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var truckInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var busInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            var car = new Car(
                double.Parse(carInfo[1]), 
                double.Parse(carInfo[2]), 
                double.Parse(carInfo[3]));

            var truck = new Truck(
                double.Parse(truckInfo[1]), 
                double.Parse(truckInfo[2]),
                double.Parse(truckInfo[3]));

            var bus = new Bus(
                double.Parse(busInfo[1]),
                double.Parse(busInfo[2]),
                double.Parse(busInfo[3]));

            var numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                var command = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Drive":
                        switch (command[1])
                        {
                            case "Car":
                                car.Drive(double.Parse(command[2]));
                                break;
                            case "Truck":
                                truck.Drive(double.Parse(command[2]));
                                break;
                            case "Bus":
                                bus.Drive(double.Parse(command[2]), true);
                                break;
                        }
                        break;
                    case "Refuel":
                        switch (command[1])
                        {
                            case "Car":
                                car.Refuel(double.Parse(command[2]));
                                break;
                            case "Truck":
                                truck.Refuel(double.Parse(command[2]));
                                break;
                            case "Bus":
                                bus.Refuel(double.Parse(command[2]));
                                break;
                        }
                        break;
                    case "DriveEmpty":
                        bus.Drive(double.Parse(command[2]), false);
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
