using Homemade.Models.EntityModels;

namespace Homemade.Data.Contracts
{
    public interface IUserRepository : IRepository<HomemadeUser> 
    {
        void ChangeRole(HomemadeUser user, string role);
    }
}
