using AKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKP.ViewModels
{
    public class MessageViewModel
    {
        public Person person { get; set;}
        public Message message { get; set; }
    }
}