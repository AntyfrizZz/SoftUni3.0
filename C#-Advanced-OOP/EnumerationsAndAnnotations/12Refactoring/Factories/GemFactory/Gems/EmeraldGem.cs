namespace _12Refactoring.Factories.GemFactory.Gems
{
    using Enumerations;

    public class EmeraldGem : Gem
    {
        private const int Strength = 1;
        private const int Agility = 4;
        private const int Vitality = 9;

        public EmeraldGem(
            GemTypes gemType,
            GemClarities gemClarity) 
            : base(
                  gemType, 
                  gemClarity,
                  Strength,
                  Agility,
                  Vitality)
        {
        }
    }
}