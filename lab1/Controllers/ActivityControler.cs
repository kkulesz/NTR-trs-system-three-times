using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

using lab1.Models.Repositories;
using lab1.Models.DomainModel;

using lab1.Controllers.Common;

namespace lab1.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult DayActivity()
        {
            return View(_repo.GetActivitiesForUserForMonth("konrad", 2021, 10));
        }

        public IActionResult CreateActivityForm()
        {
            return View();
        }

        public IActionResult CreateActivity(string code, string projectName, string executorName, int budget, DateTime date, List<String> subactivities, string description)
        {
            var activity = new Activity(code, projectName, executorName, budget, date, subactivities, description);
            _repo.CreateActivity(activity);
            return RedirectToAction("DayActivity");
        }

        public IActionResult DeleteActivity(string code)
        {
            string executor = this.HttpContext.Session.GetString(Constants.SessionKeyName);
            if (executor == null)
                return RedirectToAction("NotLoggedIn", "Auth");

            _repo.DeleteActivity(code, executor);
            return RedirectToAction("DayActivity");
        }

        public IActionResult ShowActivity(string code)
        {
            string executor = this.HttpContext.Session.GetString(Constants.SessionKeyName);
            if (executor == null)
                return RedirectToAction("NotLoggedIn", "Auth");

            var activity = _repo.GetActivity(code);
            if (activity == null)
            {
                return RedirectToAction("DayActivity");
            }

            return View(activity);
        }

        public IActionResult UpdateActivityForm(string code)
        {
            string executor = this.HttpContext.Session.GetString(Constants.SessionKeyName);
            if (executor == null)
                return RedirectToAction("NotLoggedIn", "Auth");

            return View(_repo.GetActivity(code));
        }

        public IActionResult UpdateActivity(string code, string projectName, string executorName, int budget, DateTime date,List<String> subactivities, string description)
        {
            var updated = new Activity(code, projectName, executorName, budget, date, subactivities, description);
            var result = _repo.UpdateActivity(updated);
            if(result == null)
                return RedirectToAction("DayActivity"); //TODO handle error
            return RedirectToAction("DayActivity");
        }
        private IRepository _repo = new RepositoryJson();
    }
}