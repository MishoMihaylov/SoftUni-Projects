namespace Homemade.Services.Models
{
    using System.Linq;
    using System.Collections.Generic;
    using Contracts;
    using Homemade.Models.EntityModels;

    public class ProductsService : BaseService, IProductsService
    {
        public void AddOrUpdate(Product product)
        {
            if(product.Category == null)
            {
                product.Category = this.UnitOfWork.Categories.FindById(product.CategoryId);
            }

            this.UnitOfWork.Products.AddOrUpdate(product);
            this.UnitOfWork.Commit();
        }

        public bool Contains(Product product)
        {
            return this.UnitOfWork.Products.Contains(product);
        }

        public Product GetById(int id)
        {
            Product product = this.UnitOfWork.Products.FindBy(p => p.Id == id).Single();

            return product;
        }

        public ICollection<Product> GetByName(string name)
        {
            ICollection<Product> matchedProducts = this.UnitOfWork.Products.FindBy(p => p.Name == name).ToList();

            return matchedProducts;
        }

        public ICollection<Product> GetByCategory(string category)
        {
            ICollection<Product> matchedProducts = this.UnitOfWork.Products.FindBy(p => p.Category.Name == category).ToList();

            return matchedProducts;
        }

        public ICollection<Product> GetByCategoryId(int categoryId)
        {
            ICollection<Product> matchedProducts = this.UnitOfWork.Products.FindBy(p => p.Category.Id == categoryId).ToList();

            return matchedProducts;
        }

        public ICollection<Product> GetFromPrice(decimal fromPrice)
        {
            ICollection<Product> matchedProducts = this.UnitOfWork.Products.FindBy(p => p.Price >= fromPrice).ToList();

            return matchedProducts;
        }

        public ICollection<Product> GetToPrice(decimal toPrice)
        {
            ICollection<Product> matchedProducts = this.UnitOfWork.Products.FindBy(p => p.Price <= toPrice).ToList();

            return matchedProducts;
        }

        public ICollection<Product> GetByPriceRange(decimal fromPrice, decimal toPrice)
        {
            ICollection<Product> matchedProducts = this.UnitOfWork.Products.FindBy(p => p.Price >= fromPrice && p.Price <= toPrice).ToList();

            return matchedProducts;
        }

        public ICollection<Product> GetAll()
        {
            ICollection<Product> matchedProducts = this.UnitOfWork.Products.GetAll().ToList();

            return matchedProducts;
        }

        public void Remove(int id)
        {
            this.UnitOfWork.Products.Delete(id);
            this.UnitOfWork.Commit();
        }

        public void Remove(Product product)
        {
            this.UnitOfWork.Products.Delete(product);
            this.UnitOfWork.Commit();
        }
    }
}


//public IQueryable<Product> FindBy(Expression<Func<Product, bool>> expression)
//{
//    IQueryable<Product> elements =  this.Repository.FindBy(expression);

//    return elements;
//}