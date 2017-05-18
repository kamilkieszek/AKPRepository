using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AKP.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using Microsoft.AspNet.Identity.EntityFramework;
using AKP.ViewModels;

namespace AKP.DAL
{
    public class AKPContext : IdentityDbContext<ApplicationUser>
    {
        public AKPContext(): base("AKPContext")
        {

        }
        public static AKPContext Create()
        {
            return new AKPContext();
        }
        public DbSet<Person> Persons
        {
            get; set;
        }
        public DbSet<Holiday> Holidays
        {
            get; set;
        }
        public DbSet<Ad> Ads
        {
            get; set;
        }
        public DbSet<Message> Messages
        {
            get; set;
        }
        public DbSet<Salary> Salaries
        {
            get; set;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AKPContext>(null);
            base.OnModelCreating(modelBuilder);
            // Wyłącza konwencję, która automatycznie tworzy liczbę mnogą dla nazw tabel w bazie danych
            // Zamiast Kategorie zostałaby stworzona tabela o nazwie Kategories
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

       
            public override int SaveChanges()
            {
                try
                {
                    return base.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }
        }
    }
