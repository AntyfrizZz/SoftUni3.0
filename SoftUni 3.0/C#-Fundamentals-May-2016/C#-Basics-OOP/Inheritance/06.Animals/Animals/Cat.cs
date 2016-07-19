using System.Text;

namespace Animals.Animals
{
    using System;

    public class Cat : Animal
    {

        #region Fields

        #endregion Fields

        //===========================

        #region Constructors

        public Cat(string name, int age, string gender) : base(name, age, gender)
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
            Console.WriteLine("MiauMiau");
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Cat");
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");

            return result.ToString();
        }

        #endregion Methods

    }
}
