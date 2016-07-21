namespace _09TrafficLights
{
    using System;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var lights = new Light[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                var light = (Lights) Enum.Parse(typeof(Lights), input[i], true);

                lights[i] = new Light(light);
            }
            var numberOfUpdates = int.Parse(Console.ReadLine());

            var result = new StringBuilder();
            for (int i = 0; i < numberOfUpdates; i++)
            {

                foreach (var light in lights)
                {
                    light.Update();
                    result.Append(light)
                        .Append(" ");
                }

                result.AppendLine();
            }

            Console.Write(result);
        }
    }
}
