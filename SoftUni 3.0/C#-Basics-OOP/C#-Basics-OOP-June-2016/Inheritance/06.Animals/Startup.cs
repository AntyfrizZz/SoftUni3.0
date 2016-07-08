namespace Animals
{
    using System;
    using Animals;

    public class Startup
    {
        static void Main()
        {

            var animal = Console.ReadLine();

            try
            {
                while (!animal.Equals("Beast!"))
                {
                    var animalInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var animalName = animalInfo[0];
                    var animalAge = int.Parse(animalInfo[1]);
                    var animalGender = string.Empty;

                    if (!animalName.Equals("Tomcat") && !animalName.Equals("Kitten"))
                    {
                        animalGender = animalInfo[2];
                    }


                    switch (animal)
                    {
                        case "Dog":
                            var dog = new Dog(animalName, animalAge, animalGender);
                            Console.Write(dog);
                            dog.ProduceSount();
                            break;
                        case "Frog":
                            var frog = new Frog(animalName, animalAge, animalGender);
                            Console.Write(frog);
                            frog.ProduceSount();
                            break;
                        case "Cat":
                            var cat = new Cat(animalName, animalAge, animalGender);
                            Console.Write(cat);
                            cat.ProduceSount();
                            break;
                        case "Kitten":
                            var kitten = new Kitten(animalName, animalAge, "Female");
                            Console.Write(kitten);
                            kitten.ProduceSount();
                            break;
                        case "Tomcat":
                            var tomcat = new Tomcat(animalName, animalAge, "Male");
                            Console.Write(tomcat);
                            tomcat.ProduceSount();
                            break;
                        case "Animal":
                            Console.WriteLine("Not implemented!");
                            break;
                        default:
                            break;
                    }

                    animal = Console.ReadLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!");
            }

        }
    }
}
