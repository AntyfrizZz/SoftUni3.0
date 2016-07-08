using System.Text;

namespace Animals.Animals
{
    using System;

    class Kitten : Cat
    {
        #region Fields

        #endregion Fields

        //===========================

        #region Constructors

        public Kitten(string name, int age, string gender)
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
                if (!value.Equals("Female"))
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
            Console.WriteLine("Miau");
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Kitten");
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");

            return result.ToString();
        }

        #endregion Methods

    }
}
