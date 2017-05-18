using AKP.App_Start;
using AKP.Infrastructure;
using AKP.Models;
using AKP.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AKP.Controllers
{
    public class CommunicationController : Controller
    {       
        private UnitOfWork unitofwork = null;
        
        public CommunicationController()
        {
            unitofwork = new UnitOfWork();
            
        }
        // GET: Communication
        public ActionResult Index()
        {
            var model = new CommunicationViewModel();
            model.TypeList = Const.CommunicationType;        
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(CommunicationViewModel model)
        {
            if (model.Id == 1)
            {
                return RedirectToAction("AppForPay");
            }
            else if (model.Id == 2)
            {
                return RedirectToAction("EmploymentCertificate");
            }
            else if (model.Id == 3)
            {
                return RedirectToAction("NonUseOfChildCare");
            } 
            else if (model.Id == 4)
            {
                return RedirectToAction("AskForLeave");
            }
            else
            {
                return RedirectToAction("AppForLoan");
            }          
        }
        public ActionResult AppForPay ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AppForPayPost(AppForPayViewModel.PeriodListEnum PeriodList, AppForPayViewModel.RateEnum Rate)
        {
             try
            {             
                string name = "Zaświadczenie o wynagrodzeniu";
                string content = "Zwracam się z uprzejmą prośbą wydanie zaświadczenia o wynagrodzeniu " + Rate + " za ostatni " + PeriodList + "."
                  + "Z poważaniem ";
                CreateMessage(name, content);
             }
             catch
              {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
            return View();
        }
        public ActionResult EmploymentCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmploymentCertificatePost(string command)
        {
            if (command.Equals("Potwierdź"))
            {
                try
               {
                    string name = "Zaświadczenie o zatrudnieniu";
                    string content = "Zwracam się z uprzejmą prośbą wydanie zaświadczenia o zatrudnieniu. Z poważaniem ";
                    CreateMessage(name, content); 
                }
                catch
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult NonUseOfChildCare ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NonUseOfChildCarePost(string command)
        {
            if (command.Equals("Potwierdź"))
            {
                try
                {
                    string name = "Zaświadczenie o nie korzystaniu z opieki na dziecko";
                    string content = "Zwracam się z uprzejmą prośbą wydanie zaświadczenia o nie korzystaniu z opieki na dziecko. Z poważaniem ";
                    CreateMessage(name, content);
                }
                catch
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult AskForLeave()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AskForLeavePost(HolidayViewModel model)
        {
                try
                {
                    string name = "Wniosek o urlop";
                    string content = "Proszę o " + (model.AmountOfDay).ToString() + " dni urlopu w okresie od " + (model.From).ToShortDateString() + "do" + (model.To).ToShortDateString() + "Z poważaniem ";
                    CreateMessage(name, content);
                }
                catch 
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            
                return View();         
        }
        public ActionResult AppForLoan()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AppForLoanPost(AppForLoanViewModel model, string command)
        {
            if (command.Equals("Wyślij"))
            {
                try
                {
                    string name = "Wniosek o Pozyczkę zakładową";
                    string content = "Proszę o przyznanie mi pożyczki ze środków zakładowego funduszu świadczeń socjalnych w wysokości"
                        + (model.AmountOfLoan).ToString() + " oraz ilością rat: " + (model.AmountOfInstallments).ToString()
                        + " z przeznaczeniem na " + (model.Target).ToString()
                        + ". Dane poręczyciela: " + (model.Guarantor).ToString() + "Z poważaniem ";
                    CreateMessage(name, content);
                }
                catch
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                return View();
            }
            else
            {
                double TotalLoan = CalculateTotalLoan(model);
                ViewBag.TotalLoan = TotalLoan;
                ViewBag.SumInstallment = TotalLoan / model.AmountOfInstallments;
                return View("AppForLoan");
            }
        }
        public void CreateMessage(string action, string content)
        {

                var user = UserManager.FindById(User.Identity.GetUserId());
                Person person = user.person;
                Message message = new Message();
                message.Name = action;
                message.PersonSenderId = person.PersonId;
                //popraw baze - wielu odbiorcow
                Person personsAdmin = unitofwork.PersonGetRepo.GetPersonsByRole("Administrator");
                message.PersonReceiverId = personsAdmin.PersonId;
                message.Added = DateTime.Now;
                message.Content = content + user.person.Name + " " + user.person.Surname;
                message.NumberVisits = 0;
                unitofwork.MessageRepo.Add(message);         
        }
        public double CalculateTotalLoan(AppForLoanViewModel model)
        {
            double TotalLoan = 0;
            if (model.AmountOfInstallments <= 20)
            {
                TotalLoan = model.AmountOfLoan * Const.FactorLoanShort;
            }
            else
            {
                TotalLoan = model.AmountOfLoan * Const.FactorLoanHigh;
            }
            return TotalLoan;
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
    }
}