using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AKP.ViewModels
{
    public class CommunicationViewModel
    {
        public int Id { get; set; }
        public IEnumerable<SelectListItem> TypeList { get; set; }
    }
}