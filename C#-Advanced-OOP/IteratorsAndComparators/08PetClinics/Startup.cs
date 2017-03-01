namespace _08PetClinics
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var commandInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (commandInfo[0])
                    {
                        case "Create":
                            switch (commandInfo[1])
                            {
                                case "Pet":
                                    var pet = new Pet(
                                        commandInfo[2],
                                        int.Parse(commandInfo[3]),
                                        commandInfo[4]);
                                    break;
                                case "Clinic":
                                    var clinic = new Clinic(
                                        commandInfo[2],
                                        int.Parse(commandInfo[3]));
                                    break;
                            }
                            break;
                        case "Add":
                            Console.WriteLine(AddToClinic(commandInfo[1], commandInfo[2]));
                            break;
                        case "Release":
                            Console.WriteLine(ReleasePetFromClinic(commandInfo[1]));
                            break;
                        case "HasEmptyRooms":
                            Console.WriteLine(HasEmptyRooms(commandInfo[1]));
                            break;
                        case "Print":
                            if (commandInfo.Length == 3)
                            {
                                Console.WriteLine(PrintClinicsRoom(commandInfo[1], int.Parse(commandInfo[2])));
                            }
                            else if (commandInfo.Length == 2)
                            {
                                Console.WriteLine(PrintClinic(commandInfo[1]));
                            }
                            else
                            {
                                throw new InvalidOperationException("Something gone wrong with Print pet or clinic input!");
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static string PrintClinicsRoom(string clinic, int room)
        {
            if (!Clinic.clinics.ContainsKey(clinic))
            {
                throw new InvalidOperationException("There is no clinic with that name");
            }

            var currentClinic = Clinic.clinics[clinic];

            return currentClinic.PrintRoom(room);
        }

        private static string PrintClinic(string clinic)
        {
            if (!Clinic.clinics.ContainsKey(clinic))
            {
                throw new InvalidOperationException("There is no clinic with that name");
            }

            var currentClinic = Clinic.clinics[clinic];

            return currentClinic.ToString();
        }

        private static string HasEmptyRooms(string clinic)
        {
            if (!Clinic.clinics.ContainsKey(clinic))
            {
                throw new InvalidOperationException("There is no clinic with that name");
            }

            var currentClinic = Clinic.clinics[clinic];

            return currentClinic.HasEmptyRooms() ? "True" : "False";
        }

        private static string ReleasePetFromClinic(string clinic)
        {
            if (!Clinic.clinics.ContainsKey(clinic))
            {
                throw new InvalidOperationException("There is no clinic with that name");
            }

            var currentClinic = Clinic.clinics[clinic];

            return currentClinic.ReleasePet() ? "True" : "False";
        }

        private static string AddToClinic(string pet, string clinic)
        {
            if (!Clinic.clinics.ContainsKey(clinic))
            {
                throw new InvalidOperationException("There is no clinic with that name");
            }

            if (!Pet.pets.ContainsKey(pet))
            {
                throw new InvalidOperationException("There is no pet with that name");
            }

            var currentClinic = Clinic.clinics[clinic];
            var currentPet = Pet.pets[pet];

            return currentClinic.AddPet(currentPet) ? "True" : "False";
        }
    }
}
