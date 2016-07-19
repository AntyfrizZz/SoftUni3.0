using System;
using System.Linq;

class Startup
{
    static void Main()
    {
        var nameArgs = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var gender = Console.ReadLine();

        var pin = Console.ReadLine();

        if (nameArgs.Length != 2 ||
            !char.IsUpper(nameArgs[0][0]) ||
            !char.IsUpper(nameArgs[1][0]))
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }

        if (gender != "male" &&
            gender != "female")
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }

        if (pin.Length != 10)
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }

        if (int.Parse(pin[8].ToString()) % 2 == 0 && gender == "female" ||
            int.Parse(pin[8].ToString()) % 2 == 1 && gender == "male")
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }

        var year = int.Parse(pin.Substring(0, 2));
        var month = int.Parse(pin.Substring(2, 2));
        var day = int.Parse(pin.Substring(4, 2));


        if (month > 40)
        {
            month -= 40;
            year += 2000;
        }
        else if (month > 20)
        {
            month -= 20;
            year += 1800;
        }
        else
        {
            year += 1900;
        }

        var yearString = $"{year}-{month}-{day}";
        DateTime temp;
        if (!DateTime.TryParse(yearString, out temp))
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }

        var multipliers = new int[] { 2, 4, 8, 5, 10, 9, 7, 3, 6 };

        var checksum = 0;

        for (int i = 0; i < multipliers.Length; i++)
        {
            checksum += int.Parse(pin[i].ToString()) * multipliers[i];
        }

        checksum %= 11;

        if (checksum == 10)
        {
            checksum = 0;
        }

        if (checksum != int.Parse(pin[9].ToString()))
        {
            Console.WriteLine("<h2>Incorrect data</h2>");
            return;
        }


        Console.WriteLine($"{{\"name\":\"{nameArgs[0]} {nameArgs[1]}\",\"gender\":\"{gender}\",\"pin\":\"{pin}\"}}");
    }
}