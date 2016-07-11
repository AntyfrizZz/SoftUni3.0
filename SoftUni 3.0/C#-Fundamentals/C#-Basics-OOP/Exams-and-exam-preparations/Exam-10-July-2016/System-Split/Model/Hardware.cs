using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemSplit
{
    public abstract class Hardware : Component
    {
        #region Constructors

        protected Hardware(string name, int maximumCapacity, int maximumMemory)
            : base(name)
        {
            this.MaximumCapacity = maximumCapacity;
            this.MaximumMemory = maximumMemory;

            this.Software = new Dictionary<string, Software>();
        }

        #endregion Constructors

        //===================================================================

        #region Properties

        public int MaximumCapacity { get; protected set; }

        public int CapacityInUse { get; protected set; }

        public int MaximumMemory { get; protected set; }

        public int MemoryInUse { get; protected set; }

        public int ExpressSoftwareCount { get; protected set; }

        public int LightSoftwareCount { get; protected set; }


        public Dictionary<string, Software> Software { get; set; }

        #endregion Properties

        //===================================================================

        #region Methods

        public void AddSoftware(Software software)
        {
            if (this.CapacityInUse + software.CapacityConsumption > this.MaximumCapacity ||
                this.MemoryInUse + software.MemoryConsumption > this.MaximumMemory)
            {
                throw new InvalidOperationException();
            }

            if (!software.Type.Equals("Express") && !software.Type.Equals("Light"))
            {
                throw new InvalidOperationException();
            }

            if (software.Type.Equals("Express"))
            {
                this.ExpressSoftwareCount++;
            }
            else //Equals Light
            {
                this.LightSoftwareCount++;
            }

            this.CapacityInUse += software.CapacityConsumption;
            this.MemoryInUse += software.MemoryConsumption;

            this.Software.Add(software.Name, software);
        }

        public void RemoveSoftware(string name)
        {
            if (!this.Software.ContainsKey(name))
            {
                throw new InvalidOperationException();
            }

            this.CapacityInUse -= this.Software[name].CapacityConsumption;
            this.MemoryInUse -= this.Software[name].MemoryConsumption;

            if (this.Software[name].Type.Equals("Express"))
            {
                this.ExpressSoftwareCount--;
            }
            else //Equals Light
            {
                this.LightSoftwareCount--;
            }

            this.Software.Remove(name);
        }

        public override string ToString()
        {
            var softwareNames = "None";

            if (this.Software.Any())
            {
                softwareNames = string.Join(", ", this.Software.Keys);
            }

            var result = new StringBuilder();

            result.AppendLine($"Hardware Component - {this.Name}");
            result.AppendLine($"Express Software Components - {this.ExpressSoftwareCount}");
            result.AppendLine($"Light Software Components - {this.LightSoftwareCount}");
            result.AppendLine($"Memory Usage: {this.MemoryInUse} / {this.MaximumMemory}");
            result.AppendLine($"Capacity Usage: {this.CapacityInUse} / {this.MaximumCapacity}");
            result.AppendLine($"Type: {this.Type}");
            result.Append($"Software Components: {softwareNames}");

            return result.ToString();
        }

        #endregion Methods
    }
}