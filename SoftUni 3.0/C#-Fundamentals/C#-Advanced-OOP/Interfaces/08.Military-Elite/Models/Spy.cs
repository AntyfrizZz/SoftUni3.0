namespace _08.Military_Elite.Models
{
    using System.Text;

    using Interfaces;

    class Spy : ISpy
    {
        public Spy(string id, string firstName, string lastname, string codeNumber)
        {
            Id = id;
            FirstName = firstName;
            Lastname = lastname;
            CodeNumber = codeNumber;
        }

        public string Id { get; }

        public string FirstName { get; }

        public string Lastname { get; }

        public string CodeNumber { get; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"Name: {this.FirstName} {this.Lastname} Id: {this.Id}");
            result.AppendLine($"Code Number: {this.CodeNumber}");

            return result.ToString();
        }
    }
}
