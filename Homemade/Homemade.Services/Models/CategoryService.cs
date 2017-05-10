namespace Homemade.Services.Models
{
    using System.Linq;
    using System.Collections.Generic;
    using Contracts;
    using Data.Contracts;
    using Homemade.Models.EntityModels;

    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork = null) : base(unitOfWork)
        {
        }

        public void AddOrUpdate(Category category)
        {
            this.UnitOfWork.Categories.AddOrUpdate(category);
            this.UnitOfWork.Commit();
        }

        public Category GetById(int id)
        {
            Category category = this.UnitOfWork.Categories.FindBy(p => p.Id == id).Single();

            return category;
        }

        public Category GetByName(string name)
        {
            Category category = this.UnitOfWork.Categories.FindBy(c => c.Name == name).Single();

            return category;
        }

        public ICollection<Category> GetAll()
        {
            ICollection<Category> allCategories = this.UnitOfWork.Categories.GetAll().ToList();

            return allCategories;
        }

        public ICollection<string> GetAllTitles()
        {
            ICollection<string> allCategoryTitles = this.UnitOfWork.Categories.GetAll().Select(cat => cat.Name).ToList();

            return allCategoryTitles;
        }

        public void Remove(Category category)
        {
            this.UnitOfWork.Categories.Delete(category);
            this.UnitOfWork.Commit();
        }
    }
}
