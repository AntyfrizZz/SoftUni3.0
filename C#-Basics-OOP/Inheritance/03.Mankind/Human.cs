using System;

namespace Mankind
{
    class Human
    {
        #region Fields

        private string firstName;
        private string lastName;

        #endregion Fields

        //===========================

        #region Constructors

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        #endregion Constructors

        //===========================

        #region Properties

        public virtual string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value[0].ToString().Equals(value[0].ToString().ToLower()))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: firstName");
                }

                this.firstName = value;
            }
        }

        public virtual string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value[0].ToString().Equals(value[0].ToString().ToLower()))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: lastName");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }

                this.lastName = value;
            }
        }

        #endregion Properties

        //===========================

        #region Methods

        #endregion Methods
    }
}
