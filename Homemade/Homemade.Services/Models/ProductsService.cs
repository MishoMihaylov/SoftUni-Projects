namespace Homemade.Services.Models
{
    using System.Linq;
    using System.Collections.Generic;
    using Contracts;
    using Data.Contracts;
    using Homemade.Models.EntityModels;

    public class ProductsService : BaseService<Product>, IProductsService
    {
        public ProductsService(IRepository<Product> repository = null) : base(repository)
        {
        }

        public void AddOrUpdate(Product product)
        {
            this.Repository.AddOrUpdate(product);
        }

        public bool Contains(Product product)
        {
            return this.Repository.Contains(product);
        }

        public Product GetById(int id)
        {
            Product product = this.Repository.FindBy(p => p.Id == id).Single();

            return product;
        }

        public ICollection<Product> GetByName(string name)
        {
            ICollection<Product> matchedProducts = this.Repository.FindBy(p => p.Name == name).ToList();

            return matchedProducts;
        }

        public ICollection<Product> GetByCategory(string category)
        {

            ICollection<Product> matchedProducts = this.Repository.FindBy(p => p.Category.Name == category).ToList();

            return matchedProducts;
        }

        public ICollection<Product> GetByManufacturer(string manufacturerName)
        {
            ICollection<Product> matchedProducts = this.Repository.FindBy(p => p.Producer == manufacturerName).ToList();

            return matchedProducts;
        }

        public ICollection<Product> GetFromPrice(decimal fromPrice)
        {
            ICollection<Product> matchedProducts = this.Repository.FindBy(p => p.Price >= fromPrice).ToList();

            return matchedProducts;
        }

        public ICollection<Product> GetToPrice(decimal toPrice)
        {
            ICollection<Product> matchedProducts = this.Repository.FindBy(p => p.Price <= toPrice).ToList();

            return matchedProducts;
        }

        public ICollection<Product> GetByPriceRange(decimal fromPrice, decimal toPrice)
        {
            ICollection<Product> matchedProducts = this.Repository.FindBy(p => p.Price >= fromPrice && p.Price <= toPrice).ToList();

            return matchedProducts;
        }

        public void Remove(int id)
        {
            this.Repository.Delete(id);
        }

        public void Remove(Product product)
        {
            this.Repository.Delete(product);
        }
    }
}


//public IQueryable<Product> FindBy(Expression<Func<Product, bool>> expression)
//{
//    IQueryable<Product> elements =  this.Repository.FindBy(expression);

//    return elements;
//}