namespace MordorsCrueltyPlan.Foods
{
    class Lembas : Food
    {
        protected new const int Points = 3;

        public override int GetPoints()
        {
            return Points;
        }
    }
}
