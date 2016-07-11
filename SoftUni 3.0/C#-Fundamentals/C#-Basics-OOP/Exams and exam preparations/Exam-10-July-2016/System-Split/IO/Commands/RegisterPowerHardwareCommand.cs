namespace SystemSplit.IO.Commands
{
    class RegisterPowerHardwareCommand : Command
    {
        private string name;
        private int capacity;
        private int memory;

        public RegisterPowerHardwareCommand(string name, int capacity, int memory)
        {
            this.name = name;
            this.capacity = capacity;
            this.memory = memory;
        }

        public override void Execute()
        {
            var component = new PowerHardware(this.name, this.capacity, this.memory);
            SystemInfo.HardwareComponets.Add(component.Name, component);
        }
    }
}
