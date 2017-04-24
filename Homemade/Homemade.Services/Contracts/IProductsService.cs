namespace Homemade.Services.Contracts
{
    using System.Collections.Generic;
    using Homemade.Models.EntityModels;

    public interface IProductsService
    {
        void AddOrUpdate(Product product);

        bool Contains(Product product);

        Product GetById(int id);

        ICollection<Product> GetByName(string name);

        ICollection<Product> GetByManufacturer(string manufacturerName);

        ICollection<Product> GetFromPrice(decimal fromPrice);

        ICollection<Product> GetToPrice(decimal toPrice);

        ICollection<Product> GetByPriceRange(decimal fromPrice, decimal toPrice);

        void Remove(int id);

        void Remove(Product product);
    }
}
