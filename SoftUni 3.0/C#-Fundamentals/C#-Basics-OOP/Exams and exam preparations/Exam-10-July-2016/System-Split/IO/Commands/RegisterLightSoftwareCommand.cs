namespace SystemSplit.IO.Commands
{
    class RegisterLightSoftwareCommand : Command
    {
        private string hardwareComponentName;
        private string name;
        private int capacity;
        private int memory;

        public RegisterLightSoftwareCommand(string hardwareComponentName, string name, int capacity, int memory)
        {
            this.hardwareComponentName = hardwareComponentName;
            this.name = name;
            this.capacity = capacity;
            this.memory = memory;
        }

        public override void Execute()
        {
            var software = new LightSoftware(this.hardwareComponentName, this.name, this.capacity, this.memory);
            SystemInfo.HardwareComponets[this.hardwareComponentName].AddSoftware(software);
        }
    }
}
