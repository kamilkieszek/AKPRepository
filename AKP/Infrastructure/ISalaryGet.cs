using AKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKP.Infrastructure
{
    public interface ISalaryGet<T>: IRepository<Salary>
    {
        Salary GetByPersonId(int item);
    }
}