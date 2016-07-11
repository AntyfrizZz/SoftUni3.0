using Kermen.Models;

namespace Kermen.Factory
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class HouseholdFactory
    {
        public static Household MakeHousehold(string input)
        {
            var pattern = @"(\w+)\(([\d\.,\s]+)\)";

            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(input);

            var householdName = matches[0].Groups[1].Value;

            switch (householdName)
            {
                case "YoungCouple":
                    return MakeCoupleYoung(matches);
                case "YoungCoupleWithChildren":
                    return MakeCoupleYoungWithChildren(matches);
                case "AloneYoung":
                    return MakeSingleYoung(matches);
                case "OldCouple":
                    return MakeCoupleOld(matches);
                case "AloneOld":
                    return MakeSingleOld(matches);
                default:
                    throw new InvalidOperationException();
            }
        }

        private static Household MakeSingleOld(MatchCollection matches)
        {
            var income = decimal.Parse(matches[0].Groups[2].Value);

            return new AloneOld(income);
        }

        private static Household MakeCoupleOld(MatchCollection matches)
        {
            var incomes = matches[0].Groups[2].Value
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            var incomeOne = incomes[0];
            var incomeTwo = incomes[1];
            var tvCosts = decimal.Parse(matches[1].Groups[2].Value);
            var fridgeCosts = decimal.Parse(matches[2].Groups[2].Value);
            var stoveCosts = decimal.Parse(matches[3].Groups[2].Value);

            return new OldCouple(incomeOne, incomeTwo, tvCosts, fridgeCosts, stoveCosts);
        }

        private static Household MakeSingleYoung(MatchCollection matches)
        {
            var income = decimal.Parse(matches[0].Groups[2].Value);
            var laptopCosts = decimal.Parse(matches[1].Groups[2].Value);

            return new AloneYoung(income, laptopCosts);
        }

        private static Household MakeCoupleYoungWithChildren(MatchCollection matches)
        {
            var incomes = matches[0].Groups[2].Value
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            var incomeOne = incomes[0];
            var incomeTwo = incomes[1];
            var tvCosts = decimal.Parse(matches[1].Groups[2].Value);
            var fridgeCosts = decimal.Parse(matches[2].Groups[2].Value);
            var laptopCosts = decimal.Parse(matches[3].Groups[2].Value);

            var matchesBeforeChildren = 4;
            var numberOfChildren = matches.Count - matchesBeforeChildren;
            var children = new Child[numberOfChildren];

            for (int i = matchesBeforeChildren; i < matches.Count; i++)
            {
                var childCosts = matches[i].Groups[2].Value
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(decimal.Parse)
                    .ToArray();

                children[i - matchesBeforeChildren] = new Child(childCosts);
            }

            return new YoungCoupleWithChildren(incomeOne, incomeTwo, tvCosts, fridgeCosts, laptopCosts, children);
        }

        private static Household MakeCoupleYoung(MatchCollection matches)
        {
            var incomes = matches[0].Groups[2].Value
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            var incomeOne = incomes[0];
            var incomeTwo = incomes[1];
            var tvCosts = decimal.Parse(matches[1].Groups[2].Value);
            var fridgeCosts = decimal.Parse(matches[2].Groups[2].Value);
            var laptopCosts = decimal.Parse(matches[3].Groups[2].Value);

            return new YoungCouple(incomeOne, incomeTwo, tvCosts, fridgeCosts, laptopCosts);
        }
    }
}
