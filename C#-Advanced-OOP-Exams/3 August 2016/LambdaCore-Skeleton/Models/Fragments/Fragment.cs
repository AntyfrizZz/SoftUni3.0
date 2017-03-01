namespace LambdaCore_Skeleton.Models.Fragments
{
    using Contracts.Models;
    using Enumerations;

    public abstract class Fragment : IFragment
    {
        private FragmentType type;

        protected Fragment(string name, FragmentType type, int pressureAffection)
        {
            this.Name = name;
            this.type = type;
            this.PressureAffection = pressureAffection;
        }

        public string Name { get; }

        public virtual int PressureAffection { get; protected set; }
    }
}
