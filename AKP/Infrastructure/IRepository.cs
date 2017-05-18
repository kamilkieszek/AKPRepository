using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKP.Models
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        void Add(T item);
        void Remove(T item);
        void Update(T item);
    }
}
