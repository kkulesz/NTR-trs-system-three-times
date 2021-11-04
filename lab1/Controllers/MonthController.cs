// using System.Collections.Generic;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Http;
// using System;


// using lab1.Models.Repositories;
// using lab1.Models.DomainModel;
// using lab1.Models.ViewModel;

// using lab1.Controllers.Common;

// namespace lab1.Controllers
// {
//     public class MonthController : Controller
//     {
//         public IActionResult MonthActivities(Nullable<DateTime> date)
//         {
//             string executor = this.HttpContext.Session.GetString(Constants.SessionKeyName);
//             if (executor == null)
//                 return RedirectToAction("NotLoggedIn", "Auth");
//             // var activitiesThisMonth =
//             return View();
//         }
//         private IRepository _repo = new RepositoryJson();
//     }
// }