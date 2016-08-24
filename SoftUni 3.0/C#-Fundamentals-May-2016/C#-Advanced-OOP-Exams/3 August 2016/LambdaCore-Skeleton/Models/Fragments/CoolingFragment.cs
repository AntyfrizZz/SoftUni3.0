namespace LambdaCore_Skeleton.Models.Fragments
{
    using Enumerations;

    public class CoolingFragment : Fragment
    {
        private const FragmentType Type = FragmentType.Cooling;
        private const int PressureRatio = -3;

        public CoolingFragment(string name, int pressureAffection) 
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
