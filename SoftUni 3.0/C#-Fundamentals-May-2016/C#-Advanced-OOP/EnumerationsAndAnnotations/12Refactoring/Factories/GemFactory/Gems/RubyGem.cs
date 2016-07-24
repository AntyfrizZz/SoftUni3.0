﻿namespace _12Refactoring.Factories.GemFactory.Gems
{
    using Enumerations;

    public class RubyGem : Gem
    {
        private const int Strength = 7;
        private const int Agility = 2;
        private const int Vitality = 5;

        public RubyGem(
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