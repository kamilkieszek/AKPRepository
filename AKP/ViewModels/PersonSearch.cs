using AKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKP.ViewModels
{
    public class PersonSearch
    {
        public IEnumerable<Person> persons { get; set; }
    }
}