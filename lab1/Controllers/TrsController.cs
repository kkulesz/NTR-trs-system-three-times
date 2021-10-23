using Microsoft.AspNetCore.Mvc;
using lab1.Models;

namespace lab1.Controllers
{
    public class TrsController : Controller
    {

        public TrsController()
        { }

        public IActionResult GetUser(string login)
        {
            return _repo.GetUser(login).Match<IActionResult>(Ok, NotFound);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]User user)
        {
            return _repo.CreateUser(user).Match<IActionResult>(Ok, Conflict);
        }

        private Repository _repo = new RepositoryJson();
    }
}