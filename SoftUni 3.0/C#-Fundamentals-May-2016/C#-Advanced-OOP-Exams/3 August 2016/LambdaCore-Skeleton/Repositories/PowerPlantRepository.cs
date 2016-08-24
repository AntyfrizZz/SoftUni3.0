namespace LambdaCore_Skeleton.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts.Models;
    using Contracts.Repositories;

    public class PowerPlantRepository : IRepository
    {
        private const char currentCoreDefaultChar = '@';

        private Dictionary<char, ICore> cores;
        private char currentCore;
        private int totalDurability;
        private int totalFragmentsCount;

        public PowerPlantRepository()
        {
            this.cores = new Dictionary<char, ICore>();
            this.currentCore = currentCoreDefaultChar;
        }

        public string Status()
        {
            var powerPlantCoresStatus = new List<string>();
            this.totalDurability = 0;
            this.totalFragmentsCount = 0;

            foreach (var core in this.cores)
            {
                this.totalDurability += core.Value.Durability();
                this.totalFragmentsCount += core.Value.FragmentsCount();

                var current = new StringBuilder();

                current
                    .AppendLine($"Core {core.Key}:")
                    .AppendLine($"####Durability: {core.Value.Durability()}")
                    .AppendLine($"####Status: {core.Value.State}");

                powerPlantCoresStatus.Add(current.ToString().Trim());
            }

            var powerPlantOverallStatys = new StringBuilder();

            powerPlantOverallStatys
                .AppendLine("Lambda Core Power Plant Status:")
                .AppendLine($"Total Durability: {this.totalDurability}")
                .AppendLine($"Total Cores: {this.cores.Count}")
                .AppendLine($"Total Fragments: {this.totalFragmentsCount}");

            foreach (var coreStatus in powerPlantCoresStatus)
            {
                powerPlantOverallStatys.AppendLine(coreStatus);
            }

            return powerPlantOverallStatys.ToString().Trim();
        }

        public void AddCore(ICore core)
        {
            this.cores.Add(core.Name, core);
        }

        public void RemoveCore(char coreName)
        {
            if (!this.cores.ContainsKey(coreName))
            {
                throw new InvalidOperationException($"Failed to remove Core {coreName}!");
            }

            if (this.currentCore.Equals(coreName))
            {
                this.currentCore = currentCoreDefaultChar;
            }

            this.cores.Remove(coreName);
        }

        public void SetCurrentCore(char coreName)
        {
            if (!this.cores.ContainsKey(coreName))
            {
                throw new InvalidOperationException($"Failed to select Core {coreName}!");
            }

            this.currentCore = coreName;
        }

        public bool IsCurrentCoreSet()
        {
            return this.currentCore != currentCoreDefaultChar;
        }

        public char CurrentCoreName()
        {
            return this.currentCore;
        }

        public void AddFragment(IFragment fragment)
        {
            this.cores[this.currentCore].AddFragment(fragment);
        }

        public IFragment RemoveLastFragment()
        {
            if (!this.IsCurrentCoreSet())
            {
                throw new InvalidOperationException("Failed to detach Fragment!");
            }

            return this.cores[this.currentCore].RemoveLastFragment();
        }
    }
}
