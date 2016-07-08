using System.Text;

namespace Animals.Animals
{
    using System;

    public class Dog : Animal
    {

        #region Fields

        #endregion Fields

        //===========================

        #region Constructors

        public Dog(string name, int age, string gender) : base(name, age, gender)
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
            Console.WriteLine("BauBau");
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Dog");
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");

            return result.ToString();
        }

        #endregion Methods

    }
}
