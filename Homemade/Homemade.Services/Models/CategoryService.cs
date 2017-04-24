namespace Homemade.Services.Models
{
    using System.Linq;
    using System.Collections.Generic;
    using Contracts;
    using Data.Contracts;
    using Homemade.Models.EntityModels;

    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IRepository<Category> repository = null) : base(repository)
        {
        }

        public void AddOrUpdate(Category category)
        {
            this.Repository.AddOrUpdate(category);
        }

        public Category GetById(int id)
        {
            Category category = this.Repository.FindBy(p => p.Id == id).Single();

            return category;
        }

        //Make sure name is unique!!!
        public Category GetByName(string name)
        {
            Category category = this.Repository.FindBy(c => c.Name == name).Single();

            return category;
        }

        public ICollection<Category> GetAll()
        {
            ICollection<Category> allCategories = this.Repository.GetAll().ToList();

            return allCategories;
        }

        public ICollection<string> GetAllTitles()
        {
            ICollection<string> allCategoryTitles = this.Repository.GetAll().Select(cat => cat.Name).ToList();

            return allCategoryTitles;
        }

        public void Remove(Category category)
        {
            this.Repository.Delete(category);
        }
    }
}
