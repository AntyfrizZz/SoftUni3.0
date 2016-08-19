namespace AirConditionerTester.Tester
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Models;
    using Models.AirConditioners;
    using Strategies;

    public class AirConditionerTester : IAirConditionerTester
    {
        private readonly Dictionary<Type, IAirConditionerTestStrategy> strategyHolder;

        public AirConditionerTester()
        {
            this.strategyHolder = new Dictionary<Type, IAirConditionerTestStrategy>();
            this.AddStrategies();
        }

        public IReport TestAirConditioner(IAirConditioner airConditioner)
        {
            var type = airConditioner.GetType();
            var strategy = this.strategyHolder[type];

            return strategy.Test(airConditioner);
        }

        private void AddStrategies()
        {
            var assemblyTypes = Assembly.GetExecutingAssembly().DefinedTypes as TypeInfo[]
                ?? Assembly.GetExecutingAssembly().DefinedTypes.ToArray();

            var strategies = assemblyTypes
                .Where(x => typeof(IAirConditionerTestStrategy).IsAssignableFrom(x) &&
                    x != typeof(IAirConditionerTestStrategy) &&
                    !x.IsAbstract &&
                    !x.IsInterface);

            var airConditionerModels = assemblyTypes
                .Where(x => typeof(IAirConditioner).IsAssignableFrom(x) &&
                    x != typeof(IAirConditioner) &&
                    !x.IsAbstract);

            foreach (var model in airConditionerModels)
            {
                string strategyName = model.Name + "TestStrategy";
                var strategy = strategies.FirstOrDefault(x => x.Name == strategyName);

                if (strategy != null)
                {
                    var stratInstance = (IAirConditionerTestStrategy)Activator.CreateInstance(strategy);
                    this.strategyHolder.Add(model, stratInstance);
                }
            }
        }
    }
}
