namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string NamespacePath = "_03BarracksFactory.Models.Units.";

        public IUnit CreateUnit(string unitType)
        {
            Type t = Type.GetType(NamespacePath + unitType);
            IUnit unit = (IUnit)Activator.CreateInstance(t);
            return unit;
        }
    }
}