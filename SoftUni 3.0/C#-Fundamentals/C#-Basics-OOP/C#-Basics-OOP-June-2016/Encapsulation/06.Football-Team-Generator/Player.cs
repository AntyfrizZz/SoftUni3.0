using System;

namespace _06.Football_Team_Generator
{
    public class Player
    {
        #region Fields

        private string name;

        #endregion Fields

        //===========================

        #region Constructors

        public Player(string name, Stat endurance, Stat sprint, Stat dribble, Stat passing, Stat shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        #endregion Constructors

        //===========================

        #region Properties

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public Stat Endurance { get; }

        public Stat Sprint { get; }

        public Stat Dribble { get; }

        public Stat Passing { get; }

        public Stat Shooting { get; }

        public int SkillLevel
        {
            get
            {
                var sumOfStats = this.Endurance.Level + this.Sprint.Level + this.Dribble.Level + this.Passing.Level +
                          this.Shooting.Level;

                return (int)Math.Round(sumOfStats / 5.0);
            }
        }

        #endregion Properties

        //===========================

        #region Methods

        #endregion Methods
    }
}