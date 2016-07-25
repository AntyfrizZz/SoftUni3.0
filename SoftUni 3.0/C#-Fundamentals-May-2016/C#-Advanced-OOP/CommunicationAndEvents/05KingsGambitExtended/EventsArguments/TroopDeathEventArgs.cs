namespace _05KingsGambitExtended.EventsArguments
{
    using System;
    using Models;

    public class TroopDeathEventArgs : EventArgs
    {
        public TroopDeathEventArgs(string name, KingUnderAttackEventHandler respond)
        {
            this.Name = name;
            this.Respond = respond;
        }

        public string Name { get; private set; }

        public KingUnderAttackEventHandler Respond { get; private set; }
    }
}
