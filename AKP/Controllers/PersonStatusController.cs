using AKP.App_Start;
using AKP.Infrastructure;
using AKP.Models;
using AKP.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKP.Controllers
{
    public class PersonStatusController : Controller
    {
        private UnitOfWork unitofwork = null;

        public PersonStatusController()
        {
            unitofwork = new UnitOfWork();

        }
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: PersonStatus
        [Authorize]
        public ActionResult Index()
        {
            PersonStatusViewModel model = new PersonStatusViewModel();
            var user = UserManager.FindById(User.Identity.GetUserId());
            Person person = user.person;

            Salary salary = unitofwork.SalaryGetRepo.GetByPersonId(person.PersonId);
            model.Rate = salary.Rate;
            model.HoursWorked = salary.HoursWorked;
            model.TotalSalary = salary.Rate * salary.HoursWorked;
            model.TotalLoan = salary.TotalLoan;

            Holiday holiday = unitofwork.HolidayGetRepo.GetByPersonId(person.PersonId);
            model.HolidayDaysSpend = holiday.DaysSpend;
            model.HolidayDaysToUse = holiday.DaysToUse;
            
            return View(model);
        }
    }
}