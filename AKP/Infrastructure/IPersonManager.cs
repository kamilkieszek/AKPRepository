using AKP.DAL;
using AKP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AKP.Infrastructure
{
    public class IPersonManager : IRepository<Person>, IPersonGet<Person>
    {
        private AKPContext db = null;
        public IPersonManager (AKPContext context)
        {
            this.db = context;
        }
        public void Add(Person item)
        {
            db.Persons.Add(item);
            db.SaveChanges();    
        }

        public Person GetById(int id)
        {
            return db.Persons.FirstOrDefault(a => a.PersonId == id);
        }
        public List<Person> GetByName(string Name, string Surname)
        {
            return db.Persons.Where(a => a.Name == Name && a.Surname == Surname).ToList();
        }
        public void Remove(Person item)
        {
            db.Persons.Remove(item);
            db.SaveChanges();
        }
        public void Update(Person item)
        {
            if (item.PersonId == 0)
            {
                db.Persons.Add(item);
            }
            else
            {
                Person person = db.Persons.First(a => a.PersonId == item.PersonId);
                person.Name = item.Name;
                person.Surname = item.Surname;
                person.City = item.City;
                person.Street = item.Street;
                person.StreetNr = item.StreetNr;
                person.PostalCode = item.PostalCode;
                person.TelNumber = item.TelNumber;
                person.Appointment = item.Appointment;
                person.DateOfEmployment = DateTime.Now;
                person.Education = item.Education;
                person.IncomeGroup = item.IncomeGroup;                
            }
            db.SaveChanges();
        }
        public List<string> GetMail(string term)
        {
            var mail = db.Persons.Where(m => m.Name.StartsWith(term)).Select(m => m.Name).ToList();
            return mail;
        }
        public int GetPersonIdByUserId(string item)
        {
            var user = db.Users.Where(m => m.Id == item).Single();
            int Id = user.person.PersonId;
            return Id;
        }
        public Person GetPersonsByRole(string item)
        {
            List<Person> persons = null;
            var role = (from r in db.Roles where r.Name.Contains(item) select r).FirstOrDefault();
            var Users = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();
            foreach (var model in Users )
            {
                persons.Add(model.person);
            }
            //zmien na liste adminow
            Person person = persons.FirstOrDefault();         
            return person;
        }
    }
}