namespace SimpleMVC.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using BindingModels;
    using Data;
    using Models;
    using MVC.Attributes.Methods;
    using MVC.Controllers;
    using MVC.Interfaces;
    using MVC.Interfaces.Generic;
    using MVC.Security;
    using SimpleHttpServer.Models;
    using ViewModels;

    public class UsersController : Controller
    {
        private SignInManager signInManager;

        public UsersController()
        {
            this.signInManager = new SignInManager(new NotesAppContext());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            var user = new User()
            {
                Username = model.Username,
                Passsword = model.Password
            };

            using (var context = new NotesAppContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult<AllUsernamesViewModel> All(HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/users/login");
                return null;
            }

            List<string> usernames = null;

            using (var context = new NotesAppContext())
            {
                usernames = context.Users
                    .Select(u => u.Username)
                    .ToList();
            }

            var viewModel = new AllUsernamesViewModel()
            {
                Usernames = usernames
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Logout(HttpSession session)
        {
            this.signInManager.Logout(session);

            return this.View("Home", "Index");
        }

        public IActionResult<GreetViewModel> Greet(HttpSession session)
        {
            var viewModel = new GreetViewModel()
            {
                SessionId = session.Id
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model, HttpSession session, HttpResponse response)
        {
            using (var context = new NotesAppContext())
            {
                var user = context
                    .Users
                    .FirstOrDefault(u => u.Username == model.Username && u.Passsword == model.Password);

                if (user != null)
                {
                    context.Logins.Add(new Login()
                    {
                        SessionId = session.Id,
                        User = user,
                        IsActive = true
                    });
                    context.SaveChanges();
                    this.Redirect(response, "/home/index");

                    return null;
                }
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            using (var context = new NotesAppContext())
            {
                var user = context.Users.Find(id);

                var viewModel = new UserProfileViewModel
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Notes = user.Notes
                        .Select(x =>
                            new NoteViewModel()
                            {
                                Title = x.Title,
                                Content = x.Content
                            })
                };

                return this.View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using (var context = new NotesAppContext())
            {
                var user = context.Users.Find(model.UserId);
                var note = new Note
                {
                    Title = model.Title,
                    Content = model.Content
                };

                user.Notes.Add(note);
                context.SaveChanges();
            }

            return this.Profile(model.UserId);
        }
    }
}