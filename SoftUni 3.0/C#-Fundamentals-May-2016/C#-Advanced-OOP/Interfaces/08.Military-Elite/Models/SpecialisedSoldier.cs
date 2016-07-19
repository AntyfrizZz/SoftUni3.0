namespace _08.Military_Elite.Models
{
    using System;
    using System.Text;

    public abstract class SpecialisedSoldier : Private
    {
        private string corps;

        protected SpecialisedSoldier(string id, string firstName, string lastname, decimal salary, string corps) 
            : base(id, firstName, lastname, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get
            {
                return this.corps;
            }
            set
            {
                if (!value.Equals("Airforces") && !value.Equals("Marines"))
                {
                    throw new InvalidOperationException();
                }

                this.corps = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());
            result.AppendLine($"Corps: {this.Corps}");
            return result.ToString();
        }
    }
}
