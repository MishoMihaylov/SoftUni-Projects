namespace Homemade.Services.Contracts
{
    using Homemade.Models.EntityModels.Contracts;

    public interface IProductService
    {
        void AddProduct(IProduct product);

        void RemoveProduct(int id, IProduct product);

        void UpdateProduct(int id, IProduct product);

        IProduct GetProduct(int id);
    }
}
