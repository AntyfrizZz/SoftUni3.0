namespace Mankind
{
    using System;
    using System.Text;

    class Worker : Human
    {
        #region Fields
        private decimal weekSalary;
        private decimal workHoursPerDay;
        #endregion Fields

        //===========================

        #region Constructors

        public Worker(string firstName, string lastName, decimal salary, decimal hoursPerDay) 
            : base(firstName, lastName)
        {
            this.WeekSalary = salary;
            this.WorkHoursPerDay = hoursPerDay;
        }

        #endregion Constructors

        //===========================

        #region Properties

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 10.0m)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }


        public decimal WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workHoursPerDay = value;
            }
        }

        #endregion Properties

        //===========================

        #region Methods

        public decimal MoneyPerHour()
        {
            return (this.weekSalary / 5.0m) / this.workHoursPerDay;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"First Name: {this.FirstName}");
            result.AppendLine($"Last Name: {this.LastName}");
            result.AppendLine($"Week Salary: {this.weekSalary:F2}");
            result.AppendLine($"Hours per day: {this.workHoursPerDay:F2}");
            result.AppendLine($"Salary per hour: {this.MoneyPerHour():F2}");

            return result.ToString();
        }

        #endregion Methods
    }
}
