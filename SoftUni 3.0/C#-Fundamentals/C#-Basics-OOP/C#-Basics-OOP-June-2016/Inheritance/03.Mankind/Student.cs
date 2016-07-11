namespace Mankind
{
    using System;
    using System.Text;

    class Student : Human
    {
        #region Fields

        private string facultyNumber;

        #endregion Fields

        //===========================

        #region Constructors
        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }
        #endregion Constructors

        //===========================

        #region Properties

        public override string FirstName
        {
            get { return base.FirstName; }
            set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
                }

                base.FirstName = value;
            }
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException($"Invalid faculty number!");
                }
                else
                {
                    foreach (var character in value)
                    {
                        if (!char.IsLetterOrDigit(character))
                        {
                            throw new ArgumentException($"Invalid faculty number!");
                        }
                    }

                    this.facultyNumber = value;
                }
            }
        }
        #endregion Properties

        //===========================

        #region Methods

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"First Name: {this.FirstName}");
            result.AppendLine($"Last Name: {this.LastName}");
            result.AppendLine($"Faculty number: {this.facultyNumber}");

            return result.ToString();
        }

        #endregion Methods

    }
}
