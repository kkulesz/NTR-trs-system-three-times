using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.IO;
using lab1.Models.Repositories;
using lab1.Models.DomainModel;

using lab1.Controllers.Common;

namespace lab1.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult DisplayProject()
        {
            return View(_repo.GetAllProjects());
        }

        public IActionResult CreateProjectForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(string projectName, bool isActive, List<string> categories)
        {
            string owner = this.HttpContext.Session.GetString(Constants.SessionKeyName);
            if (owner == null)
                return RedirectToAction("NotLoggedIn", "Auth");

            var newProject = new Project(projectName, owner, isActive, categories);
            _repo.CreateProject(newProject);
            return RedirectToAction("DisplayProject");
        }

        public IActionResult MarkProjectNotActive(string projectName)
        {
            string owner = this.HttpContext.Session.GetString(Constants.SessionKeyName);
            if (owner == null)
                return RedirectToAction("NotLoggedIn", "Auth");

            var inactive = _repo.GetProject(projectName).Inactive();
            _repo.UpdateProject(inactive);

            return RedirectToAction("DisplayProject");
        }
        private IRepository _repo = new RepositoryJson();
    }
}