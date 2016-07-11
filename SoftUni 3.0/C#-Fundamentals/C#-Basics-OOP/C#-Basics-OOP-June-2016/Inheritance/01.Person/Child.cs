using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Child : Person
    {

        #region Fields

        #endregion Fields

        //===========================

        #region Constructors

        public Child(string name, int age)
            : base(name, age)
        {
        }

        #endregion Constructors

        //===========================

        #region Properties

        public override int Age
        {
            get { return base.Age; }
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException("Child's age must be less than 15!");
                }

                base.Age = value;
            }
        }

        #endregion Properties

        //===========================

        #region Methods

        #endregion Methods
    }
}
