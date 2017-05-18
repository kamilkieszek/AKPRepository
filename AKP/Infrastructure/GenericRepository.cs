using AKP.DAL;
using AKP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AKP.Infrastructure
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private AKPContext db = null;
        // obiekt reprezentuje kolekcję wszystkich encji w danym kontekście
        // lub może być wynikiem zapytania z bazy danych
        IDbSet<T> _objectSet;
        public GenericRepository(AKPContext _db)
        {
            db = _db;
            _objectSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }
        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _objectSet.First(predicate);
        }

        public IEnumerable<T> GetOverview(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
                return _objectSet.Where(predicate);
            return _objectSet.AsEnumerable();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}