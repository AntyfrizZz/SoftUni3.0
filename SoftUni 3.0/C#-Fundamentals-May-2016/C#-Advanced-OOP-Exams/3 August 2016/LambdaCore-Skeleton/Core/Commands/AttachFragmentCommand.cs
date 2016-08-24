namespace LambdaCore_Skeleton.Core.Commands
{
    using System;
    using Attributes;
    using Contracts.Core;
    using Contracts.Models;
    using Contracts.Repositories;

    public class AttachFragmentCommand : Command
    {
        [Inject]
        private IFragmentFactory fragmentFactory;

        [Inject]
        private IRepository powerPlantRepository;

        public AttachFragmentCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            if (!this.powerPlantRepository.IsCurrentCoreSet())
            {
                throw new InvalidOperationException($"Failed to attach Fragment {this.Data[2]}!");
            }

            var fragmentType = this.Data[1];
            var fragmentName = this.Data[2];
            var fragmentPressure = int.Parse(this.Data[3]);

            IFragment fragment = this.fragmentFactory.CreateFragment(fragmentType, fragmentName, fragmentPressure);

            this.powerPlantRepository.AddFragment(fragment);

            return $"Successfully attached Fragment {this.Data[2]} to Core {this.powerPlantRepository.CurrentCoreName()}!";
        }
    }
}
