using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Common;

namespace IssueTracker.Models.ViewModels
{
    public class RegistrationVerificationErrorViewModel
    {
        private string message;

        public RegistrationVerificationErrorViewModel(string message)
        {
            this.message = message;
        }

        public override string ToString()
        {
            var alert = ViewBuilder.ReadFile(GlobalConstants.Alert);
            return string.Format(alert, this.message);
        }
    }
}
