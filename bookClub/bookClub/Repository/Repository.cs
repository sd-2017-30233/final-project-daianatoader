using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq.Expressions;

using System.Data.Entity;
using bookClub.Models;

namespace bookClub.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal BookClubContext context;
        internal DbSet<T> dbSet;

        public Repository(BookClubContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public virtual IList<T> GetAll()
        {
            IList<T> list = dbSet.ToList();
            return list;
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
            Save();
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public virtual void Delete(int id)
        {
            T entity = dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            Save();
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

    }
}
