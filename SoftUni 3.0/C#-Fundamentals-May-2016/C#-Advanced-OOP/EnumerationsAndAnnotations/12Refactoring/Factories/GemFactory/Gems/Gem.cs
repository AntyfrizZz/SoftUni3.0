namespace _12Refactoring.Factories.GemFactory.Gems
{
    using Enumerations;

    public class Gem
    {
        private const int StrengthMinDamageIncrease = 2;
        private const int StrengthMaxDamageIncrease = 3;
        private const int AgilityhMinDamageIncrease = 1;
        private const int AgilityhMaxDamageIncrease = 4;

        private GemTypes gemType;
        private GemClarities gemClarity;

        public Gem(
            GemTypes gemType,
            GemClarities gemClarity,
            int strengthIncrease,
            int agilityIncrease,
            int vitalityIncrease)
        {
            this.gemType = gemType;
            this.gemClarity = gemClarity;

            this.StrengthIncrease = (int)gemClarity + strengthIncrease;
            this.AgilityIncrease = (int)gemClarity + agilityIncrease;
            this.VitalityIncrease = (int)gemClarity + vitalityIncrease;

            this.MinDamageIncrease = 
                (StrengthMinDamageIncrease * this.StrengthIncrease) + 
                (AgilityhMinDamageIncrease * this.AgilityIncrease);

            this.MaxDamageIncrease = 
                (StrengthMaxDamageIncrease * this.StrengthIncrease) + 
                (AgilityhMaxDamageIncrease * this.AgilityIncrease);
        }

        public int StrengthIncrease { get; }

        public int AgilityIncrease { get; }

        public int VitalityIncrease { get; }

        public int MinDamageIncrease { get; }

        public int MaxDamageIncrease { get; }
    }
}
