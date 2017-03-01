namespace _08.Military_Elite.Models
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using Interfaces;

    public class LeutenantGeneral : Private
    {
        public LeutenantGeneral(string id, string firstName, string lastname, decimal salary) 
            : base(id, firstName, lastname, salary)
        {
            this.UnderCommand = new List<IPrivate>();
        }


        public List<IPrivate> UnderCommand { get; }

        public void AddPrivate(string id)
        {
            var priverForAdd = Private.privates.FirstOrDefault(p => p.Id.Equals(id));

            if (priverForAdd != null)
            {
                this.UnderCommand.Add(priverForAdd);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());
            result.AppendLine("Privates:");

            foreach (var privateUnderCommand in this.UnderCommand)
            {
                result.Append("  " + privateUnderCommand);
            }

            return result.ToString();
        }
    }
}
