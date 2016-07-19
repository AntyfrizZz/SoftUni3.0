namespace MordorsCrueltyPlan.Moods
{
    public class Sad : Mood
    {
        protected const string Mood = "Sad";

        public override string GetMood()
        {
            return Mood;
        }
    }
}
