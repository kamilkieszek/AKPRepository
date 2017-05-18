using AKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKP.Infrastructure
{
    public interface IPersonGet<T>:IRepository<Person>
    {
       List<T> GetByName (string n, string s);
       List<string> GetMail(string term);
       int GetPersonIdByUserId(string item);
       T GetPersonsByRole(string item); 
    }
    
}