using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using lab1.Models;

namespace lab1.Controllers
{
    public class TrsController : Controller
    {

        public TrsController()
        { }

        public IActionResult GetUser(string login)
        {
            var userOpt = _repo.GetUser(login);

            if (userOpt.HasValue)
                return Ok(userOpt.Value);
            else
                return NotFound();

        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]User user)
        {
            var userOpt = _repo.CreateUser(user);

            if (userOpt.HasValue)
                return Ok(userOpt.Value);
            else
                return Conflict();

        }

        private Repository _repo = new RepositoryJson();
    }
}