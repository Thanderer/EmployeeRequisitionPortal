using EmployeeRequisitionPortal.Data;
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
            _dbSet.Remove(FindById(id));
            _context.SaveChanges();
        }

        public T FindById(long id)
        { 
            var data = _dbSet.Find(id);
            return data;
        }

        public List<T> FindAll()
        {
            return _dbSet.ToList();
        }

        public void UpdateData(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public T FindByName(string name)
        {
            return _dbSet.Find(name);//??can we use this to find id fro given name
        }
    }
}
