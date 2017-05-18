using AKP.DAL;
using AKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKP.Infrastructure
{
    public interface IAdGet<T>: IRepository<Ad>
    {
        IEnumerable<T> GetToListDsc();
    }
}