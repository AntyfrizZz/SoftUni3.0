namespace SystemSplit
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class SystemInfo
    {
        public static Dictionary<string, Hardware> HardwareComponets = new Dictionary<string, Hardware>();

        public static Dictionary<string, Hardware> DumpedHardwareComponets = new Dictionary<string, Hardware>();

        public static void Analize()
        {
            var systemComponentsInformation = SystemComponents();
            //Item1 - softwareComponentsCount
            //Item2 - totalMemoryInUse
            //Item3 - totalMemory
            //Item4 - totalCapacityInUse
            //Item5 - totalCapacity

            var result = new StringBuilder();

            result.AppendLine("System Analysis");
            result.AppendLine($"Hardware Components: {HardwareComponets.Count}");
            result.AppendLine($"Software Components: {systemComponentsInformation.Item1}");
            result.AppendLine($"Total Operational Memory: {systemComponentsInformation.Item2} / {systemComponentsInformation.Item3}");
            result.AppendLine($"Total Capacity Taken: {systemComponentsInformation.Item4} / {systemComponentsInformation.Item5}");

            System.Console.Write(result);
        }

        public static void DumpAnalize()
        {
            var dumpedSystemComponentsInformation = DumpedSystemComponents();
            //Item1 - dumpedPowerHardwareComponents
            //Item2 - dumpedHeavyHardwareComponents
            //Item3 - dumpedExpressSoftwareComponents
            //Item4 - dumpedLightSoftwareComponents
            //Item5 - dumpedMemory
            //Item6 - dumpedCapacity

            var result = new StringBuilder();

            result.AppendLine("Dump Analysis");
            result.AppendLine($"Power Hardware Components: {dumpedSystemComponentsInformation.Item1}");
            result.AppendLine($"Heavy Hardware Components: {dumpedSystemComponentsInformation.Item2}");
            result.AppendLine($"Express Software Components: {dumpedSystemComponentsInformation.Item3}");
            result.AppendLine($"Light Software Components: {dumpedSystemComponentsInformation.Item4}");
            result.AppendLine($"Total Dumped Memory: {dumpedSystemComponentsInformation.Item5}");
            result.AppendLine($"Total Dumped Capacity: {dumpedSystemComponentsInformation.Item6}");

            System.Console.Write(result);
        }

        private static Tuple<int, int, int, int, int, int> DumpedSystemComponents()
        {
            var dumpedPowerHardwareComponents = 0;
            var dumpedHeavyHardwareComponents = 0;
            var dumpedExpressSoftwareComponents = 0;
            var dumpedLightSoftwareComponents = 0;
            var dumpedMemory = 0;
            var dumpedCapacity = 0;

            foreach (var dumpedHardwareComponent in DumpedHardwareComponets)
            {
                if (dumpedHardwareComponent.Value.Type.Equals("Heavy"))
                {
                    dumpedHeavyHardwareComponents++;
                }
                //Equals Power
                else
                {
                    dumpedPowerHardwareComponents++;
                }

                foreach (var software in dumpedHardwareComponent.Value.Software)
                {
                    dumpedMemory += software.Value.MemoryConsumption;
                    dumpedCapacity += software.Value.CapacityConsumption;

                    if (software.Value.Type.Equals("Express"))
                    {
                        dumpedExpressSoftwareComponents++;
                    }
                    //Equals Light
                    else
                    {
                        dumpedLightSoftwareComponents++;
                    }
                }
            }

            return new Tuple<int, int, int, int, int, int>(
                dumpedPowerHardwareComponents,
                dumpedHeavyHardwareComponents,
                dumpedExpressSoftwareComponents,
                dumpedLightSoftwareComponents,
                dumpedMemory,
                dumpedCapacity);
        }

        private static Tuple<int, int, int, int, int> SystemComponents()
        {
            var softwareComponentsCount = 0;
            var totalMemoryInUse = 0;
            var totalMemory = 0;
            var totalCapacityInUse = 0;
            var totalCapacity = 0;

            foreach (var hardwareComponet in HardwareComponets)
            {
                softwareComponentsCount += hardwareComponet.Value.Software.Count;
                totalMemory += hardwareComponet.Value.MaximumMemory;
                totalCapacity += hardwareComponet.Value.MaximumCapacity;

                foreach (var software in hardwareComponet.Value.Software)
                {
                    totalMemoryInUse += software.Value.MemoryConsumption;
                    totalCapacityInUse += software.Value.CapacityConsumption;
                }
            }

            return new Tuple<int, int, int, int, int>(
                softwareComponentsCount, 
                totalMemoryInUse, 
                totalMemory, 
                totalCapacityInUse, 
                totalCapacity);
        }
    }
}
