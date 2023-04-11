namespace EmployeeRequisitionPortal.Repository
{
    public interface IRepository<T> where T : class
    {
        T FindById(long id);
        List<T> FindAll();
        void Add(T entity);
        void UpdateData(T entity);
        void Delete(int id);
    }
}
