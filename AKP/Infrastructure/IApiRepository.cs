using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKP.Infrastructure
{
    public interface IApiRepository<T> where T : class
    {
        T GetApi(string item);
        T GetApi();
    }
}