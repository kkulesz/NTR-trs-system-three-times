using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

using lab1.Models.Repositories;
using lab1.Models.DomainModel;
using lab1.Models.ViewModel;

using lab1.Controllers.Common;

namespace lab1.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult ProjectSummaries()
        {
            string owner = this.HttpContext.Session.GetString(Constants.SessionKeyName);
            if (owner == null)
                return _redirectToLogin();

            var allProjects = _repo.GetAllProjects();
            var ownerProjects = allProjects.Filter(p => p.Owner == owner);

            var allActivities = _repo.GetAllActivities();
            var projectSummaries = new List<ProjectSummary>();
            foreach (var project in ownerProjects)
            {
                var thisProjectActivities = allActivities.Filter(a => a.ProjectName == project.Name).ToList();
                // var participantsBudget = thisProjectActivities.
                var projectSummary = new ProjectSummary(project.Name, project.IsActive, -1, -1, thisProjectActivities);
                projectSummaries.Add(projectSummary);
            }

            return View(projectSummaries);
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
                return _redirectToLogin();

            var newProject = new Project(projectName, owner, isActive, categories);
            _repo.CreateProject(newProject);
            return _redirectToProjectView();
        }

        public IActionResult MarkProjectNotActive(string projectName)
        {
            string owner = this.HttpContext.Session.GetString(Constants.SessionKeyName);
            if (owner == null)
                return _redirectToLogin();

            var inactive = _repo.GetProject(projectName).Inactive();
            _repo.UpdateProject(inactive);

            return _redirectToProjectView();
        }

        private IActionResult _redirectToProjectView()
        {
            return RedirectToAction("ProjectSummaries");
        }

        private IActionResult _redirectToLogin()
        {
            return RedirectToAction("NotLoggedIn", "Auth");
        }
        private IRepository _repo = new RepositoryJson();
    }
}