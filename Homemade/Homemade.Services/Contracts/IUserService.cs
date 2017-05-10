namespace Homemade.Services.Contracts
{
    using System.Collections.Generic;
    using Homemade.Models.EntityModels;

    interface IUserService
    {
        HomemadeUser GetUserById(string id);

        ICollection<HomemadeUser> GetAll();

        void ChangeRole(HomemadeUser user, string role);
    }
}
