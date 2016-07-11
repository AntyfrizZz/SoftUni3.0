namespace MordorsCrueltyPlan.Moods
{
    public class Happy : Mood
    {
        protected const string Mood = "Happy";

        public override string GetMood()
        {
            return Mood;
        }
    }
}
