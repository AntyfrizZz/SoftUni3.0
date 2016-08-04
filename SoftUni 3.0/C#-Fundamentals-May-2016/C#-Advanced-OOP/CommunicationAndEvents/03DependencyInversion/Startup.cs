namespace _03DependencyInversion
{
    using System;
    using Contracts;
    using Models;
    using Strategies;

    public class Startup
    {
        public static void Main()
        {
            var calculator = new PrimitiveCalculator();

            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            while (!input[0].Equals("End"))
            {
                if (input[0].Equals("mode"))
                {
                    switch (input[1][0])
                    {
                        case '/':
                            IStrategy division = new DivisionStrategy();
                            calculator.ChangeStrategy(division);
                            break;
                        case '*':
                            IStrategy multiply = new MultiplicationStrategy();
                            calculator.ChangeStrategy(multiply);
                            break;
                        case '+':
                            IStrategy addition = new AdditionStrategy();
                            calculator.ChangeStrategy(addition);
                            break;
                        case '-':
                            IStrategy subtraction = new SubtractionStrategy();
                            calculator.ChangeStrategy(subtraction);
                            break;
                        default:
                            throw new InvalidOperationException("Invalid operator!");
                    }
                }
                else
                {
                    int firstOperand = int.Parse(input[0]);
                    int secondOperand = int.Parse(input[1]);
                    int result = calculator.PerformCalculation(firstOperand, secondOperand);
                    Console.WriteLine(result);
                }

                input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
