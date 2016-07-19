namespace _08.Military_Elite.Models
{
    using System.Collections.Generic;
    using System.Text;

    class Engineer : SpecialisedSoldier
    {
        public Engineer(string id, string firstName, string lastname, decimal salary, string corps) 
            : base(id, firstName, lastname, salary, corps)
        {
            this.Repairs = new List<Repair>();
        }

        public List<Repair> Repairs { get; }

        public void AddRepair(Repair repair)
        {
            this.Repairs.Add(repair);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());
            result.AppendLine("Repairs:");

            foreach (var repair in this.Repairs)
            {
                result.AppendLine(repair.ToString());
            }

            return result.ToString();
        }
    }
}
