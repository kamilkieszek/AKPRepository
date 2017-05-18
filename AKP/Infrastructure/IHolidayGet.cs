using AKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKP.Infrastructure
{
    public interface IHolidayGet<T>: IRepository<Holiday>
    {
        Holiday GetByPersonId(int item);
    }
}