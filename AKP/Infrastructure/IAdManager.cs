using AKP.DAL;
using AKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AKP.Infrastructure
{
    public class IAdManager : IRepository<Ad>, IAdGet<Ad>
    {
        private AKPContext db = null;
        public IAdManager (AKPContext context)
        {
            this.db = context;
        }

        public void Add(Ad item)
        {
            db.Ads.Add(item);
            db.SaveChanges();
        }

        public Ad GetById(int id)
        {
            return db.Ads.First(a => a.AdId == id);
        }

        public void Remove(Ad item)
        {
            db.Ads.Remove(item);
            db.SaveChanges();
        }

        public void Update(Ad item)
        {
            if (item.AdId==0)
            {
                db.Ads.Add(item);
            }
            else
            {
                Ad ad = db.Ads.Find(item.AdId);
                if (ad != null)
                {
                    ad.Name = item.Name;
                    ad.AddTime = DateTime.Now;
                    ad.Content = item.Content;
                }          
            }
            db.SaveChanges();
        }
        public IEnumerable<Ad> GetToListDsc()
        {
            var ads = from s in db.Ads select s;
            IEnumerable <Ad> adsList = ads.OrderByDescending(m => m.AddTime);
            return adsList;
        }
    }
}