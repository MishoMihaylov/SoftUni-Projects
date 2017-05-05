namespace Homemade.Data.Contracts
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T: class
    {
        void AddOrUpdate(T entity);

        bool Contains(T entity);

        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        T FindById(int id);

        void Delete(int id);

        void Delete(T entity);
    }
}
