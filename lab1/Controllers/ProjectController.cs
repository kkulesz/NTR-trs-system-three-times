using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using lab1.Models.Repositories;
using lab1.Models.DomainModel;

using lab1.Controllers.Common;

namespace lab1.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult DisplayProject(string projectName)
        {
            Console.WriteLine(this.HttpContext.Session.GetString(Constants.SessionKeyName));
            if (this.HttpContext.Session.GetString(Constants.SessionKeyName) != null)
            {
                Console.WriteLine($"login = {this.HttpContext.Session.GetString(Constants.SessionKeyName)}");
            }
            return View(_repo.GetAllProjects());
        }

        public IActionResult CreateProjectForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(Project newProject)
        {
            _repo.CreateProject(newProject);
            return View("../Activity/DayActivity");
        }
        private IRepository _repo = new RepositoryJson();
    }
}