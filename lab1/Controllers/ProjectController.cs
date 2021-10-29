using Microsoft.AspNetCore.Mvc;

using lab1.Models.Repositories;
using lab1.Models.DomainModel;

namespace lab1.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult DisplayProject(string projectName)
        {
            return View(_repo.GetAllProjects());
        }
        private IRepository _repo = new RepositoryJson();
    }
}