namespace Homemade.Services.Contracts
{
    using System.Collections.Generic;
    using Homemade.Models.EntityModels;

    interface ICategoryService
    {
        void AddOrUpdate(Category category);

        Category GetById(int id);

        Category GetByName(string name);

        ICollection<Category> GetAll();

        ICollection<string> GetAllTitles();

        void Remove(Category category);
    }
}
