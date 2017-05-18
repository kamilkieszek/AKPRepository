using AKP.DAL;
using AKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKP.Infrastructure
{
    public class ISalaryManager : IRepository<Salary>, ISalaryGet<Salary>
    {
        private AKPContext db = null;
        public ISalaryManager (AKPContext context)
        {
            this.db = context;
        }
        public void Add(Salary item)
        {
            db.Salaries.Add(item);
            db.SaveChanges();
        }

        public Salary GetById(int id)
        {
            return db.Salaries.First(a => a.SalaryId == id);
        }

        public void Remove(Salary item)
        {
            db.Salaries.Remove(item);
            db.SaveChanges();
        }

        public void Update(Salary item)
        {
            if (item.SalaryId==0)
            {
                db.Salaries.Add(item);
            }
            else
            {
                Salary salary = db.Salaries.First(a => a.SalaryId == item.SalaryId);
                salary.HoursWorked = item.HoursWorked;
                salary.Rate = item.Rate;
                salary.Month = item.Month;
                salary.Year = item.Year;
            }
            db.SaveChanges();
        }
        public Salary GetByPersonId(int id)
        {
            return db.Salaries.SingleOrDefault(a => a.PersonId == id);
        }
    }
}