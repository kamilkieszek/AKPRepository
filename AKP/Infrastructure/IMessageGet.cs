using AKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKP.Infrastructure
{
    public interface IMessageGet<T>: IRepository<Message>
    {
        IEnumerable<Message> GetAllMessageDsc(int item);
        IEnumerable<Message> GetAllMessageSend(int item);
    }
}