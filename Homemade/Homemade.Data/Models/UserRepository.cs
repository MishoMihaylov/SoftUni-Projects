namespace Homemade.Data.Models
{
    using Homemade.Data.Contracts;
    using Homemade.Models.EntityModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class UserRepository : Repository<HomemadeUser>, IUserRepository
    {
        public UserRepository(HomemadeDbContext context = null) : base(context)
        {
        }

        public void ChangeRole(HomemadeUser user, string role)
        {
            var userStore = new UserStore<HomemadeUser>(this._context);
            var userManager = new UserManager<HomemadeUser>(userStore);
            userManager.AddToRole(user.Id, role);
        }
    }
}
