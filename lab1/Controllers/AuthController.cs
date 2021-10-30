using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LanguageExt;
using System;

using lab1.Models.Repositories;
using lab1.Models.DomainModel;

using lab1.Controllers.Common;

namespace lab1.Controllers
{
    public class AuthController : Controller
    {

        public IActionResult Index()
        {
            return _formViewWithUsers();
        }
        public IActionResult Login(string login)
        {
            var userOpt = _repo.GetUser(login);

            if (userOpt.IsNone)
            {
                return _formViewWithUsers();
            }
            else
            {
                return _handleSuccess(login);
            }
        }

        [HttpPost]
        public IActionResult Register(string login)
        {
            var userOpt = _repo.CreateUser(login);

            if (userOpt.IsNone)
            {
                return _formViewWithUsers();
            }
            else
            {
                return _handleSuccess(login);
            }
        }

        private IActionResult _handleSuccess(string login)
        {
            this.HttpContext.Session.SetString(Constants.SessionKeyName, login);
            return View("../Project/DisplayProject", _repo.GetAllProjects());
        }

        private IActionResult _formViewWithUsers(){
            return View("Index", _repo.GetAllUsers());
        }
        private IRepository _repo = new RepositoryJson();
    }
}