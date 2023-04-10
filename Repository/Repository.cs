﻿using EmployeeRequisitionPortal.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequisitionPortal.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(Find(id));
            _context.SaveChanges();
        }

        public T Find(int id)
        {
            var data = _dbSet.FirstOrDefault(x => x.Equals(id));
            if(data == null)
            {
                throw new Exception(message: "Id does not exits");
            }
            else
            {
                return data;
            }
        }

        public List<T> FindAll()
        {
            return _dbSet.ToList();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}