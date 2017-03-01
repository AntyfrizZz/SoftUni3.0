namespace _08.Military_Elite.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class Commando : SpecialisedSoldier
    {
        public Commando(string id, string firstName, string lastname, decimal salary, string corps)
            : base(id, firstName, lastname, salary, corps)
        {
            this.Missions = new List<Mission>();
        }

        public List<Mission> Missions { get; }

        public void AddMission(Mission mission)
        {
            this.Missions.Add(mission);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());
            result.AppendLine("Missions:");

            foreach (var mission in this.Missions)
            {
                result.AppendLine(mission.ToString());
            }

            return result.ToString();
        }
    }
}
