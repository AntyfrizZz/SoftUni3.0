namespace _02BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var blackBox = typeof(BlackBoxInt);

            var blackBoxConstructor = blackBox
                .GetConstructor(
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    null,
                    Type.EmptyTypes,
                    null);

            var blackBoxInstance = (BlackBoxInt)blackBoxConstructor.Invoke(new object[] {});
            var field = blackBox.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

            var input = Console.ReadLine()
                .Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);

            while (!input[0].Equals("END"))
            {
                var operation = input[0];
                var number = int.Parse(input[1]);

                var method = blackBox
                    .GetMethod(
                        operation,
                        BindingFlags.Instance | BindingFlags.NonPublic);

                method.Invoke(blackBoxInstance, new object[] { number });

                Console.WriteLine(field.GetValue(blackBoxInstance));

                input = Console.ReadLine()
                    .Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
