using System;

namespace _06.Football_Team_Generator
{
    public class Stat
    {
        #region Fields
        private const int LevelMinValue = 0;
        private const int LevelMaxValue = 100;

        private int level;

        #endregion Fields

        //===========================

        #region Constructors

        public Stat(string name, int level)
        {
            this.Name = name;
            this.Level = level;
        }

        #endregion Constructors

        //===========================

        #region Properties

        public string Name { get; }

        public int Level
        {
            get { return this.level; }
            set
            {
                if (value < LevelMinValue || value > LevelMaxValue)
                {
                    throw new ArgumentException($"{this.Name} should be between {LevelMinValue} and {LevelMaxValue}.");
                }

                this.level = value;
            }
        }

        #endregion Properties

        //===========================

        #region Methods

        #endregion Methods
    }
}
