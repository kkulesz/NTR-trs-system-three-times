using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

using lab2and3.Models.Repositories;
using lab2and3.Models.DomainModel;
using lab2and3.Models.ViewModel;

using lab2and3.Controllers.Common;

namespace lab2and3.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult MonthSummary(Nullable<DateTime> date)
        {
            string executor = this.HttpContext.Session.GetString(Constants.SessionKeyName);
            if (executor == null)
                return _redirectToLogin();

            var fetchDate = date ?? DateTime.Today;
            var year = fetchDate.Year;
            var month = fetchDate.Month;

            var activitiesThisMonth = _repo.GetActivitiesForUserForMonth(executor, year, month);
            var usersMonth = _repo.GetUsersMonth(executor, year, month);
            var validUsersMonth = usersMonth ?? new UsersMonth
            {
                UsersMonthId = Guid.NewGuid(),
                Year = year,
                Month = month,
                UserLogin = executor,
                Frozen = false
            };

            var projectsThisMonth = activitiesThisMonth.ConvertAll(a => a.Project).Distinct();
            var projectActivitiesList = new List<ProjectActivities>();
            foreach (var projectName in projectsThisMonth)
            {
                var activitiesForThisProject = activitiesThisMonth.Filter(a => a.Project == projectName).ToList();
                var projectActivities = new ProjectActivities(projectName, activitiesForThisProject);
                projectActivitiesList.Add(projectActivities);
            }

            var monthSummary = new MonthSummary(projectActivitiesList, validUsersMonth);

            return View(monthSummary);
        }

        public IActionResult CreateActivityForm()
        {
            var projects = _repo.GetAllProjects();
            var activeProjectNames = projects.Filter(p => p.IsActive).ToList().ConvertAll(p => p.Name);
            return View(activeProjectNames);
        }

        public IActionResult CreateActivity(string code, string projectName, int budget, DateTime date, string description)
        {
            string executor = this.HttpContext.Session.GetString(Constants.SessionKeyName);
            if (executor == null)
                return _redirectToLogin();
            var activity = new Activity
            {
                ActivityId = Guid.NewGuid(),
                Code = code,
                Project = projectName,
                Executor = executor,
                Budget = budget,
                AcceptedBudget = null,
                Date = date,
                Subactivities = null,
                Description = description,
                IsActive = true
            };
            _repo.CreateActivity(activity);
            return _redirectToActivityView();
        }

        public IActionResult DeleteActivity(string code)
        {
            string executor = this.HttpContext.Session.GetString(Constants.SessionKeyName);
            if (executor == null)
                return _redirectToLogin();

            _repo.DeleteActivity(code, executor);
            return _redirectToActivityView();
        }

        public IActionResult ShowActivity(string code)
        {
            string executor = this.HttpContext.Session.GetString(Constants.SessionKeyName);
            if (executor == null)
                return _redirectToLogin();

            var activity = _repo.GetActivity(code);
            if (activity == null)
            {
                return _redirectToActivityView();
            }

            return View(activity);
        }

        public IActionResult UpdateActivityForm(string code)
        {
            string executor = this.HttpContext.Session.GetString(Constants.SessionKeyName);
            if (executor == null)
                return _redirectToLogin();
            var activity = _repo.GetActivity(code);
            return View(activity);
        }

        public IActionResult UpdateActivity(string code, string projectName, string executorName, int budget, int acceptedBudget, DateTime date, string description)
        {
            var updated = new Activity
            {
                ActivityId = Guid.NewGuid(),
                Code = code,
                Project = projectName,
                Executor = executorName,
                Budget = budget,
                AcceptedBudget = acceptedBudget,
                Date = date,
                Subactivities = null,
                Description = description,
                IsActive = true
            };
            var result = _repo.UpdateActivity(updated);
            if (result == null)
                return _redirectToActivityView(); //TODO handle error
            return _redirectToActivityView();
        }

        public IActionResult AcceptMonth(DateTime date)
        {
            string executor = this.HttpContext.Session.GetString(Constants.SessionKeyName);
            if (executor == null)
                return _redirectToLogin();

            var month = new UsersMonth
            {
                UsersMonthId = Guid.NewGuid(),
                Year = date.Year,
                Month = date.Month,
                UserLogin = executor,
                Frozen = true
            };

            var activitiesThisMonth = _repo.GetAllActivities()
                    .Filter(a => a.Date.Month == date.Month && a.Date.Year == date.Year)
                    .ToList()
                    .ConvertAll(a => a.Inactive());
            _repo.AcceptMonthForUser(month);
            foreach (var act in activitiesThisMonth)
            {
                _repo.UpdateActivity(act);
            }

            return _redirectToActivityView();
        }

        private IActionResult _redirectToActivityView()
        {
            return RedirectToAction("MonthSummary");
        }

        private IActionResult _redirectToLogin()
        {
            return RedirectToAction("NotLoggedIn", "Auth");
        }

        private IRepository _repo = new RepositoryEf();
    }
}