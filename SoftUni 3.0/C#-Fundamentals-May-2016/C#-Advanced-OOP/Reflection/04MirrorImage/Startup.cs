namespace _04MirrorImage
{
    using System;
    using Contracts;
    using Models;
    using Repositories;

    public class Startup
    {
        public static void Main()
        {

            var casterInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            ICast wizzard = new Wizard(casterInfo[0], int.Parse(casterInfo[1]));
            CasterRepository.AddCaster(wizzard);

            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            while (!input[0].Equals("END"))
            {
                var caster = CasterRepository.GetCaster(int.Parse(input[0]));

                switch (input[1])
                {
                    case "FIREBALL":
                        caster.CastFireball(null, EventArgs.Empty);
                        break;
                    case "REFLECTION":
                        caster.CastReflection(null, EventArgs.Empty);
                        break;
                }

                input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            }

        }
    }
}
