using System.Text;

namespace Animals.Animals
{
    using System;

    class Tomcat : Cat
    {
        #region Fields

        #endregion Fields

        //===========================

        #region Constructors

        public Tomcat(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        #endregion Constructors

        //===========================

        #region Properties

        public override string Gender
        {
            get { return base.Gender; }
            set
            {
                if (!value.Equals("Male"))
                {
                    throw new InvalidOperationException();
                }

                base.Gender = value;
            }
        }

        #endregion Properties

        //===========================

        #region Methods

        public override void ProduceSount()
        {
            Console.WriteLine("Give me one million b***h");
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Tomcat");
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");

            return result.ToString();
        }

        #endregion Methods
    }
}
