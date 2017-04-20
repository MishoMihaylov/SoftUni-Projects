namespace Homemade.Data.Contracts
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    public interface IRepository<T> where T: class
    {
        void AddOrUpdate(T newEntity);

        bool Contains(T entity);

        T FindBy(T entity);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Delete(T entity);
    }
}
