namespace MordorsCrueltyPlan.Foods
{
    public class Cram : Food
    {
        protected new const int Points = 2;

        public override int GetPoints()
        {
            return Points;
        }
    }
}
