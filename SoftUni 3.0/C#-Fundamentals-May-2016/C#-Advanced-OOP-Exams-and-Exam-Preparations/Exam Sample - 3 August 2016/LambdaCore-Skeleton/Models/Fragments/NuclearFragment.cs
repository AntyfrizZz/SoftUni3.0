namespace LambdaCore_Skeleton.Models.Fragments
{
    using Enumerations;

    public class NuclearFragment : Fragment
    {
        private const FragmentType Type = FragmentType.Nuclear;
        private const int PressureRatio = 2;

        public NuclearFragment(string name, int pressureAffection)
            : base(name, Type, pressureAffection)
        {
        }

        public override int PressureAffection
        {
            get
            {
                return base.PressureAffection;
            }

            protected set
            {
                base.PressureAffection = value * PressureRatio;
            }
        }
    }
}
