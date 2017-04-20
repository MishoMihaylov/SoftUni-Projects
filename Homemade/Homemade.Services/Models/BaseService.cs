namespace Homemade.Services.Models
{
    using Data.Models;
    using Data.Contracts;

    public abstract class BaseService<T> where T: class
    {
        private IRepository<T> _repository; 

        public BaseService(IRepository<T> repository = null)
        {
            this._repository = repository ?? new Repository<T>();
        }

        protected IRepository<T> Repository
        {
            get
            {
                return this._repository;
            }
        }
    }
}
