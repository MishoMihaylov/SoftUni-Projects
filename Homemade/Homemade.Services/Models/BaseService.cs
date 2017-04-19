namespace Homemade.Services.Models
{
    using Homemade.Data;

    public abstract class BaseService
    {
        //TODO: Use interface
        private HomemadeDbContext _dbContext = new HomemadeDbContext();

        public BaseService(HomemadeDbContext dbContext)
        {
            this._dbContext = dbContext ?? new HomemadeDbContext();
        }

        protected HomemadeDbContext DbContext { get; set; }
    }
}
