namespace AirConditionerTester.IO
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Commands;
    using Tester;

    public class Injector : IInjector
    {
        private IAirConditionerTester tester;

        public Injector(IAirConditionerTester tester)
        {
            this.tester = tester;
        }

        public Injector()
            : this(new AirConditionerTester())
        {
        }

        public void Inject(IExecutable command)
        {
            var type = command.GetType();

            var injectFields = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => Attribute.IsDefined(f, typeof(InjectAttribute)));
            var injecterFields = typeof(Injector)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var injectField in injectFields)
            {
                var injectValue = injecterFields
                    .First(x => x.FieldType == injectField.FieldType)
                    .GetValue(this);

                injectField.SetValue(command, injectValue);
            }
        }
    }
}
