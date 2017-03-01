namespace LambdaCore_Skeleton.Core.Commands
{
    using Attributes;
    using Contracts.Models;
    using Contracts.Repositories;

    public class RemoveCoreCommand : Command
    {
        [Inject]
        private IRepository powerPlantRepository;

        public RemoveCoreCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            this.powerPlantRepository.RemoveCore(this.Data[1][0]);

            return $"Successfully removed Core {this.Data[1][0]}!";
        }
    }
}
