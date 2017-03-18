namespace CarDealer.Models.ViewModels.Logs
{
    using System.Collections.Generic;

    public class AllLogsPageVm
    {
        public int CurrentPage { get; set; }

        public int TotalNumberOfPages { get; set; }

        public IEnumerable<AllLogVm> Logs { get; set; }

        public string WantedUserName { get; set; }
    }
}
