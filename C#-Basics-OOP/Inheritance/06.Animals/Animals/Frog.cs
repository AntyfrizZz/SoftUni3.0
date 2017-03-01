using System.Text;

namespace Animals.Animals
{
    using System;

    class Frog : Animal
    {
        #region Fields

        #endregion Fields

        //===========================

        #region Constructors

        public Frog(string name, int age, string gender) : base(name, age, gender)
        {
        }

        #endregion Constructors

        //===========================

        #region Properties

        #endregion Properties

        //===========================

        #region Methods

        public override void ProduceSount()
        {
            Console.WriteLine("Frogggg");
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Frog");
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");

            return result.ToString();
        }

        #endregion Methods
    }
}
