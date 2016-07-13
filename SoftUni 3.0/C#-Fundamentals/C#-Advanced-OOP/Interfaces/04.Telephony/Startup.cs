namespace _04.Telephony
{
    using System;

    class Startup
    {
        static void Main()
        {
            var phoneNumbers = Console.ReadLine()
                .Split(new[] { ' ' });
            var websites = Console.ReadLine()
                .Split(new[] { ' ' });

            var smartphone = new Smartphone();

            foreach (var phoneNumber in phoneNumbers)
            {
                Console.WriteLine(smartphone.CallPhone(phoneNumber));
            }

            foreach (var website in websites)
            {
                Console.WriteLine(smartphone.BrowseWebsite(website));
            }
        }
    }
}
