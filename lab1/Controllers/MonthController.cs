using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


using lab1.Models.Repositories;
using lab1.Models.DomainModel;

namespace lab1.Controllers
{
    public class MonthController : Controller
    {
        public IActionResult MonthActivities()
        {
            return View(new List<UsersMonth>());
        }
        private IRepository _repo = new RepositoryJson();
    }
}