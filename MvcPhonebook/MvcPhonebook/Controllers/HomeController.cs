﻿using MvcPhonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcPhonebook.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(string username, string password)
        {
            AuthenticationManager.Authenticate(username, password);
            if (AuthenticationManager.LoggedUser == null)
            {
                ModelState.AddModelError("authenticationFailed", "Wrong username and/or passwors");
                ViewData["username"] = username;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            AuthenticationManager.Logout();

            return RedirectToAction("Login", "Home");
        }
        }
}
