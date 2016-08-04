namespace LambdaCore_Skeleton.Core.Commands
{
    using Attributes;
    using Contracts.Repositories;

    public class SelectCoreCommand : Command
    {
        [Inject]
        private IRepository powerPlantRepository;

        public SelectCoreCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            this.powerPlantRepository.SetCurrentCore(this.Data[1][0]);
            return $"Currently selected Core {this.Data[1][0]}!";
        }
    }
}
