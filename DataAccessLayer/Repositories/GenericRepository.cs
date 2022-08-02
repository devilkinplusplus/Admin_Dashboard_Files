﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context c = new Context();
        public void Delete(T t)
        {
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            var data = c.Set<T>().Find(id);
            return data;
        }

        public List<T> GetListAll()
        {
            return c.Set<T>().ToList();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            return c.Set<T>().Where(filter).ToList();
        }

        public void Insert(T t)
        {
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            c.Update(t);
            c.SaveChanges();
        }
    }
}