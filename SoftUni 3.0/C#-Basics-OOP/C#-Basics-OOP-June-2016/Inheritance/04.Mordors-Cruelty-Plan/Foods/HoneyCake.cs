namespace MordorsCrueltyPlan.Foods
{
    class HoneyCake : Food
    {
        protected new const int Points = 5;

        public override int GetPoints()
        {
            return Points;
        }
    }
}
