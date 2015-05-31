using DataAccess.Entity;
using DataAccess.Repository;
using MvcPhonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPhonebook.Controllers
{
    public class UserManagerController : Controller
    {
        //
        // GET: /UserManager/

        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UsersRepository userRepo = RepositoryFactory.GetUserRepository();
            ViewData["users"] = userRepo.GetAll();

            return View();

        }
        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");
            UsersRepository userRepo = RepositoryFactory.GetUserRepository();

            User user = null;
            if (id == null)
                user = new User();
            else
                user = userRepo.GetById(id.Value);
            ViewData["user"] = user;
            return View();
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if(AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");
            UsersRepository userRepo = RepositoryFactory.GetUserRepository();
            userRepo.Save(user);
            return RedirectToAction("Index", "UserManager");
        }
        public ActionResult DeleteUser(int id)
        {
            if (AuthenticationManager.LoggedUser==null)
                return RedirectToAction("Login","Home");
            UsersRepository userRepo = RepositoryFactory.GetUserRepository();
            User user = userRepo.GetById(id);
            userRepo.Delete(user);
            return RedirectToAction("Index", "UserManager");
        }



        }
    }

