namespace _04MirrorImage.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Repositories;

    public abstract class Caster : ICast
    {
        private const int MaxNumberOfReflections = 2;
        private static int idCounter = 0;

        private string name;
        private int spellPower;
        private List<Reflection> reflections;

        protected Caster(string name, int spellPower)
        {
            this.name = name;
            this.spellPower = spellPower;
            this.Id = idCounter;
            this.reflections = new List<Reflection>();
        }

        public event EventHandler CastFireballEvent;

        public event EventHandler CastReflectionEvent;

        public int Id { get; }

        public void CastFireball(object sender, EventArgs eventArgs)
        {
            Console.WriteLine($"{this.name} {this.Id} casts Fireball for {this.spellPower} damage");

            this.CastFireballEvent?.Invoke(null, EventArgs.Empty);
        }

        public void CastReflection(object sender, EventArgs eventArgs)
        {
            Console.WriteLine($"{this.name} {this.Id} casts Reflection");

            if (this.reflections.Count == 0)
            {
                for (int i = 0; i < MaxNumberOfReflections; i++)
                {
                    idCounter++;
                    var newReflection = new Reflection(this.name, this.spellPower/2);
                    this.CastReflectionEvent += newReflection.CastReflection;
                    this.CastFireballEvent += newReflection.CastFireball;
                    this.reflections.Add(newReflection);
                    CasterRepository.AddCaster(newReflection);
                }
            }
            else
            {
                this.CastReflectionEvent?.Invoke(null, EventArgs.Empty);
            }
        }
    }
}
