using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Common;
using IssueTracker.Models.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace IssueTracker.Web.Views.Users
{
    public class Register : IRenderable<HashSet<RegistrationVerificationErrorViewModel>>
    {
        public HashSet<RegistrationVerificationErrorViewModel> Model { get; set; }

        public string Render()
        {
            var header = ViewBuilder.ReadFile(GlobalConstants.Header);
            var menu = ViewBuilder.ReadFile(GlobalConstants.Menu);

            var errors = new StringBuilder();

            foreach (var error in this.Model)
            {
                errors.Append(error);
            }

            var register = ViewBuilder.ReadFile(GlobalConstants.Register);
            var registerWithErrors = string.Format(register, errors);
            var footer = ViewBuilder.ReadFile(GlobalConstants.Footer);

            return ViewBuilder.CreateView(header, menu, registerWithErrors, footer);
        }
    }
}
