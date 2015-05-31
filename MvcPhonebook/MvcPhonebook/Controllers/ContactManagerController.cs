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
    public class ContactManagerController : Controller
    {
        //
        // GET: /ContactManager/

        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            ContactsRepository contRepo = RepositoryFactory.GetContactsRepository();
            ViewData["contacts"] = contRepo.GetAll(AuthenticationManager.LoggedUser.Id);


            return View();
        }
        public ActionResult ContactDetails(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            ContactsRepository contRepo = RepositoryFactory.GetContactsRepository();
            PhonesRepository phonesRepo = RepositoryFactory.GetPhonesRepository();

            ViewData["contact"] = contRepo.GetById(id);
            ViewData["phones"] = phonesRepo.GetAll(id);

            return View();
        }
        [HttpGet]
        public ActionResult EditContact(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            ContactsRepository contRepo = RepositoryFactory.GetContactsRepository();
            Contact cont = null;
            if (id == null)
            {
                cont = new Contact();
                cont.ParentUserId = AuthenticationManager.LoggedUser.Id;
            }
            else
                cont = contRepo.GetById(id.Value);
            ViewData["contact"] = cont;
            return View();
        }
        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            ContactsRepository contRepo = RepositoryFactory.GetContactsRepository();
            contRepo.Save(contact);

            return RedirectToAction("Index", "ContactManager");
        }
        public ActionResult DeleteContact(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            ContactsRepository contRepo = RepositoryFactory.GetContactsRepository();
            Contact cont = contRepo.GetById(id);
            contRepo.Delete(cont);

            return RedirectToAction("Index", "ContactManager");
        }
    }
}
