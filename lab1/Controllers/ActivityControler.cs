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

        public IActionResult CreateActivity(string code, string projectName, string executorName, int budget, DateTime date, string description)
        {
            var activity = new Activity(code, projectName, executorName, budget, date, null, description);
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
            if(activity == null){
                return RedirectToAction("DayActivity");
            }

            return View(activity);
        }
        private IRepository _repo = new RepositoryJson();
    }
}