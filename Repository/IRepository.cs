namespace EmployeeRequisitionPortal.Repository
{
    public interface IRepository<T> where T : class
    {
        T FindById(long id);
        IQueryable<T> FindAll();
        void Add(T entity);
        void UpdateData(T entity);
        void Delete(int id);
        T FindByName(string name);
    }
}
