namespace ACME.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> All();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}