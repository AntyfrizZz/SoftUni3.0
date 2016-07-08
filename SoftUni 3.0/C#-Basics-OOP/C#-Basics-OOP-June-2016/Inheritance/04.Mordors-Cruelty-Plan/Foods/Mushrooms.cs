namespace MordorsCrueltyPlan.Foods
{
    class Mushrooms : Food
    {
        protected new const int Points = -10;

        public override int GetPoints()
        {
            return Points;
        }
    }
}
