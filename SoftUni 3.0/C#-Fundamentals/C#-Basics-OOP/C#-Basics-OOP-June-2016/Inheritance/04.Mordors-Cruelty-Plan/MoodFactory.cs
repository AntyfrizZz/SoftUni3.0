namespace MordorsCrueltyPlan
{
    using MordorsCrueltyPlan.Moods;

    class MoodFactory
    {
        public static Mood GetMood(int mood)
        {
            if (mood < -5)
            {
                return new Angry();
            }
            else if (mood < 0)
            {
                return new Sad();
            }
            else if (mood < 15)
            {
                return new Happy();
            }
            else
            {
                return new JavaScript();
            }
        }
    }
}
