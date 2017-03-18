namespace CarDealer.Models.ViewModels.Cars
{
    using System.Collections.Generic;
    using Parts;

    public class AboutCarVm
    {
        public CarVm Car { get; set; }

        public IEnumerable<PartVm> Parts { get; set; }
    }
}
