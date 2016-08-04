namespace LambdaCore_Skeleton.Models.Cores
{
    using System;
    using Collection;
    using Contracts.Models;
    using Enumerations;

    public abstract class Core : ICore
    {
        private static int nameIntValue = 64;

        private CoreType type;
        private int maxDurability;
        private int modifiedDurability;
        private int pressure;
        private LStack fragments;

        protected Core(CoreType type, int maxDurability)
        {
            this.type = type;
            this.MaxDurability = maxDurability;
            nameIntValue++;
            this.Name = (char)nameIntValue;
            this.pressure = 0;
            this.fragments = new LStack();
        }

        public char Name { get; }

        protected virtual int MaxDurability
        {
            get
            {
                return this.maxDurability;
            }

            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Failed to create Core!");
                }

                this.maxDurability = value;
            }
        }

        public CoreState State => this.pressure > 0 ? CoreState.CRITICAL : CoreState.NORMAL;

        public void AddFragment(IFragment fragment)
        {
            this.fragments.Push(fragment);

            this.pressure += fragment.PressureAffection;
        }

        public IFragment RemoveLastFragment()
        {
            if (this.fragments.Count() < 1)
            {
                throw new InvalidOperationException("Failed to detach Fragment!");
            }

            var fragment = this.fragments.Pop();

            this.pressure -= fragment.PressureAffection;

            return fragment;
        }

        public int FragmentsCount()
        {
            return this.fragments.Count();
        }

        public int Durability()
        {
            this.modifiedDurability = this.maxDurability - this.pressure;

            if (this.modifiedDurability <= 0)
            {
                return 0;
            }
            else if (this.modifiedDurability >= this.maxDurability)
            {
                return this.maxDurability;
            }

            return this.modifiedDurability;
        }
    }
}
