namespace Homemade.Services.Models
{
    using System;
    using Contracts;
    using Homemade.Models.EntityModels;
    using Homemade.Models.EntityModels.Contracts;

    public class ProductService : BaseService, IProductService
    {
        public ProductService() : base(new Data.HomemadeDbContext())
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
