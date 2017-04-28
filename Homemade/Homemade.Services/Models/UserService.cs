using Homemade.Models.EntityModels;

namespace Homemade.Services.Models
{
    public class UserService : BaseService<HomemadeUser>
    {
        public HomemadeUser GetUserById(string id)
        {
            return this.Repository.FindById(id);
        }
    }
}
