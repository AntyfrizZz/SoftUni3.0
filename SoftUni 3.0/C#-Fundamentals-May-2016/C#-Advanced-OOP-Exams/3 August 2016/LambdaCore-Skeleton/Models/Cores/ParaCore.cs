namespace LambdaCore_Skeleton.Models.Cores
{
    using Enumerations;

    public class ParaCore : Core
    {
        private const CoreType Type = CoreType.Para;
        private const int DurabilityRatio = 3;

        public ParaCore(int maxDurability)
            : base(Type, maxDurability)
        {
        }

        protected override int MaxDurability
        {
            get
            {
                return base.MaxDurability;
            }

            set
            {
                base.MaxDurability = value / DurabilityRatio;
            }
        }
    }
}
