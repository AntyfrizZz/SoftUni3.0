using System;
using System.Collections.Generic;
using System.Linq;

class SerbianUnleashed
{
    static void Main()
    {
        var result = new Dictionary<string, Dictionary<string, long>>();
        
        var input = Console.ReadLine();


        while (input != "End")
        {
            var inputArgs = input
                 .Split(new char[] { '@' });

            if (inputArgs[0].Length == 0 || inputArgs[1].Length == 0)
            {
                input = Console.ReadLine();
                continue;
            }

            //Extracting name
            var nameArgs = inputArgs[0];

            if (nameArgs[nameArgs.Length - 1] != ' ')
            {
                input = Console.ReadLine();
                continue;
            }

            var nameArray = nameArgs
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var slongerName = string.Empty;

            for (int i = 0; i < nameArray.Length; i++)
            {
                slongerName += nameArray[i] + " ";
            }

            slongerName = slongerName.TrimEnd();

            //Extracting venue
            var venueArgs = inputArgs[1]
                  .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (venueArgs.Length < 3)
            {
                input = Console.ReadLine();
                continue;
            }

            int ticketPrice;
            int ticketSold;

            bool isNumericTicketPrice = int.TryParse(venueArgs[venueArgs.Length - 2], out ticketPrice);
            bool isNumericTicketSold = int.TryParse(venueArgs[venueArgs.Length - 1], out ticketSold);

            if (!isNumericTicketPrice || !isNumericTicketSold)
            {
                input = Console.ReadLine();
                continue;
            }

            var venueName = string.Empty;
            var totalMoney = ticketPrice * ticketSold;

            for (int i = 0; i < venueArgs.Length - 2; i++)
            {
                venueName += venueArgs[i] + " ";
            }

            venueName = venueName.Trim();

            //Adding to the Dict
            if (!result.ContainsKey(venueName))
            {
                var temp = new Dictionary<string, long>();
                temp.Add(slongerName, totalMoney);

                result.Add(venueName, temp);
            }
            else
            {
                if (!result[venueName].ContainsKey(slongerName))
                {
                    result[venueName].Add(slongerName, 0);
                }

                result[venueName][slongerName] += totalMoney;
            }


            //Console.WriteLine("#" + name + "#");
            //Console.WriteLine("#" + venueName + "#");
            //Console.WriteLine("#" + ticketPrice +"#");
            //Console.WriteLine("#" + ticketSold + "#");
            input = Console.ReadLine();
        }

        foreach (var kvp in result)
        {
            Console.WriteLine(kvp.Key);

            var ordered = kvp.Value.OrderByDescending(s => s.Value);

            foreach (var kvpInValue in ordered)
            {
                Console.WriteLine("#  {0} -> {1}", kvpInValue.Key, kvpInValue.Value);
            }

        }
    }
}