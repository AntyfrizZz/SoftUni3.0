namespace _02KingsGambit.Models
{
    using System;

    public abstract class Troop
    {
        protected Troop(string name)
        {
            this.Name = name;
        }

        protected string Name { get; }

        public abstract void OnKingAttack(object sender, EventArgs args);
    }
}
