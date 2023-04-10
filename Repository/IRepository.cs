namespace EmployeeRequisitionPortal.Repository
{
    public interface IRepository<T> where T : class
    {
        T Find(int id);
        List<T> FindAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
