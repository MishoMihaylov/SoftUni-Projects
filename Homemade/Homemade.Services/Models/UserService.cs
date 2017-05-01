using Homemade.Models.EntityModels;

namespace Homemade.Services.Models
{
    public class UserService : BaseService<HomemadeUser>
    {
        public HomemadeUser GetUserById(string id)
        {
            return (HomemadeUser)this.Repository.FindBy(user => user.Id == id);
        }
    }
}
