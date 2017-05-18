using AKP.Infrastructure;
using AKP.Models;
using AKP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AKP.Controllers
{
    public class PersonController : Controller
    {
        private UnitOfWork unitofwork = null;
        public PersonController()
        {
            unitofwork = new UnitOfWork();
        }
        
        public ActionResult NewPerson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewPersonPost (Person person)
        {
                person.DateOfEmployment = DateTime.Now;
                unitofwork.PersonRepo.Add(person);
            
                return View();
        }
        public ActionResult Edit ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetPerson (string name, string surname)
        {
            IEnumerable<Person> personsView = unitofwork.PersonGetRepo.GetByName(name, surname);
            if (personsView != null)
            {
                PersonSearch personsearch = new PersonSearch()
                { persons = personsView };
                return View(personsearch);
            }
            else
            {
                return Content("W systemie nie ma takiego pracownika!");
            }
        }
        public ActionResult EditPerson (int id)
        {
            Person person = unitofwork.PersonRepo.GetById(id);
            return View(person);
        }
        public ActionResult EditPersonPost (Person person)
        {
            if (!ModelState.IsValid)
                unitofwork.PersonRepo.Update(person);
            return View();
        }
        

    }
}