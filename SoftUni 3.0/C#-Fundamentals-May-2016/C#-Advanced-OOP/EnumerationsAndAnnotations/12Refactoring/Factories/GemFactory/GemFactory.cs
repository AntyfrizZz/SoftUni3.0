namespace _12Refactoring.Factories.GemFactory
{
    using Enumerations;
    using Gems;

    public class GemFactory
    {
        public Gem CreateGem(GemTypes gemType, GemClarities gemClarity)
        {
            Gem gem = null;

            switch (gemType)
            {
                case GemTypes.Amethyst:
                    gem = new AmethystGem(gemType, gemClarity);
                    break;
                case GemTypes.Emerald:
                    gem = new EmeraldGem(gemType, gemClarity);
                    break;
                case GemTypes.Ruby:
                    gem = new RubyGem(gemType, gemClarity);
                    break;
            }

            return gem;
        }
    }
}
