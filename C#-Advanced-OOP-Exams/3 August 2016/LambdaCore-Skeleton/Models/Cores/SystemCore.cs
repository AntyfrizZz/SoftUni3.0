namespace LambdaCore_Skeleton.Models.Cores
{
    using Enumerations;

    public class SystemCore : Core
    {
        private const CoreType Type = CoreType.System;

        public SystemCore(int maxDurability) 
            : base(Type, maxDurability)
        {
        }
    }
}
