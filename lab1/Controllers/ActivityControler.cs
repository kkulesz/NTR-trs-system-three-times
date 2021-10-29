using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


using lab1.Models.Repositories;
using lab1.Models.DomainModel;

namespace lab1.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult DayActivity()
        {
            return View(new List<Activity>());
        }
        private IRepository _repo = new RepositoryJson();
    }
}