namespace _05KingsGambitExtended
{
    using System.Collections.Generic;
    using EventsArguments;
    using Models;

    public class TroopsRepository
    {
        private readonly Dictionary<string, Troop> troops;

        public TroopsRepository()
        {
            this.troops = new Dictionary<string, Troop>();
        }

        public Troop GetTroop(string name)
        {
            return this.troops[name];
        }

        public void AddTroop(Troop troop)
        {
            this.troops.Add(troop.Name, troop);
        }

        public void OnTroopDeath(object sender, TroopDeathEventArgs args)
        {
            this.troops.Remove(args.Name);
        }
    }
}
