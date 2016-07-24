namespace _12Refactoring.Factories.GemFactory.Gems
{
    using Enumerations;

    public class AmethystGem : Gem
    {
        private const int Strength = 2;
        private const int Agility = 8;
        private const int Vitality = 4;

        public AmethystGem(
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