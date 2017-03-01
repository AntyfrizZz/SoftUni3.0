namespace Animals.Animals
{
    using System;

    public abstract class Animal
    {
        #region Fields

        private string name;
        private int age;
        private string gender;

        #endregion Fields

        //===========================

        #region Constructors

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        #endregion Constructors

        //===========================

        #region Properties

        public virtual string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }

        public virtual int Age
        {
            get { return this.age; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.age = value;
            }
        }

        public virtual string Gender
        {
            get { return this.gender; }
            set
            {
                if (!value.Equals("Male") && !value.Equals("Female"))
                {
                    throw new InvalidOperationException();
                }
                this.gender = value;
            }
        }

        #endregion Properties

        //===========================

        #region Methods

        public abstract void ProduceSount();

        #endregion Methods
    }
}
