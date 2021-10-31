using Microsoft.AspNetCore.Mvc;

using lab1.Models.Repositories;
using lab1.Models.DomainModel;

namespace lab1.Controllers
{
    public class TrsController : Controller
    {
        public IActionResult GetProject(string projectName)
        {
            var project = _repo.GetProject(projectName);
            return project != null ? Ok(project) : NotFound();
        }

        public IActionResult GetProjectsPage()
        {
            return Ok(_repo.GetAllProjects());
        }

        [HttpPost]
        public IActionResult CreateProject([FromBody] Project project)
        {
            var newProject = _repo.CreateProject(project);
            return newProject != null ? Ok(project) : Conflict();
        }

        [HttpPut]
        public IActionResult UpdateProject([FromBody] Project project)
        {
            var updated = _repo.UpdateProject(project);
            return updated != null ? Ok(project) : NotFound();
        }

        private IRepository _repo = new RepositoryJson();
    }
}