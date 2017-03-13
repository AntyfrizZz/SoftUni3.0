using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Models.Enums;

namespace IssueTracker.Models.ViewModels
{
    public class IssuesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public DateTime CreationDate { get; set; }

        public string Username { get; set; }

        public override string ToString()
        {
            var pattern = 
            return base.ToString();
        }
    }
}
