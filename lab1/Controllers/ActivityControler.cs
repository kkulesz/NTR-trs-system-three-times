using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;

using lab1.Models.Repositories;
using lab1.Models.DomainModel;

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
        private IRepository _repo = new RepositoryJson();
    }
}