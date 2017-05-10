namespace Homemade.Data.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Data.Entity.Migrations;
    using Contracts;

    public class Repository<T>: IRepository<T> where T: class
    {
        protected readonly HomemadeDbContext _context;

        public Repository(HomemadeDbContext context = null)
        {
            this._context = context ?? new HomemadeDbContext();
        }

        public void AddOrUpdate(T newEntity)
        {
            this._context.Set<T>().AddOrUpdate(newEntity);
        }

        public bool Contains(T entity)
        {
            return this._context.Set<T>().Contains<T>(entity);
        }

        public IQueryable<T> GetAll()
        {
            return this._context.Set<T>();
        }

        public T FindById(int id)
        {
            return this._context.Set<T>().Find(id);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> foundEntities =  this._context.Set<T>().Where(predicate);

            return foundEntities;
        }

        public void Delete(int id)
        {
            T entity = FindById(id);

            this._context.Set<T>().Remove(entity);
        }

        public void Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }
    }
}
