using AKP.DAL;
using AKP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace AKP.Infrastructure
{
    public class UnitOfWork: IDisposable
    {
        private AKPContext db = null;      
        public UnitOfWork ()
        {
            this.db = new AKPContext();
        }
        /*
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public IRepository<T> Repository<T>() where T : class
        {
            // Jeżeli instancja danego repozytorium istnieje - zostanie zwrócona
            if (repositories.Keys.Contains(typeof(T)) == true)
                return repositories[typeof(T)] as IRepository<T>;
            // Jeżeli nie, zostanie utworzona nowa i dodana do słownika
            IRepository<T> repo = new GenericRepository<T>(db);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        */
        IRepository<Person> personRepository = null;
        IRepository<Ad> adRepository = null;
        IRepository<Holiday> holidayRepository = null;
        IRepository<Message> messageRepository = null;
        IRepository<Salary> salaryRepository = null;
        IPersonGet<Person> persongetRepository = null;
        IAdGet<Ad> adgetRepository = null;
        IMessageGet<Message> messagegetRepository = null;
        ISalaryGet<Salary> salarygetRepository = null;
        IHolidayGet<Holiday> holidaygetRepository = null;

        public IHolidayGet<Holiday> HolidayGetRepo
        {
            get
            {
                if (holidaygetRepository == null)
                    holidaygetRepository = new IHolidayManager(db);
                return holidaygetRepository;
            }
        }
        public ISalaryGet<Salary> SalaryGetRepo
        {
            get
            {
                if (salarygetRepository == null)
                    salarygetRepository = new ISalaryManager(db);
                return salarygetRepository;
            }
        }
        public IMessageGet<Message> MessageGetRepo
        {
            get
            {
                if (messagegetRepository == null)
                    messagegetRepository = new IMessageManager(db);
                return messagegetRepository;
            }
        }

        public IAdGet<Ad> AdGetRepo
        {
            get
            {
                if(adgetRepository == null)              
                    adgetRepository = new IAdManager(db);
                        return adgetRepository;                
            }
        }
        public IPersonGet<Person> PersonGetRepo
        {
            get
            {
                if (persongetRepository == null)
                    persongetRepository = new IPersonManager(db);
                return persongetRepository;
            }
        }
        public IRepository<Person> PersonRepo
        {           
            get
            { if (personRepository == null)               
                    personRepository = new IPersonManager(db);
                    return personRepository;               
            }
        }
        public IRepository<Ad> AdRepo
        {
            get
            {
                if (adRepository == null)
                    adRepository = new IAdManager(db);
                return adRepository;
            }
        }
        public IRepository<Holiday> HolidayRepo
        {
            get
            {
                if (holidayRepository == null)
                    holidayRepository = new IHolidayManager(db);
                return holidayRepository;
            }
        }
        public IRepository<Message> MessageRepo
        {
            get
            {
                if (messageRepository == null)
                    messageRepository = new IMessageManager(db);
                return messageRepository;
            }
        }
        public IRepository<Salary> SalaryRepo
        {
            get
            {
                if (salaryRepository == null)
                    salaryRepository = new ISalaryManager(db);
                return salaryRepository;
            }
        }
        
        /*ObjectContext context;
        public ObjectStateEntry GetObjectStateEntry()
        {

            return context.ObjectStateManager.TryGetObjectStateEntry();
 
        }*/
        public void AsNoTracking()
        {
            db.Persons.AsNoTracking();
        }
        public void RefreshAll()
        {
            foreach (var entity in db.ChangeTracker.Entries())
            {
                Detach(entity);
            }
        }
        public void Detach(object item)
        {
             ((IObjectContextAdapter)db).ObjectContext.Detach(item);
            
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}