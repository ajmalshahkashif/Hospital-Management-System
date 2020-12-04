using Pharmacy.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pharmacy.Models
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private HospitalEntities1 _context = null;
        private DbSet<T> table = null;

        public GenericRepo()
        {
            this._context = new HospitalEntities1();
            table = _context.Set<T>();
        }

        public GenericRepo(HospitalEntities1 _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            return table.Find(id);
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            table.Add(obj);
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
            throw new NotImplementedException();
        }

    }
}
