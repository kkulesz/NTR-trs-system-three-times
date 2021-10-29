using Microsoft.AspNetCore.Mvc;

using lab1.Models.Repositories;
using lab1.Models.DomainModel;

namespace lab1.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login(string login)
        {
            //todo cookie
            return _repo.GetUser(login).Match<IActionResult>(Ok, NotFound);
        }

        [HttpPost]
        public IActionResult Register([FromBody] User user)
        {
            //todo cookie
            return _repo.CreateUser(user).Match<IActionResult>(Ok, Conflict);
        }
        private IRepository _repo = new RepositoryJson();
    }
}