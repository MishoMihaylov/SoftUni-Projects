namespace Homemade.Services.Models
{
    using System;
    using Contracts;
    using Data.Contracts;
    using Homemade.Models.EntityModels;
    using Homemade.Models.EntityModels.Contracts;

    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IRepository<Product> repository = null) : base(repository)
        {
        }

        public void AddProduct(IProduct product)
        {
        }

        public IProduct GetProduct(int id)
        {

            return new Product();
        }

        public void RemoveProduct(int id, IProduct product)
        {
            Console.WriteLine("");
        }

        public void UpdateProduct(int id, IProduct product)
        {
            Console.WriteLine("");
        }
    }
}
