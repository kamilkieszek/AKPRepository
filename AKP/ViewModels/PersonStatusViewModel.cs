using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKP.ViewModels
{
    public class PersonStatusViewModel
    {
        public int HoursWorked { get; set; }
        public double Rate { get; set; }
        public double TotalSalary { get; set; }
        public int HolidayDaysSpend { get; set; }
        public int HolidayDaysToUse { get; set; }
        public double TotalLoan { get; set; }
    }
}