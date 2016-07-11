namespace MordorsCrueltyPlan.Foods
{
    class Junk : Food
    {
        protected new const int Points = -1;

        public override int GetPoints()
        {
            return Points;
        }
    }
}
