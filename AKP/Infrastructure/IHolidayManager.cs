using AKP.DAL;
using AKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKP.Infrastructure
{
    public class IHolidayManager : IRepository<Holiday>, IHolidayGet<Holiday>
    {
        private AKPContext db = null;
        public IHolidayManager (AKPContext context)
        {
            this.db = context;
        } 
        public void Add(Holiday item)
        {
            db.Holidays.Add(item);
            db.SaveChanges();
        }

        public Holiday GetById(int id)
        {
            return db.Holidays.First(a=> a.HolidayId == id);
        }

        public void Remove(Holiday item)
        {
            db.Holidays.Remove(item);
            db.SaveChanges();
        }

        public void Update(Holiday item)
        {
            if(item.HolidayId==0)
            {
                db.Holidays.Add(item);
            }
            else
            {
                Holiday holiday = db.Holidays.Find(item.HolidayId);
                holiday.DaysSpend = item.DaysSpend;
                holiday.DaysToUse = item.DaysToUse;
                holiday.NrOfDays = item.NrOfDays;
            }
            db.SaveChanges();
        }
        public Holiday GetByPersonId(int id)
        {
            return db.Holidays.SingleOrDefault(a => a.PersonId == id);
        }
    }
}