namespace AirConditionerTester.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class AliasAttribute : Attribute
    {
        public AliasAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public override bool Equals(object obj)
        {
            return this.Name.Equals(obj);
        }
    }
}
