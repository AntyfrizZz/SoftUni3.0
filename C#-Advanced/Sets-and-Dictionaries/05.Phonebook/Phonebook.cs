using System;
using System.Collections.Generic;

class Phonebook
{
    static void Main()
    {
        var contact = Console.ReadLine();

        var phonebook = new Dictionary<string, string>();

        while (contact != "search")
        {
            var contactArgs = contact
                .Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            phonebook[contactArgs[0]] = contactArgs[1];

            contact = Console.ReadLine();
        }

        var searched = Console.ReadLine();

        while (searched != "stop")
        {
            if (phonebook.ContainsKey(searched))
            {
                Console.WriteLine("{0} -> {1}", searched, phonebook[searched]);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", searched);
            }

            searched = Console.ReadLine();
        }
    }
}