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
    public class PhoneManagerController : Controller
    {
        //
        // GET: /PhoneManager/
        [HttpGet]
        public ActionResult EditPhone(int? parentContactId, int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");
            PhonesRepository phoneRepo = RepositoryFactory.GetPhonesRepository();
            Phone phone = null;
            if (id == null)
            {
                phone = new Phone();
                phone.ParentContactId = parentContactId.Value;
            }
            else
                phone = phoneRepo.GetById(id.Value);
            ViewData["phone"] = phone;
            return View();
        }
        [HttpPost]
        public ActionResult EditPhone(Phone phone)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            PhonesRepository phoneRepo = RepositoryFactory.GetPhonesRepository();
            phoneRepo.Save(phone);
            return RedirectToAction("ContactDetails", "ContactManager", new { id = phone.ParentContactId });

        }
        public ActionResult DeletePhone(int id)
        {
            if(AuthenticationManager.LoggedUser==null)
                return RedirectToAction("Login","Home");
                    PhonesRepository phoneRepo = RepositoryFactory.GetPhonesRepository();
            Phone phone= phoneRepo.GetById(id);
            phoneRepo.Delete(phone);
            return RedirectToAction("ContactDetails", "ContactManager", new { id = phone.ParentContactId });
        }
    }
}
