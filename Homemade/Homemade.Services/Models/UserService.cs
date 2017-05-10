namespace Homemade.Services.Models
{
    using System.Linq;
    using System.Collections.Generic;
    using Homemade.Models.EntityModels;
    using Homemade.Services.Contracts;

    public class UserService : BaseService, IUserService
    {
        public HomemadeUser GetUserById(string id)
        {
            return this.UnitOfWork.Users.FindBy(user => user.Id == id).Single();
        }

        public ICollection<HomemadeUser> GetAll()
        {
            return this.UnitOfWork.Users.GetAll().ToList();
        }

        public void ChangeRole(HomemadeUser user, string role)
        {
            this.UnitOfWork.Users.ChangeRole(user, role);
        }
    }
}
