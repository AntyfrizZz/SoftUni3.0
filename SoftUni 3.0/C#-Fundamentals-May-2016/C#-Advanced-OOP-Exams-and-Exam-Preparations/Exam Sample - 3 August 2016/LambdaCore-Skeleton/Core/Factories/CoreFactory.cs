namespace LambdaCore_Skeleton.Core.Factories
{
    using System;
    using Contracts.Core;
    using Contracts.Models;

    public class CoreFactory : ICoreFactory
    {
        private const string NamespacePath = "LambdaCore_Skeleton.Models.Cores.";
        private const string PostText = "Core";

        public ICore CreateCore(string type, int durability)
        {
            var coreFullName = NamespacePath + type + PostText;

            Type t = Type.GetType(coreFullName);
            object[] coreParameters = new object[] { durability };

            ICore core;
            try
            {
                core = (ICore)Activator.CreateInstance(t, coreParameters);
            }
            catch
            {
                throw new InvalidOperationException("Failed to create Core!");
            }
            
            return core;
        }
    }
}