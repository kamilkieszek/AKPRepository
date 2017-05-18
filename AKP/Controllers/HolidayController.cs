using AKP.Infrastructure;
using AKP.Models;
using AKP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKP.Controllers
{
    public class HolidayController : Controller
    {
        private UnitOfWork unitofwork = null;
        public HolidayController ()
        {
            unitofwork = new UnitOfWork();
        }
        
        public ActionResult HolidayInfo(int id)
        {
            try
            {
                Holiday holidayById = unitofwork.HolidayRepo.GetById(id);
                HolidayInfo holidayinfo = new HolidayInfo()
                {
                    holiday = holidayById,
                    number = 0
                };
                return View(holidayinfo);
            }
            catch
            {
                return HttpNotFound();
            }
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult HolidayUpdate(int id, int number)
        {
            Holiday holiday = unitofwork.HolidayRepo.GetById(id);
            holiday.DaysSpend += number;
            holiday.DaysToUse -= number;
            if (holiday.DaysSpend > holiday.NrOfDays)
            {
                return View(holiday);
            }
            else
            {
                unitofwork.HolidayRepo.Update(holiday);
                return View(holiday);
            }
        }
    }
}