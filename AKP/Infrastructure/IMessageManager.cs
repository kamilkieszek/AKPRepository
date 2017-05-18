using AKP.DAL;
using AKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AKP.Infrastructure
{
    public class IMessageManager : IRepository<Message>, IMessageGet<Message>
    {
        private AKPContext db = null; 
        public IMessageManager (AKPContext context)
        {
            this.db = context;
        }

        public void Add(Message item)
        {
            db.Messages.Add(item);
            db.SaveChanges();
        }

        public Message GetById(int id)
        {
            return db.Messages.First(a => a.MessageId == id);
        }

        public void Remove(Message item)
        {
            db.Messages.Remove(item);
            db.SaveChanges();
        }

        public void Update(Message item)
        {
            if(item.MessageId == 0)
            {
                db.Messages.Add(item);
            }
            else
            {
                Message message = db.Messages.First(a => a.MessageId == item.MessageId);
                message.Added = item.Added;
                message.Content = item.Content;
            }
            db.SaveChanges();
        }
        public IEnumerable<Message> GetAllMessageDsc(int item)
        {
            //IEnumerable<Message> message = db.Messages.Where(m => m.PersonId == item).OrderByDescending(a =>a.Added);
            //IEnumerable<Message> messagelist = db.Messages.OrderByDescending(m => m.Added);

            IEnumerable<Message> message= db.Messages.Where(m => m.PersonReceiverId == item).OrderByDescending(m => m.Added).ToList();
            return message;
        }
        public IEnumerable<Message> GetAllMessageSend(int item)
        {
            IEnumerable<Message> message = db.Messages.Where(m => m.PersonSenderId == item).OrderByDescending(m => m.Added);
            return message;
        }

    }
}