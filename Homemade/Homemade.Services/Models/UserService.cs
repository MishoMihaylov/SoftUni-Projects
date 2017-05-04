namespace Homemade.Services.Models
{
    using System.Linq;
    using Homemade.Models.EntityModels;

    public class UserService : BaseService<HomemadeUser>
    {
        public HomemadeUser GetUserById(string id)
        {
            return this.Repository.FindBy(user => user.Id == id).Single();
        }
    }
}
