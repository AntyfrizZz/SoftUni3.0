using System;
using System.Collections.Generic;

class FixEmails
{
    static void Main()
    {
        var nameEmails = new Dictionary<string, string>();

        var name = Console.ReadLine();

        if (name == "stop")
        {
            return;
        }

        var email = Console.ReadLine();

        while (true)
        {
            if (
                !(email[email.Length - 2] == 'u' && email[email.Length - 1] == 's' ||
                email[email.Length - 2] == 'u' && email[email.Length - 1] == 'S' ||
                email[email.Length - 2] == 'U' && email[email.Length - 1] == 's' ||
                email[email.Length - 2] == 'U' && email[email.Length - 1] == 'S')
                )
            {
                nameEmails[name] = email;

            }

            name = Console.ReadLine();

            if (name == "stop")
            {
                break;
            }

            email = Console.ReadLine();
        }

        foreach (var kvp in nameEmails)
        {
            Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value);
        }
    }
}
