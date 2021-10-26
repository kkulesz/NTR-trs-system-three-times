using Microsoft.AspNetCore.Mvc;

using lab1.Models.Repositories;
using lab1.Models.DomainModel;

namespace lab1.Controllers
{
    public class TrsController : Controller
    {
        public IActionResult GetUser(string login)
        {
            return _repo.GetUser(login).Match<IActionResult>(Ok, NotFound);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            return _repo.CreateUser(user).Match<IActionResult>(Ok, Conflict);
        }

        public IActionResult GetProject(string projectName)
        {
            return _repo.GetProject(projectName).Match<IActionResult>(Ok, NotFound);
        }

        public IActionResult GetProjectsPage(int offset=0, int limit=100)
        {
            return Ok(_repo.GetProjectsPage(offset, limit));
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] Project project)
        {
            return _repo.CreateProject(project).Match<IActionResult>(Ok, Conflict);
        }

        [HttpPut]
        public IActionResult UpdateProject([FromBody] Project project)
        {
            return _repo.UpdateProject(project).Match<IActionResult>(Ok, NotFound);
        }

        private IRepository _repo = new RepositoryJson();
    }
}