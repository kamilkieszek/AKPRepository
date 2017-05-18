using AKP.Infrastructure;
using AKP.Models;
using System;
using System.Web.Mvc;
using PagedList;
using Microsoft.AspNet.Identity;

namespace AKP.Controllers
{
    public class AdvertisementController : Controller
    {
        private UnitOfWork unitofwork = null;
        public AdvertisementController()
        {
            unitofwork = new UnitOfWork();
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult NewAd()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult NewAdPost(Ad newad)
        {
            try {

                string UserId = User.Identity.GetUserId();
                Ad ad = new Ad();
                ad.Name = newad.Name;
                ad.Content = newad.Content;
                ad.AddTime = DateTime.Now;
                ad.PersonId = unitofwork.PersonGetRepo.GetPersonIdByUserId(UserId);
                unitofwork.AdRepo.Add(ad);
                return View();
            }
            catch
            {
                return HttpNotFound();
            }
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult EditAd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetadbyId (int id)
        {
            try
            {
                Ad ad = unitofwork.AdRepo.GetById(id);
                return View(ad);
            }
            catch 
            {
                return HttpNotFound();
            }                         
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult EditAdPost (Ad ad)
        {       
                string UserId = User.Identity.GetUserId();
                ad.PersonId = unitofwork.PersonGetRepo.GetPersonIdByUserId(UserId);
                unitofwork.AdRepo.Update(ad);
                return View();
        }
        public ActionResult AdList(int? page)
        {
            try
            {
                var ListView = unitofwork.AdGetRepo.GetToListDsc();
                int pageSize = 3;
                int pageNumber = (page ?? 1);
                return View(ListView.ToPagedList(pageNumber, pageSize));
            }
            catch 
            {
                return HttpNotFound();
            }
        }       
    }
}