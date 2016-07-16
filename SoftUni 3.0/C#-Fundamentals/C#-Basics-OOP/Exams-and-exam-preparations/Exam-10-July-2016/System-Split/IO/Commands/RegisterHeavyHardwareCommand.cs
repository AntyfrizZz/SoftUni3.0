namespace SystemSplit.IO.Commands
{
    public class RegisterHeavyHardwareCommand : Command
    {
        private string name;
        private int capacity;
        private int memory;

        public RegisterHeavyHardwareCommand(string name, int capacity, int memory)
        {
            this.name = name;
            this.capacity = capacity;
            this.memory = memory;
        }

        public override void Execute()
        {
            var component = new HeavyHardware(this.name, this.capacity, this.memory);
            SystemInfo.HardwareComponets.Add(component.Name, component);
        }
    }
}
