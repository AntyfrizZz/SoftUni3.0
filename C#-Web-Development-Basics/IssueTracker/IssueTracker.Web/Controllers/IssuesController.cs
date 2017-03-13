using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Data.Services;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace IssueTracker.Web.Controllers
{
    public class IssuesController : Controller
    {
        private IssuesService service;

        public IssuesController()
        {
            this.service = new IssuesService();
        }

        [HttpGet]
        public IActionResult All()
        {
            List<>
            return this.View();
        }
    }
}
