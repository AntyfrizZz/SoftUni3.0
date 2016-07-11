namespace SystemSplit
{
    using System;
    using IO;

    class Startup
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();

            while (true)
            {
                try
                {
                    var commandInterpreter = new CommandInterpreter();
                    commandInterpreter.InterpredCommand(inputLine);
                }
                catch (Exception)
                {
  
                }

                if (inputLine.Equals("System Split"))
                {
                    break;
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}
