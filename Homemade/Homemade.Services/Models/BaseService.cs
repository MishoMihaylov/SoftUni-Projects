namespace Homemade.Services.Models
{
    using Data.Models;
    using Data.Contracts;

    public abstract class BaseService
    {
        private IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork = null)
        {
            this._unitOfWork = unitOfWork ?? new UnitOfWork();
        }

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return this._unitOfWork;
            }
        }
    }
}
